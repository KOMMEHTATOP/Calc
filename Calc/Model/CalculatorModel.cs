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
    public delegate void FirstNumberChanged(double firstNumber);

    public class CalculatorModel
    {
        public State state = State.First;
        public double FirstNumber { get; private set; }
        public double SecondNumber;
        public string MathOperator;
        public double Result;
        public bool CanBeRefreshed = true;
        public bool IsHistoryVisible = false;
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
        public event HistoryViewChanged HistoryViewChanged;
        public event FirstNumberChanged FirstNumberChanged;

        public void SetDialText(string text)
        {
            DialText = text;
            DialTextChanged.Invoke(text);
        }

        public void SetLastOperation(string text)
        {
            LastOperation = text;
            LastOpTextChanged.Invoke(text);
        }

        public void SetFirstNumber(double firstNumber)
        {
            FirstNumber = firstNumber;
            FirstNumberChanged.Invoke(firstNumber);
        }

        public void Calculate()
        {
            if (MathOperator == "+")
            {
                Result = Math.Round(FirstNumber + SecondNumber, 2);
            }
            else if (MathOperator == "-")
            {
                Result = Math.Round(FirstNumber - SecondNumber, 2);
            }

            SetDialText(Result.ToString());

            LastOperation = FirstNumber + MathOperator + SecondNumber + "=";
            LastOpTextChanged?.Invoke(LastOperation);

            HistoryItem historyItem = new HistoryItem(LastOperation, Result.ToString());
            historyItems.Add(new HistoryItem(LastOperation, Result.ToString()));
            HistoryViewChanged?.Invoke(historyItem);
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
