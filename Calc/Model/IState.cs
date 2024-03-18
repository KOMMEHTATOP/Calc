using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Model
{
    public interface IState
    {
        public void OnNumberClicked(string buttonContent, CalculatorModel calculatorModel);
        public void OnOperClicked(string buttonContent, CalculatorModel calculatorModel);
        public void OnResultClicked(CalculatorModel calculatorModel);
    }
}
