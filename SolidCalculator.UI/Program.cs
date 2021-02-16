using System;
using System.Windows.Forms;
using SolidCalculator.Core;

namespace SolidCalculator.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServicesConfig.Initialize(); // create instance

            IArithmeticOperationsRepo operationsRepo = ServicesConfig.OperationsRepo;

            //inject dependency
            Application.Run(new Calculator(operationsRepo));
        }
    }
}