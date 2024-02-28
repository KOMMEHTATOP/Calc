using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calc.Model
{
    public class CalculatorModel
    {
        public State state = State.First;
        public double firstNumber;
        public double secondNumber;
        public string mathOperator;
        public double result;
        public bool canBeRefreshed = true;
        public bool isHistoryVisible = false;
        public List<HistoryItem> historyItems = new List<HistoryItem>();

        public FirstState firstState = new FirstState();
        public SecondState secondState = new SecondState();
        public OpersState opersState = new OpersState();
        public ResultState resultState = new ResultState();

        public void Calculate(MainWindow mainWindow)
        {
            if (mathOperator == "+")
            {
                result = Math.Round(firstNumber + secondNumber, 2);
            }
            else if (mathOperator == "-")
            {
                result = Math.Round(firstNumber - secondNumber, 2);
            }

            mainWindow.Dial.Text = result.ToString();
            mainWindow.LastOperation.Text = firstNumber + mathOperator + secondNumber + "=";
            historyItems.Add(new HistoryItem(mainWindow.LastOperation.Text, result.ToString()));
            foreach (var item in historyItems)
            {
                mainWindow.HistoryList.Items.Add(item);
            }
        }

        public void CheckZeroAndDot(string buttonContent, MainWindow mainWindow)
        {
            if (buttonContent == "0" && mainWindow.Dial.Text == "0")
            {
                return;
            }

            if (buttonContent == "," && mainWindow.Dial.Text.Contains(","))
            {
                return;
            }
        }

    }
}
