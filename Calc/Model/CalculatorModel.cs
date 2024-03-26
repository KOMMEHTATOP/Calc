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
    public delegate void FirstNumberChanged(decimal firstNumber);
    public delegate void SecondNumberChanged(decimal secondNumber);

    public class CalculatorModel
    {
        public State state { get; set; } = State.First;
        public string DialText { get; private set; } = "0";
        public string LastOperation { get; private set; }
        public decimal FirstNumber { get; private set; }
        public decimal SecondNumber { get; private set; }
        public string MathOperator;
        public decimal Result;
        public bool CanBeRefreshed = true;
        public bool IsHistoryVisible = false;
        public List<HistoryItem> historyItems = new List<HistoryItem>();
        public FirstState firstState = new FirstState();
        public SecondState secondState = new SecondState();
        public OpersState opersState = new OpersState();
        public ResultState resultState = new ResultState();

        public event DialTextChanged DialTextChanged;
        public event LastOpTextChanged LastOpTextChanged;
        public event HistoryViewChanged HistoryViewChanged;
        public event FirstNumberChanged FirstNumberChanged;
        public event SecondNumberChanged SecondNumberChanged;

        public Dictionary<State, IState> stateDic = new Dictionary<State, IState>();

        public CalculatorModel()
        {
            stateDic[State.First] = new FirstState();
            stateDic[State.Second] = new SecondState();
            stateDic[State.Opers] = new OpersState();
            stateDic[State.Result] = new ResultState();
        }

        public void RefreshOn()
        {
            state = State.First;
            Result = 0;
            SetDialText(Result.ToString());
            SetFirstNumber(0);
            SetSecondNumber(0);
            SetLastOperation(string.Empty);
            CanBeRefreshed = true;
            MathOperator = string.Empty;
            //MessageBox.Show($"State {state} Result {Result} FirstNum {FirstNumber} Second {SecondNumber} MathOper {MathOperator}");
        }

        public void SetDialText(string text)
        {
            DialText = text;
            DialTextChanged?.Invoke(text);
        }

        public void SetLastOperation(string text)
        {
            LastOperation = text;
            LastOpTextChanged?.Invoke(text);
        }

        public void SetSecondNumber(decimal secondNumber)
        {
            SecondNumber = secondNumber;
            SecondNumberChanged?.Invoke(secondNumber);
        }

        public void SetFirstNumber(decimal firstNumber)
        {
            FirstNumber = firstNumber;
            FirstNumberChanged?.Invoke(firstNumber);
        }

        public void Calculate()
        {
            //вот это не покрыл тестом
            if (MathOperator == "1/x")
            {
                SetFirstNumber(decimal.Parse(DialText));
                Result = 1m / FirstNumber;
                SetLastOperation($"1 / ({FirstNumber})");
                SetDialText(Result.ToString());
                state = State.Result;
                return;
            }
            //вот это не покрыл тестом
            if (MathOperator == "x2")
            {
                SetFirstNumber(decimal.Parse(DialText));
                Result = FirstNumber * FirstNumber;
                SetLastOperation($"sqr({FirstNumber})");
                SetDialText(Result.ToString());
                state = State.Result;
                return;
            }
            //вот это не покрыл тестом
            if (MathOperator == "²√ₓ")
            {
                SetFirstNumber(decimal.Parse(DialText));
                Result = (decimal)Math.Sqrt((double)FirstNumber);
                SetLastOperation($"²√({FirstNumber})");
                SetDialText(Result.ToString());
                state = State.Result;
                return;
            }


            else if (MathOperator == "+")
            {
                Result = FirstNumber + SecondNumber;
            }
            else if (MathOperator == "-")
            {
                Result = FirstNumber - SecondNumber;
            }
            else if (MathOperator == "*")
            {
                Result = FirstNumber * SecondNumber;
            }
            else if (MathOperator == "/")
            {
                Result = FirstNumber / SecondNumber;
            }

            SetDialText(Result.ToString());
            LastOperation = FirstNumber + MathOperator + SecondNumber + "=";
            LastOpTextChanged?.Invoke(LastOperation);

            HistoryItem historyItem = new HistoryItem(LastOperation, Result.ToString());
            historyItems.Add(new HistoryItem(LastOperation, Result.ToString()));
            HistoryViewChanged?.Invoke(historyItem);
        }

        public void TrySetNumber(string num)
        {
            IState currentState = stateDic[state];
            currentState.OnNumberClicked(num, this);
        }

        public void TryOperator(string oper)
        {
            CanBeRefreshed = true;
            IState currentState = stateDic[state];
            currentState.OnOperClicked(oper, this);
        }

        public void TryResult()
        {
            IState currentState = stateDic[state];
            currentState.OnResultClicked(this);
        }
    }
}
