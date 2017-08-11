using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 Name: Lyrica Yoshida
 ID: 300923951
 Date: August 10, 2017
 Description: Calculator Demo Project
 Version: 0.8 - Added the _calculate and _convertOperand methods
     */

namespace COMP123_S2017_Lesson12B2
{
    public partial class CalculatorForm : Form
    {
        // PRIVATE INSTANCE VARIABLES
        private bool _isDecimalClicked;

        private string _currentOperator;

        private List<double> _operandList;

        // PUBLIC PROPERTIES
        public bool IsDecimalClicked
        {
            get
            {
                return this._isDecimalClicked;
            }
            set
            {
                this._isDecimalClicked = value;
            }
        } 

        public string CurrentOperator
        {
            get
            {
                return this._currentOperator;
            }
            set
            {
                this._currentOperator = value;
            }
        }

        public List<double> OperandList
        {
            get
            {
                return this._operandList;
            }
            set
            {
                this._operandList = value;
            }
        }

        // CONSTRUCTORS

        /// <summary>
        /// This is the main constructor for the CalculatorForm class
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is an event handler for the "FormClosing" event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This is the shared event handler for the Calculator Buttons
        /// Not including the Operator Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            Button calculatorButton = sender as Button; // downcasting

            if ((this.IsDecimalClicked) && (calculatorButton.Text == "."))
            {
                return;
            }

            if(calculatorButton.Text == ".")
            {
                this.IsDecimalClicked = true;    
            }

            if((ResultTextBox.Text == "0") && (calculatorButton.Text != "."))
            {
                ResultTextBox.Text = calculatorButton.Text;
            }
            else
            {
                ResultTextBox.Text += calculatorButton.Text;
            }


            //Debug.WriteLine("A Calculator Button was clicked");
        }


        /// <summary>
        /// This is a shared event handler for the Operator Buttons of the calculator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button operatorButton = sender as Button; // downcasting

            switch(operatorButton.Text)
            {
                case "C":
                    this._clear();
                    break;
                case "=":
                    break;
                case "←":
                    break;
                case "±":
                    break;
                default:
                    this._calculate(ResultTextBox.Text, operatorButton.Text);
                    break;
            }
        }
        
        /// <summary>
        /// This method calculates the result of all the operands in the OperandList
        /// </summary>
        /// <param name=""></param>
        private void _calculate(string operandString, string operatorString)
        {
            double operand = this._convertOperand(operandString);
        }

        /// <summary>
        /// This method converts the string from the ResultTextBox to a number
        /// </summary>
        /// <param name="operandString"></param>
        /// <returns></returns>
        private double _convertOperand(string operandString)
        {
            try
            {
                return Convert.ToDouble(operandString);
            }
            catch(Exception exception)
            {
                Debug.WriteLine("An error occurred");
                Debug.WriteLine(exception.Message);
            }
            return 0;
        }

        /// <summary>
        /// This is the private _clear method
        /// It clears / resets the calculator
        /// </summary>
        private void _clear()
        {
            this.IsDecimalClicked = false;
            ResultTextBox.Text = "0";
            this.OperandList = new List<double>();
            this.CurrentOperator = "C";
        }

        /// <summary>
        /// This is the event handler for the "Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            this._clear();
        }
    }
}
