﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VC_Project_4_1
{
    /*************************************************************************
     * This is a simple program that takes user inputs of lenth and, of a
     * square or rectangle, and calculates the area and perimeter of the 
     * shape.  And that's it.  It doesn't not do any data validation, so 
     * the user must enter numeric values.  It is only slightly easier
     * than doing the math with pen and paper, and depending on your
     * computer's load times and your personal math skillz, it may take
     * even more time.
     * 
     * Produced by Joseph Larson
     *************************************************************************/
    public partial class frmAnP : Form
    {
        public frmAnP()
        {
            InitializeComponent();
        }



        private void btnCalculate_Click(object sender, EventArgs e)
        {

            //validate form
            if (!IsValidForm())
            {
               return;
            }
            //Take in the user inputs and convert to decimal
            //Then create 2 more variables to hold the answers
            //Do some math and display in the read only textboxes
            decimal width = Convert.ToDecimal(txtWidth.Text);
            decimal length = Convert.ToDecimal(txtLength.Text);
            decimal area = CalculateArea(length, width);
            decimal perimeter = CalculatePerimeter(length, width);

            txtArea.Text = Convert.ToString(area);
            txtPerimeter.Text = Convert.ToString(perimeter);
            txtLength.Focus();

            //the last line brings the focus back to the first box in
            //case the user wants to have some more fun

        }

        //method for area
        public decimal CalculateArea(decimal length, decimal width)
        {
            decimal area = length * width;
            return area;
        }
        //method for perimeter
        public decimal CalculatePerimeter(decimal length, decimal width)
        {
            decimal perimeter = (2 * length) + (2 * width);
            return perimeter;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Event handler for the exit button
            this.Close();
        }
        //data type validation
        public bool IsDecimal(TextBox textbox, string name)
        {
            decimal number = 0;
            if (decimal.TryParse(textbox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a number.", "Entry Error");
                textbox.Clear();
                textbox.Focus();
                return false;
            }

        }
        //presence validation
        public bool IsPresent(TextBox textbox, string name)
        {
            if (textbox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textbox.Focus();
                return false;
            }
            else 
            {
                return true;
            }

        }
        //Form validation
        public bool IsValidForm()
        {
            return
                IsPresent(txtLength, "Length") && IsDecimal(txtLength, "Length") 
                && IsPresent(txtWidth, "Width") && IsDecimal(txtWidth, "Width");
        }
    }
}
