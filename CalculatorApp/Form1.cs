using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string operand1 = "";
        string operand2 = "";
        bool newCalculation = false;
        private void number_Click(object sender, EventArgs e)
        {
            if(newCalculation)
            {
                label1.Text = "";
                newCalculation = false;
            }
            var button = sender as Button;
            label1.Text += button.Text;
        }

        string computeOperator;
        private void operator_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (newCalculation)
            {
                operand1 = label1.Text;
                label1.Text = "";
                newCalculation = false;
            }

            if (string.IsNullOrEmpty(operand1))
                operand1 = label1.Text;
            else
                operand2 = label1.Text;

            if(!string.IsNullOrEmpty(computeOperator) && !string.IsNullOrEmpty(label1.Text))
            {
                label1.Text = ComputeResult(operand1, operand2, computeOperator);
                operand1 = label1.Text;
                operand2 = "";
                computeOperator = "";
                computeOperator = button.Text;
                newCalculation = true;
                return;
            }

            label1.Text = "";

            computeOperator = button.Text;
        }

        private void equal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(operand1) 
                || string.IsNullOrEmpty(computeOperator))
                return;

            operand2 = label1.Text;
            label1.Text = ComputeResult(operand1, operand2, computeOperator);
            operand1 = "";
            operand2 = "";
            computeOperator = "";
            newCalculation = true;
        }

        private string ComputeResult(string one, string two, string computeOperator)
        {
            double oneValue = double.Parse(one);
            double twoValue = double.Parse(two);

            switch(computeOperator)
            {
                case "+":
                    return (oneValue + twoValue).ToString();
                case "-":
                    return (oneValue + twoValue).ToString();
                case "x":
                    return (oneValue * twoValue).ToString();
                case "/":
                    return (oneValue / twoValue).ToString();
                default:
                    throw new NotSupportedException("Operator not supported.");
            }
        }
        private void clear_Click(object sender, EventArgs e)
        {
            operand1 = "";
            operand2 = "";
            computeOperator = "";
            label1.Text = "";
        }

    }
}
