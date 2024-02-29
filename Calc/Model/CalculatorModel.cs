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
    public delegate void DialTextChanged(string text);
    public delegate void LastOpTextChanged(string text);
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

        //сделать недостающие поля
        //сделать ивент и при изменении модели менять вью

        public string DialText;
        public string LastOperation;

        public event DialTextChanged DialTextChanged;
        public event LastOpTextChanged LastOpTextChanged;

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

            DialText = result.ToString();
            DialTextChanged?.Invoke(DialText);

            LastOperation = firstNumber + mathOperator + secondNumber + "=";
            LastOpTextChanged?.Invoke(LastOperation);

            //mainWindow.LastOperation.Text = firstNumber + mathOperator + secondNumber + "=";
            HistoryItem historyItem = new HistoryItem(mainWindow.LastOperation.Text, result.ToString());
            historyItems.Add(new HistoryItem(mainWindow.LastOperation.Text, result.ToString()));
            mainWindow.HistoryListView.Items.Add(historyItem);
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
