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
 Version: 1.4 - Fixed equals and devide operator bugs
     */

namespace COMP123_S2017_Lesson12B2
{
    public partial class CalculatorForm : Form
    {
        // PRIVATE INSTANCE VARIABLES
        private bool _isDecimalClicked;

        private string _currentOperator;

        private List<double> _operandList;

        private double _result;

        private bool _isOperandTwo;

        private bool _isDevidebByZero;

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

        public double Result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }

        public bool IsOperandTwo
        {
            get
            {
                return this._isOperandTwo;
            }
            set
            {
                this._isOperandTwo = value;
            }
        }

        public bool IsDevidedByZero
        {
            get
            {
                return this._isDevidebByZero;
            }
            set
            {
                this._isDevidebByZero = value;
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
            this.IsDevidedByZero = false;

            if ((this.IsDecimalClicked) && (calculatorButton.Text == "."))
            {
                return;
            }

            if(calculatorButton.Text == ".")
            {
                this.IsDecimalClicked = true;    
            }

            if ((OperandList.Count > 0) && (this.IsOperandTwo == false))
            {
                if (calculatorButton.Text == ".")
                {
                    ResultTextBox.Text = "0.";
                }
                else
                {
                    ResultTextBox.Text = calculatorButton.Text;
                }
                this.IsOperandTwo = true;
            }
            else if ((ResultTextBox.Text == "0") && (calculatorButton.Text != "."))
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
            double operand = this._convertOperand(ResultTextBox.Text);

            switch (operatorButton.Text)
            {
                case "C":
                    this._clear();
                    break;
                case "=":
                    this._showResult(operand);
                    break;
                case "←":
                    this._deleteLastDigit();
                    break;
                case "±":
                    this._changeSign(operand);
                    break;
                default:
                    this._calculate(operand, operatorButton.Text);
                    break;
            }
        }

        private void _changeSign(double operand)
        {
            this.Result = -1 * operand;
            ResultTextBox.Text = this.Result.ToString();
        }

        /// <summary>
        /// This method deletes the last digit in the ResultTextBox
        /// </summary>
        private void _deleteLastDigit()
        {
            if(ResultTextBox.Text.Length == 1)
            {
                ResultTextBox.Text = "0";
            }
            else
            {
                if(ResultTextBox.Text.Substring(ResultTextBox.Text.Length-1,1) == ".")
                {
                    this.IsDecimalClicked = false;
                }
                ResultTextBox.Text = ResultTextBox.Text.Substring(0, ResultTextBox.Text.Length - 1);
            }
        }

        /// <summary>
        /// This method shows the Result of the last operation in the ResultTextBox
        /// </summary>
        /// <param name="operandString"></param>
        private void _showResult(double operand)
        {
            if(OperandList.Count > 0)
            {
                this._calculate(operand, this.CurrentOperator);
            }
            else
            {
                this.Result = operand;
            }
            if (IsDevidedByZero)
            {
                ResultTextBox.Text = "Cannot devide by zero";
            }
            else
            {
                ResultTextBox.Text = this.Result.ToString();
            }
            this.CurrentOperator = "=";
        }

        /// <summary>
        /// This method calculates the result of all the operands in the OperandList
        /// </summary>
        /// <param name=""></param>
        private void _calculate(double operand, string operatorString)
        {
            OperandList.Add(operand);
            this.IsDecimalClicked = false;
            if (OperandList.Count > 1)
            {
                switch(CurrentOperator)
                {
                    case "+":
                        this.Result = this.OperandList[0] + this.OperandList[1];
                        break;
                    case "-":
                        this.Result = this.OperandList[0] - this.OperandList[1];
                        break;
                    case "x":
                        this.Result = this.OperandList[0] * this.OperandList[1];
                        break;
                    case "÷":
                        if(this.OperandList[1] == 0)
                        {
                            this._clear();
                            this.IsDevidedByZero = true;
                        }
                        else
                        {
                            this.Result = this.OperandList[0] / this.OperandList[1];
                        }
                        break;
                }
                this.OperandList.Clear();
                this.OperandList.Add(this.Result);
                this.IsOperandTwo = false;
            }
            else
            {
                this.Result = operand;
            }
            if(IsDevidedByZero)
            {
                ResultTextBox.Text = "Cannot devide by zero";
            }
            else
            {
                ResultTextBox.Text = this.Result.ToString();
            }
            this.CurrentOperator = operatorString;
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
            this.IsOperandTwo = false;
            this.IsDevidedByZero = false;
            this.Result = 0;
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
