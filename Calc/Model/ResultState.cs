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
        public void OnNumberClicked(string buttonContent, CalculatorModel calculatorModel)
        {
            if (buttonContent == "=")
            {
                calculatorModel.state = State.First;
                calculatorModel.SetDialText(buttonContent);
                calculatorModel.SetLastOperation(string.Empty);
            }
            else 
            {
                calculatorModel.state = State.Opers;
                calculatorModel.SetDialText(buttonContent);
                string v = calculatorModel.Result + calculatorModel.MathOperator;
                calculatorModel.SetLastOperation(v);
            }
            
        }

        public void OnOperClicked(string buttonContent, CalculatorModel calculatorModel)
        {
            calculatorModel.state = State.Opers;
            calculatorModel.MathOperator = buttonContent;
            calculatorModel.CanBeRefreshed = true;
            calculatorModel.SetFirstNumber(double.Parse(calculatorModel.DialText));
            string v = calculatorModel.FirstNumber + calculatorModel.MathOperator;
            calculatorModel.SetLastOperation(v);
        }

        public void OnResultClicked(string buttonContent, CalculatorModel calculatorModel)
        {
            calculatorModel.SetFirstNumber(double.Parse(calculatorModel.DialText));
            calculatorModel.Calculate();
        }
    }
}
