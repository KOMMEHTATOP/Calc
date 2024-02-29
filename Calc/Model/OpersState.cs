using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Model
{
    public class OpersState
    {
        public void OnNumberClicked(string buttonContent, CalculatorModel calculatorModel)
        {
            calculatorModel.state = State.Second;
            if (calculatorModel.CanBeRefreshed)
            {
                if (buttonContent == ",")
                {
                    calculatorModel.DialText = "0,";
                }
                else
                {
                    calculatorModel.DialText = buttonContent;
                    calculatorModel.CanBeRefreshed = false;
                }
            }

            if (buttonContent == "," && calculatorModel.DialText.Contains(","))
            {
                return;
            }
        }

        public void OnOperClicked(string buttonContent, CalculatorModel calculatorModel)
        {
            if (buttonContent == "+" || buttonContent == "-")
            {
                calculatorModel.state = State.Opers;
                calculatorModel.MathOperator = buttonContent;
                string v = calculatorModel.DialText + calculatorModel.MathOperator;
                calculatorModel.SetLastOperation(v);
            }
            else
            {
                calculatorModel.state = State.Result;
                calculatorModel.MathOperator = buttonContent;
                calculatorModel.SecondNumber = double.Parse(calculatorModel.DialText);
                calculatorModel.Calculate();
                string v = calculatorModel.DialText + calculatorModel.MathOperator;
                calculatorModel.SetLastOperation(v);
            }
        }

        public void OnResultClicked(string buttonContent, CalculatorModel calculatorModel)
        {
            calculatorModel.state = State.Result;
            calculatorModel.SecondNumber = double.Parse(calculatorModel.DialText);
            calculatorModel.Calculate();
        }
    }
}
