using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                    calculatorModel.SetDialText("0,");
                }
                else
                {
                    calculatorModel.SetDialText(buttonContent);
                    calculatorModel.CanBeRefreshed = false;
                }
            }
            else
            {
//вот это не покрыл тестом
                calculatorModel.SetDialText(calculatorModel.DialText + buttonContent);
                calculatorModel.state = State.Opers;
                calculatorModel.CanBeRefreshed = false;
            }
        }

        public void OnOperClicked(string buttonContent, CalculatorModel calculatorModel)
        {
            if (buttonContent == "+" || buttonContent == "-")
            {
                calculatorModel.state = State.Opers;
                calculatorModel.MathOperator = buttonContent;
                calculatorModel.SetFirstNumber(decimal.Parse(calculatorModel.DialText));
                string v = calculatorModel.DialText + calculatorModel.MathOperator;
                calculatorModel.SetLastOperation(v);
            }
            else
            {
                calculatorModel.state = State.Result;
                calculatorModel.MathOperator = buttonContent;
                calculatorModel.SetSecondNumber(decimal.Parse(calculatorModel.DialText));
                calculatorModel.Calculate();
                string v = calculatorModel.DialText + calculatorModel.MathOperator;
                calculatorModel.SetLastOperation(v);
            }
        }

        public void OnResultClicked(CalculatorModel calculatorModel)
        {
            calculatorModel.state = State.Result;
            calculatorModel.SetSecondNumber(decimal.Parse(calculatorModel.DialText)); 
            calculatorModel.Calculate();
        }
    }
}
