using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Biometric_Document
{
    internal class DB
    {
        private MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=biodocumentation");

        public void openConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return conn;
        }

        public void checkConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

            MessageBox.Show(conn.State.ToString());
        }

        static public string username;
    }
}
