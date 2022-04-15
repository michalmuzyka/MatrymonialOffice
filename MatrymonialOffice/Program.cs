using System;
using System.Windows.Forms;

namespace MatrymonialOffice
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Test.TestMatchingAlghorithm();

            Application.Run(new Form1());
        }
    }
}