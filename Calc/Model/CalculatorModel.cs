﻿using System;
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
    public delegate void SecondNumberChanged(double secondNumber);
    public delegate void RefreshChanged();


    public class CalculatorModel
    {
        public State state { get; set; } = State.First;
        public string DialText { get; private set; } = "0";
        public string LastOperation { get; private set; }
        public double FirstNumber { get; private set; }
        public double SecondNumber { get; private set; }
        public string MathOperator;
        public double Result;
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
        public event RefreshChanged RefreshChanged;

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

        public void SetSecondNumber(double secondNumber)
        {
            SecondNumber = secondNumber;
            SecondNumberChanged?.Invoke(secondNumber);
        }

        public void SetFirstNumber(double firstNumber)
        {
            FirstNumber = firstNumber;
            FirstNumberChanged?.Invoke(firstNumber);
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
            else if (MathOperator == "*")
            {
                Result = Math.Round(FirstNumber * SecondNumber, 2);
            }
            else if (MathOperator == "/")
            {
                Result = Math.Round(FirstNumber / SecondNumber, 2);
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
            if (state == State.First)
            {
                firstState.OnNumberClicked(num, this);
            }
            else if (state == State.Opers)
            {
                opersState.OnNumberClicked(num, this);
            }
            else if (state == State.Second)
            {
                secondState.OnNumberClicked(num, this);
            }
            else
            {
                resultState.OnNumberClicked(num, this);
            }
        }

        public void TryOperator(string oper)
        {
            CanBeRefreshed = true;
            if (state == State.First)
            {
                firstState.OnOperClicked(oper, this);
            }
            else if (state == State.Opers)
            {
                opersState.OnOperClicked(oper, this);
            }
            else if (state == State.Second)
            {
                secondState.OnOperClicked(oper, this);
            }
            else
            {
                resultState.OnOperClicked(oper, this);
            }
        }

        public void TryResult()
        {
            if (state == State.First)
            {
                firstState.OnResultClicked(this);
            }
            else if (state == State.Opers)
            {
                opersState.OnResultClicked(this);
            }
            else if (state == State.Second)
            {
                secondState.OnResultClicked(this);
            }
            else
            {
                resultState.OnResultClicked(this);
            }
        }

    }
}
