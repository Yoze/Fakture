using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Fakture.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainWindow());

            Application.Run(new OdabirKorisnikaForm());

            //Application.Run(new ONama());
           // Application.Run(new test());


        }
    }
}
