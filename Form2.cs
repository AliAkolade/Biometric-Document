using MySql.Data.MySqlClient;
using SecuGen.SecuBSPPro.Windows;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Biometric_Document
{
    public partial class Form2 : Form
    {
        private static SecuBSPMx m_SecuBSP = new SecuBSPMx();
        private BSPError err = m_SecuBSP.EnumerateDevice();
        public Form2()
        {
            InitializeComponent();
        }

        public bool IsLoggedInLogin { get; set; }


        private void button1_Click(object sender, EventArgs e)
        {
            if (StatusBar.Text.Equals("(No Scanner Detected)"))
            {
                if (!(textBox3.Text.Equals(textBox5.Text)))
                {
                    AutoClosingMessageBox.Show("Passwords Don't Match", "ERROR", 1500);
                }
                else
                {
                    DB db = new DB();
                    MySqlCommand command = new MySqlCommand("INSERT INTO `data`(`user`, `pass`, `name`, `matric`, `acc`) VALUES (@user, @pass, @name, @matric, @acc)", db.getConnection());
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
                    command.Parameters.Add("@user", MySqlDbType.VarChar).Value = textBox4.Text;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox3.Text;
                    command.Parameters.Add("@matric", MySqlDbType.VarChar).Value = textBox2.Text;
                    command.Parameters.Add("@acc", MySqlDbType.Bit).Value = 0;

                    db.openConnection();

                    if (checkUsername())
                    {
                        AutoClosingMessageBox.Show("Username Already Taken", "ERROR", 1500);
                    }
                    else
                    {
                        if (command.ExecuteNonQuery() == 1)
                        {
                            this.Close();
                            IsLoggedInLogin = true;
                            
                            AutoClosingMessageBox.Show("PLEASE LOGIN", "ACCOUNT CREATION SUCCESSFUL", 1500);
                        }
                        else
                        {
                            AutoClosingMessageBox.Show("Error", "Caption", 1500);
                        }
                    }

                    db.closeConnection();

                    Boolean checkUsername()
                    {
                        DB dbb = new DB();
                        String user = textBox4.Text;

                        DataTable table = new DataTable();

                        MySqlDataAdapter adapter = new MySqlDataAdapter();

                        MySqlCommand comm = new MySqlCommand("SELECT * FROM `data` WHERE `user`=@usn", dbb.getConnection());
                        comm.Parameters.Add("@usn", MySqlDbType.VarChar).Value = user;
                        adapter.SelectCommand = comm;

                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                if (StatusBar.Text.Equals("(Registration Successful)")) 
                {
                    if (!(textBox3.Text.Equals(textBox5.Text)))
                    {
                        AutoClosingMessageBox.Show("Passwords Don't Match", "ERROR", 1500);
                    }
                    else
                    {
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("INSERT INTO `data`(`user`, `pass`, `name`, `matric`, `acc` , `bio`) VALUES (@user, @pass, @name, @matric, @acc, @bio)", db.getConnection());
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
                        command.Parameters.Add("@user", MySqlDbType.VarChar).Value = textBox4.Text;
                        command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox3.Text;
                        command.Parameters.Add("@matric", MySqlDbType.VarChar).Value = textBox2.Text;
                        command.Parameters.Add("@bio", MySqlDbType.LongText).Value = m_SecuBSP.FIRTextData;
                        command.Parameters.Add("@acc", MySqlDbType.Bit).Value = 0;

                        db.openConnection();

                        if (checkUsername())
                        {
                            AutoClosingMessageBox.Show("Username Already Taken", "ERROR", 1500);
                        }
                        else
                        {
                            if (command.ExecuteNonQuery() == 1)
                            {
                                this.Close();
                                IsLoggedInLogin = true;
                                AutoClosingMessageBox.Show("PLEASE LOGIN", "ACCOUNT CREATION SUCCESSFUL", 1500);
                            }
                            else
                            {
                                AutoClosingMessageBox.Show("Error", "Caption", 1500);
                            }
                        }

                        db.closeConnection();

                        Boolean checkUsername()
                        {
                            DB dbb = new DB();
                            String user = textBox4.Text;

                            DataTable table = new DataTable();

                            MySqlDataAdapter adapter = new MySqlDataAdapter();

                            MySqlCommand comm = new MySqlCommand("SELECT * FROM `data` WHERE `user`=@usn", dbb.getConnection());
                            comm.Parameters.Add("@usn", MySqlDbType.VarChar).Value = user;
                            adapter.SelectCommand = comm;

                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                else 
                { 
                    AutoClosingMessageBox.Show("Please Register a Fingerprint", "ERROR", 1000);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            IsLoggedInLogin = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string m_EnrollFIRText;
            m_SecuBSP.EnableAuditData = true;
            err = m_SecuBSP.Enroll("Matric Number - " + textBox2.Text);
            if (err == BSPError.ERROR_NONE)
            {
                m_EnrollFIRText = m_SecuBSP.FIRTextData;
                StatusBar.Text = "Registered Successfully";

                //VIEW
                string m_AuditFIR = m_SecuBSP.AuditFIRTextData;
                err = m_SecuBSP.ExportAuditData(m_AuditFIR);
                if (err == BSPError.ERROR_NONE)
                {
                    ExportImageDataStruct m_FIRImageData = m_SecuBSP.FIRImageData;

                    NumFingsLabel.Text = "Number of Fingers: " + Convert.ToString(m_FIRImageData.NumOfFingers);
                    DrawImage(m_FIRImageData.ImageData[0].Sample1, pictureBox1);

                    void DrawImage(Byte[] imgData, PictureBox picBox)
                    {
                        int colorval;
                        Bitmap bmp = new Bitmap(m_FIRImageData.ImageWidth, m_FIRImageData.ImageHeight);
                        picBox.Image = (Image)bmp;

                        for (int i = 0; i < bmp.Width; i++)
                        {
                            for (int j = 0; j < bmp.Height; j++)
                            {
                                colorval = (int)imgData[(j * m_FIRImageData.ImageWidth) + i];
                                bmp.SetPixel(i, j, Color.FromArgb(colorval, colorval, colorval));
                            }
                        }
                        picBox.Refresh();
                        StatusBar.Text = "(Registration Successful)";
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //FIND
            err = m_SecuBSP.EnumerateDevice();
            if (err == BSPError.ERROR_NONE)

                m_SecuBSP.DeviceID = (Int16)DeviceID.AUTO;

            //OPEN
            err = m_SecuBSP.OpenDevice();
            if (err == BSPError.ERROR_NONE)
            {
                StatusBar.Text = "(Scanner Detected)";
            }
            else
            {
                StatusBar.Text = "(No Scanner Detected)";
            }
        }
    }
}