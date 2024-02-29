using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Model
{
    public class FirstState
    {
        public void OnNumberClicked(string buttonContent, MainWindow mainWindow)
        {
            if (buttonContent == "0" && mainWindow.Dial.Text == "0")
            {
                return;
            }

            if (buttonContent == "," && mainWindow.Dial.Text.Contains(","))
            {
                return;
            }

            if (mainWindow.calculatorModel.canBeRefreshed && !buttonContent.EndsWith(","))
            {
                mainWindow.Dial.Text = string.Empty;
            }

            mainWindow.Dial.Text += buttonContent;
            mainWindow.calculatorModel.canBeRefreshed = false;  
        }
        public void OnOperClicked(string buttonContent, MainWindow mainWindow)
        {
            mainWindow.calculatorModel.state = State.Opers;
            mainWindow.calculatorModel.mathOperator = buttonContent;
            mainWindow.calculatorModel.firstNumber = double.Parse(mainWindow.Dial.Text);
            mainWindow.LastOperation.Text = mainWindow.calculatorModel.firstNumber + mainWindow.calculatorModel.mathOperator;
        }
        public void OnResultClicked(string buttonContent, MainWindow mainWindow)
        {
           
        }
    }
}
