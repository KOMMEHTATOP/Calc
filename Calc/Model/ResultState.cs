using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calc.Model
{
    public class ResultState
    {
        public void OnNumberClicked(string buttonContent, MainWindow mainWindow)
        {
            if (buttonContent == "=")
            {
                mainWindow.calculatorModel.state = State.First;
                mainWindow.Dial.Text = buttonContent;
                mainWindow.LastOperation.Text = string.Empty;
            }
            else 
            {
                mainWindow.calculatorModel.state = State.Opers;
                mainWindow.Dial.Text = buttonContent;
                mainWindow.LastOperation.Text = mainWindow.calculatorModel.result + mainWindow.calculatorModel.mathOperator;
            }
        }

        public void OnOperClicked(string buttonContent, MainWindow mainWindow)
        {
            mainWindow.calculatorModel.state = State.Opers;
            mainWindow.calculatorModel.mathOperator = buttonContent;
            mainWindow.calculatorModel.canBeRefreshed = true;
            mainWindow.calculatorModel.firstNumber = double.Parse(mainWindow.Dial.Text);
            mainWindow.LastOperation.Text = mainWindow.calculatorModel.firstNumber + mainWindow.calculatorModel.mathOperator;
        }

        public void OnResultClicked(string buttonContent, MainWindow mainWindow)
        {
            mainWindow.calculatorModel.firstNumber = double.Parse(mainWindow.Dial.Text);
            mainWindow.calculatorModel.Calculate(mainWindow);
        }
    }
}
