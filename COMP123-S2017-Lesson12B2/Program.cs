using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 Name: Lyrica Yoshida
 ID: 300923951
 Date: August 8, 2017
 Description: Calculator Demo Project
 Version: 0.3 - Created an instance of the calculatorForm object
     */

namespace COMP123_S2017_Lesson12B2
{
    public static class Program
    {
        // Create Reference to Forms
        public static CalculatorForm calculatorForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            calculatorForm = new CalculatorForm(); 
            // instantiate a new object of type CalculatorForm

            Application.Run(new SplashForm());
        }
    }
}
