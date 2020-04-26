using MySql.Data.MySqlClient;
using SecuGen.SecuBSPPro.Windows;
using Spire.Doc;
using Spire.Pdf;
using Spire.Pdf.Security;
using Spire.Pdf.Widget;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Biometric_Document
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private String user = DB.username;
        private String f_data;
        private String matric;
        private String name;
        private DB db = new DB();
        private DataTable table = new DataTable();
        private MySqlDataAdapter adapter = new MySqlDataAdapter();
        private static SecuBSPMx m_SecuBSP = new SecuBSPMx();
        private PdfDocument pdf = new PdfDocument();
        private BSPError err = m_SecuBSP.EnumerateDevice();

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome, "+DB.username;

            db.openConnection();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `data` WHERE `user`=@user", db.getConnection());
            command.Parameters.Add("@user", MySqlDbType.VarChar).Value = user;

            MySqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                f_data = rdr.GetString(4);
                matric = rdr.GetString(3);
                name = rdr.GetString(2);
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (!(TransactionID.Text.Equals("") || ReceiptID.Text.Equals("")))
            {
                String t_id = TransactionID.Text;
                String r_id = ReceiptID.Text;
                Document doc = new Document();
                string newPath = Directory.GetCurrentDirectory();

                doc.LoadFromFile(newPath + "\\Receipt Template.docx");

                doc.Replace("_Matric_", matric, false, true);
                doc.Replace("_Id_", t_id, false, true);
                doc.Replace("_Receipt_", r_id, false, true);
                doc.Replace("_Name_", name, false, true);
                doc.Replace("_Date_", DateTime.Today.ToShortDateString(), false, true);
                doc.Replace("_Method_", "Quickteller", false, true);

                //Save PDF file.
                doc.SaveToFile("Receipt.pdf", Spire.Doc.FileFormat.PDF);

                pdf.LoadFromFile("Receipt.pdf");

                //Set document info
                pdf.DocumentInformation.Author = "Bowen University";
                pdf.DocumentInformation.Creator = "Ali Akolade";
                pdf.DocumentInformation.Keywords = "Bursary, Receipt, Clearance";
                pdf.DocumentInformation.Producer = "Bowen University";
                pdf.DocumentInformation.Subject = f_data;
                pdf.DocumentInformation.Title = "Bursary Clearance of " + name;

                //File info
                pdf.FileInfo.CrossReferenceType = PdfCrossReferenceType.CrossReferenceStream;
                pdf.FileInfo.IncrementalUpdate = false;

                //Set an owner password, enable the permissions of Printing and Copying, set encryption level
                String pfxPath = "AliAkolade.pfx";
                PdfCertificate cer = new PdfCertificate(pfxPath, "Abc123!@#$%^&*()2020", X509KeyStorageFlags.Exportable);

                //Get the first page
                PdfPageBase page = pdf.Pages[0];

                //Add a signature to the specified position
                PdfSignature signature = new PdfSignature(pdf, page, cer, "signature");
                //signature.Bounds = new RectangleF(new PointF(90, 550), new SizeF(180, 90));

                //set the signature content
                signature.NameLabel = "Digitally signed by: Bowen University";
                signature.LocationInfoLabel = "Location: Iwo, Osun State";
                signature.LocationInfo = "Iwo";
                signature.ReasonLabel = "Reason: Biometric Security Certificate";
                signature.Reason = "Ensures authenticity";
                signature.ContactInfoLabel = "Contact Number: 09032942619";
                signature.ContactInfo = "@AliAkolade";
                signature.DocumentPermissions = PdfCertificationFlags.ForbidChanges;
                signature.GraphicsMode = GraphicMode.SignNameAndSignDetail;
                //signature.SignImageSource = PdfImage.FromFile(@"..\..\..\..\..\..\Data\logo.png");

                //Configure OCSP which must conform to RFC 2560
                signature.ConfigureHttpOCSP(null, null);

                //
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `receipts`(`Matric Number`, `Transaction ID`, `Receipt ID`, `Amount Paid`, `Amount Due`) VALUES (@matric, @t_id, @r_id, @paid, @due)", db.getConnection());
                command.Parameters.Add("@matric", MySqlDbType.VarChar).Value = matric;
                command.Parameters.Add("@t_id", MySqlDbType.Int64).Value = t_id;
                command.Parameters.Add("@r_id", MySqlDbType.Int64).Value = r_id;
                command.Parameters.Add("@paid", MySqlDbType.Int64).Value = 824662;
                command.Parameters.Add("@due", MySqlDbType.Int64).Value = 0;

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    AutoClosingMessageBox.Show("Added to Database", "RECEIPT GENERATION SUCCESSFUL", 1500);
                }

                db.closeConnection();

                //Save and launch
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "PDF document (*.pdf)|*.pdf";
                DialogResult result = dialog.ShowDialog();
                string fileName = dialog.FileName;
                if (result == DialogResult.OK)
                {
                    pdf.SaveToFile(fileName);
                    AutoClosingMessageBox.Show("Save Successful", "", 1000);
                }

                System.Diagnostics.Process.Start(fileName);
            }
            else
            {
                AutoClosingMessageBox.Show("Please Input Valid Details", "ERROR", 1000);
            }
        }

        private void VerifySC_Click(object sender, EventArgs e)
        {
            err = m_SecuBSP.EnumerateDevice();
            pdf = new PdfDocument();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PDF document (*.pdf)|*.pdf";
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    string pdfFile = dialog.FileName;

                    List<PdfSignature> signatures = new List<PdfSignature>();
                    //Open a pdf document and get its all signatures
                    using (PdfDocument pdf = new PdfDocument())
                    {
                        pdf.LoadFromFile(pdfFile);
                        PdfFormWidget form = pdf.Form as PdfFormWidget;
                        for (int i = 0; i < form.FieldsWidget.Count; i++)
                        {
                            PdfSignatureFieldWidget field = form.FieldsWidget[i] as PdfSignatureFieldWidget;
                            if (field != null && field.Signature != null)
                            {
                                PdfSignature signature = field.Signature;
                                signatures.Add(signature);
                            }
                        }

                        //Get the first signature
                        PdfSignature signatureOne = signatures[0];

                        //Detect if the pdf document was modified
                        bool modified = signatureOne.VerifyDocModified();

                        //FIND
                        err = m_SecuBSP.EnumerateDevice();
                        m_SecuBSP.DeviceID = (Int16)DeviceID.AUTO;

                        //OPEN
                        err = m_SecuBSP.OpenDevice();
                        if (err == BSPError.ERROR_NONE)
                        {
                            if (!modified)
                            {
                                PdfDocumentInformation docInfo = pdf.DocumentInformation;
                                err = m_SecuBSP.Capture(FIRPurpose.VERIFY);
                                if (err == BSPError.ERROR_NONE)
                                {
                                    err = m_SecuBSP.VerifyMatch(m_SecuBSP.FIRTextData, docInfo.Subject);

                                    if (err == BSPError.ERROR_NONE)
                                    {
                                        if (m_SecuBSP.IsMatched)
                                        {
                                            AutoClosingMessageBox.Show("The Document is Authentic", "", 1500);
                                        }
                                        else { AutoClosingMessageBox.Show("The Document is not Authentic", "", 1500); }
                                    }
                                }
                            }
                            else
                            {
                                AutoClosingMessageBox.Show("The Document is not Authentic", "", 1500);
                            }
                        }
                        else { AutoClosingMessageBox.Show("No Scanner Detected", "Error!", 1000); }
                    }
                }
                catch (Exception exe)
                {
                    MessageBox.Show("Document is not Authentic", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void VerifyDB_Click(object sender, EventArgs e)
        {
            pdf = new PdfDocument();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PDF document (*.pdf)|*.pdf";
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    string pdfFile = dialog.FileName;

                    List<PdfSignature> signatures = new List<PdfSignature>();
                    //Open a pdf document and get its all signatures
                    using (PdfDocument pdf = new PdfDocument())
                    {
                        pdf.LoadFromFile(pdfFile);
                        PdfFormWidget form = pdf.Form as PdfFormWidget;
                        for (int i = 0; i < form.FieldsWidget.Count; i++)
                        {
                            PdfSignatureFieldWidget field = form.FieldsWidget[i] as PdfSignatureFieldWidget;
                            if (field != null && field.Signature != null)
                            {
                                PdfSignature signature = field.Signature;
                                signatures.Add(signature);
                            }
                        }

                        //Get the first signature
                        PdfSignature signatureOne = signatures[0];

                        //Detect if the pdf document was modified
                        bool modified = signatureOne.VerifyDocModified();

                        if (!modified)
                        {
                            PdfDocumentInformation docInfo = pdf.DocumentInformation;
                            err = m_SecuBSP.Capture(FIRPurpose.VERIFY);
                            err = m_SecuBSP.VerifyMatch(f_data, docInfo.Subject);

                            if (err == BSPError.ERROR_NONE)
                            {
                                if (m_SecuBSP.IsMatched)
                                {
                                    AutoClosingMessageBox.Show("The Document is Authentic", "", 1500);
                                }
                                else { AutoClosingMessageBox.Show("The Document is not Authentic", "", 1500); }
                            }
                        }
                        else
                        {
                            AutoClosingMessageBox.Show("The Document is not Authentic", "", 1500);
                        }
                      
                    }
                }
                catch (Exception exe)
                {
                    MessageBox.Show("Document is not Authentic", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
