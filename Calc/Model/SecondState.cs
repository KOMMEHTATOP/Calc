using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calc.Model
{
    public class SecondState :IState
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
            
            calculatorModel.SetDialText(calculatorModel.DialText + buttonContent);
        }

        public void OnOperClicked(string buttonContent, CalculatorModel calculatorModel)
        {
            calculatorModel.state = State.Opers;
            calculatorModel.SetSecondNumber(decimal.Parse(calculatorModel.DialText)); 
            calculatorModel.Calculate(); 

            calculatorModel.MathOperator = buttonContent;
            calculatorModel.SetFirstNumber(calculatorModel.Result);
        }

        public void OnResultClicked(CalculatorModel calculatorModel)
        {
            calculatorModel.state = State.Result;
            calculatorModel.SetSecondNumber(decimal.Parse(calculatorModel.DialText));
            calculatorModel.Calculate();
        }
    }
}
