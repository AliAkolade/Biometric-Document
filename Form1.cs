using MySql.Data.MySqlClient;
using SecuGen.SecuBSPPro.Windows;
using System;
using System.Data;
using System.Windows.Forms;

namespace Biometric_Document
{
    public partial class Form1 : Form
    {
        private static SecuBSPMx m_SecuBSP = new SecuBSPMx();
        private BSPError err = m_SecuBSP.EnumerateDevice();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == (int)DriverMessage.WM_DEVICE_EVENT)
            {
                if (message.WParam.ToInt32() == (Int32)DeviceEvent.FINGER_ON)
                {
                    StatusBar.Text = "Scanning Finger";

                    //CAPTURE
                    string m_CaptureFIRText;
                    err = m_SecuBSP.Capture(FIRPurpose.VERIFY);
                    if (err == BSPError.ERROR_NONE)
                    {
                        m_CaptureFIRText = m_SecuBSP.FIRTextData;

                        StatusBar.Text = "Logging In";

                        DB db = new DB();
                        DataTable table = new DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        db.openConnection();

                        MySqlCommand command = new MySqlCommand("SELECT * FROM `data`", db.getConnection());


                        MySqlDataReader rdr = command.ExecuteReader();
                       
                        while (rdr.Read()) 
                        {
                            //VERIFYMATCH
                            err = m_SecuBSP.VerifyMatch(m_CaptureFIRText, rdr.GetString(4));
                            DB.username = rdr.GetString(0);

                            if (err == BSPError.ERROR_NONE)
                            {
                                if (m_SecuBSP.IsMatched)
                                {
                                    AutoClosingMessageBox.Show("Access Granted", "Caption", 1500);
                                    
                                    //db.closeConnection();
                                    IsLoggedInDash = true;
                                    this.Close();
                                    
                                    
                                }
                                else 
                                {
                                    AutoClosingMessageBox.Show("Finger Not recognized", "Login Error", 1000);
                                }
                               
                            }
                        }
                        
                       
                       
                    }
                }
                else if (message.WParam.ToInt32() == (Int32)DeviceEvent.FINGER_OFF)
                {
                    StatusBar.Text = "Scanner Connected";
                }
            }
            base.WndProc(ref message);
        }

        public bool IsLoggedInReg { get; set; }
        public bool IsLoggedInDash { get; set; }
        public bool IsLoggedInAdmin { get; set; }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            IsLoggedInReg = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            String user = textBox1.Text.Trim();
            String pass = textBox2.Text.Trim();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `data` WHERE `user`=@usn AND `pass`=@pas", db.getConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = user;
            command.Parameters.Add("@pas", MySqlDbType.VarChar).Value = pass;

            

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                int acc_type = 0;

                db.openConnection();
                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    acc_type = rdr.GetInt16(5);
                }

                if (acc_type == 1)
                {
                    AutoClosingMessageBox.Show("Access Granted", "Welcome Administrator", 1500);

                    db.closeConnection();

                    this.Close();
                    IsLoggedInAdmin = true;
                    DB.username = user;

                }
                else {
                    AutoClosingMessageBox.Show("Access Granted", "Caption", 1500);

                    db.closeConnection();

                    this.Close();
                    IsLoggedInDash = true;
                    DB.username = user;
                }

                
           
            }
            else
            {
                AutoClosingMessageBox.Show("Access Denied", "Caption", 1500);
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FIND
            err = m_SecuBSP.EnumerateDevice();
            m_SecuBSP.DeviceID = (Int16)DeviceID.AUTO;

            //OPEN
            err = m_SecuBSP.OpenDevice();
            if (err == BSPError.ERROR_NONE)
            {
                StatusBar.Text = "Scanner Detected";
            }

            //AUTO-ON
            if (this.Visible)
            {
                m_SecuBSP.MonitorDevice(true, this.Handle);
            }
        }

    }
}
