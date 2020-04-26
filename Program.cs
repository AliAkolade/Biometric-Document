using System;
using System.Windows.Forms;

namespace Biometric_Document
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 frm1 = new Form1();
            Form2 frm2 = new Form2();
            Form3 frm3 = new Form3();
            Application.Run(frm1);

            if (frm1.IsLoggedInReg)
            {
                frm2 = new Form2(); ;
                Application.Run(frm2);
            }

            if (frm1.IsLoggedInDash)
            {
                frm3 = new Form3();

                Application.Run(frm3);
            }

            if (frm2.IsLoggedInLogin)
            {
                frm1 = new Form1();
                Application.Restart();
            }
        }
    }
}