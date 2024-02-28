using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Model
{
    public class OpersState
    {
        public void OnNumberClicked(string buttonContent, MainWindow mainWindow)
        {
            mainWindow.calculatorModel.state = State.Second;
            if (mainWindow.calculatorModel.canBeRefreshed)
            {
                if (buttonContent == ",")
                {
                    mainWindow.Dial.Text = "0,";
                }
                else
                {
                    mainWindow.Dial.Text = buttonContent;
                    mainWindow.calculatorModel.canBeRefreshed = false;
                }
            }

            if (buttonContent == "," && mainWindow.Dial.Text.Contains(","))
            {
                return;
            }

        }

        public void OnOperClicked(string buttonContent, MainWindow mainWindow)
        {
            if (buttonContent == "+" || buttonContent == "-")
            {
                mainWindow.calculatorModel.state = State.Opers;
                mainWindow.calculatorModel.mathOperator = buttonContent;
                mainWindow.LastOperation.Text = mainWindow.Dial.Text + mainWindow.calculatorModel.mathOperator;
            }
            else
            {
                mainWindow.calculatorModel.state = State.Result;
                mainWindow.calculatorModel.mathOperator = buttonContent;
                mainWindow.calculatorModel.secondNumber = double.Parse(mainWindow.Dial.Text);
                mainWindow.calculatorModel.Calculate(mainWindow);
                mainWindow.LastOperation.Text = mainWindow.Dial.Text + mainWindow.calculatorModel.mathOperator;

            }
        }

        public void OnResultClicked(string buttonContent, MainWindow mainWindow)
        {
            mainWindow.calculatorModel.state = State.Result;
            mainWindow.calculatorModel.secondNumber = double.Parse(mainWindow.Dial.Text);
            mainWindow.calculatorModel.Calculate(mainWindow);
        }
    }
}
