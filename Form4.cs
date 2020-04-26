using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace Biometric_Document
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private DataTable GetResults()
        {
            DataTable results = new DataTable();

            DB db = new DB();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM receipts", db.getConnection());
            db.openConnection();          
            
            MySqlDataReader reader = cmd.ExecuteReader();
            results.Load(reader);

            return results;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            resultsTable.DataSource = GetResults();
        }


}