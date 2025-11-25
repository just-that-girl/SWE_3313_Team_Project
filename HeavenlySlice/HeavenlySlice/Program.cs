using System;
using System.Windows.Forms;

namespace HeavenlySlice
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the HeavenlySlice application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Launch the Order Menu form
            Application.Run(new OrderMenu());
        }
    }
}