using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Model
{
    public class FirstState
    {
        public void OnNumberClicked(string buttonContent, CalculatorModel calculatorModel)
        {
            if (buttonContent == "0" && calculatorModel.DialText == "0")
            {
                return;
            }

            if (buttonContent == "," && calculatorModel.DialText.Contains(","))
            {
                return;
            }

            if (calculatorModel.CanBeRefreshed && !buttonContent.EndsWith(","))
            {
                calculatorModel.DialText = string.Empty;
            }

            calculatorModel.SetDialText(calculatorModel.DialText + buttonContent);
            calculatorModel.CanBeRefreshed = false;
        }
        public void OnOperClicked(string buttonContent, CalculatorModel calculatorModel)
        {
            calculatorModel.state = State.Opers;
            calculatorModel.MathOperator = buttonContent;
            calculatorModel.SetFirstNumber(double.Parse(calculatorModel.DialText));
            string v = calculatorModel.FirstNumber + calculatorModel.MathOperator;
            calculatorModel.SetLastOperation(v);
            calculatorModel.SetDialText(calculatorModel.FirstNumber.ToString());
        }
        public void OnResultClicked(string buttonContent, CalculatorModel calculatorModel)
        {

        }
    }
}
