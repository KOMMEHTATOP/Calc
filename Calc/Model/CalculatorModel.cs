using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calc.Model
{
    public delegate void DialTextChanged(string text);
    public delegate void LastOpTextChanged(string text);
    public delegate void HistoryViewChanged(HistoryItem historyItem);
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
        public ListBox ListBoxHistory;

        public event DialTextChanged DialTextChanged;
        public event LastOpTextChanged LastOpTextChanged;
        public event HistoryViewChanged HistoryViewChanged;

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

            HistoryItem historyItem = new HistoryItem(LastOperation, result.ToString());
            historyItems.Add(new HistoryItem(LastOperation, result.ToString()));
            HistoryViewChanged?.Invoke(historyItem);
            
            //mainWindow.LastOperation.Text = firstNumber + mathOperator + secondNumber + "=";
            //mainWindow.HistoryListView.Items.Add(historyItem);
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
