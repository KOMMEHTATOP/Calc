using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calc.Model
{
    public class SecondState
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

            mainWindow.Dial.Text += buttonContent;
        }

        public void OnOperClicked(string buttonContent, MainWindow mainWindow)
        {
            mainWindow.calculatorModel.state = State.Opers;
            mainWindow.calculatorModel.secondNumber = double.Parse(mainWindow.Dial.Text);
            mainWindow.calculatorModel.Calculate(mainWindow);

            mainWindow.calculatorModel.mathOperator = buttonContent;
            mainWindow.calculatorModel.firstNumber = mainWindow.calculatorModel.result;

        }

        public void OnResultClicked(string buttonContent, MainWindow mainWindow)
        {
            mainWindow.calculatorModel.state = State.Result;
            mainWindow.calculatorModel.secondNumber = double.Parse(mainWindow.Dial.Text);
            mainWindow.calculatorModel.Calculate(mainWindow);
        }
    }
}
