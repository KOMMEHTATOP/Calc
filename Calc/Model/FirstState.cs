using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Model
{
    public class FirstState : IState
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
                calculatorModel.SetDialText(string.Empty);
            }

            calculatorModel.SetDialText(calculatorModel.DialText + buttonContent);
            calculatorModel.CanBeRefreshed = false;
        }
        public void OnOperClicked(string buttonContent, CalculatorModel calculatorModel)
        {
            if (buttonContent == "1/x")
            {
                calculatorModel.MathOperator = "1/x";
                calculatorModel.Calculate();
                return;
            }
            if (buttonContent == "x2")
            {
                calculatorModel.MathOperator = "x2";
                calculatorModel.Calculate();
                return;
            }
            if (buttonContent == "²√ₓ")
            {
                calculatorModel.MathOperator = "²√ₓ";
                calculatorModel.Calculate();
                return;
            }


            calculatorModel.state = State.Opers;
            calculatorModel.MathOperator = buttonContent;
            calculatorModel.SetFirstNumber(decimal.Parse(calculatorModel.DialText));
            string v = calculatorModel.FirstNumber + calculatorModel.MathOperator;
            calculatorModel.SetLastOperation(v);
            calculatorModel.SetDialText(calculatorModel.FirstNumber.ToString());
        }
        public void OnResultClicked(CalculatorModel calculatorModel)
        {
            
        }
    }
}
