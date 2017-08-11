﻿using System;
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
 Version: 0.7 - Added the conditions for when 0 is already there
     */

namespace COMP123_S2017_Lesson12B2
{
    public partial class CalculatorForm : Form
    {
        // PRIVATE INSTANCE VARIABLES
        private bool _isDecimalClicked;

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
            }
        }

        /// <summary>
        /// This is the private _clear method
        /// It clears / resets the calculator
        /// </summary>
        private void _clear()
        {
            this.IsDecimalClicked = false;
            ResultTextBox.Text = "0";
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
