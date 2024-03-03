﻿using Calc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Calc.ViewModel
{
    public class ModelUpdateController 
    {
        private MainWindow _mainWindow;
        private CalculatorModel _calculatorModel;

        public ModelUpdateController(MainWindow mainWindow, CalculatorModel calculatorModel)
        {
            _mainWindow = mainWindow;
            _calculatorModel = calculatorModel;
        }

        public void Subscribe()
        {
            _calculatorModel.DialTextChanged += OnDialTextChanged;
            _calculatorModel.LastOpTextChanged += OnLastOperationChanged;
            _calculatorModel.HistoryViewChanged += OnHistoryViewChanged;
            _calculatorModel.FirstNumberChanged += OnFirstNumberChanged;
            _calculatorModel.SecondNumberChanged += OnSecondNumberChanged;
            _mainWindow.Plus.Click += Oper_Click;
            _mainWindow.Minus.Click += Oper_Click;
            _mainWindow.Multiply.Click += Oper_Click;
            _mainWindow.Divide.Click += Oper_Click;
            _mainWindow.Result.Click += Result_Click;
            _mainWindow.RefreshAll.Click += Refresh_Click;
            _mainWindow.Delete.Click += Delete_Click;
            _mainWindow.History.Click += History_Click;
        }

        private void OnSecondNumberChanged(double secondNumber)
        {

        }

        private void OnFirstNumberChanged(double firstNumber)
        {

        }

        private void OnHistoryViewChanged(HistoryItem historyItem)
        {
            _mainWindow.HistoryListView.Items.Add(historyItem);
        }

        private void OnDialTextChanged(string text)
        {
            _mainWindow.Dial.Text = text;
        }

        private void OnLastOperationChanged(string text)
        {
            _mainWindow.LastOperation.Text = text;
        }

        private void Oper_Click(object sender, RoutedEventArgs e)
        {
            var oldState = _calculatorModel.state;
            Button button = sender as Button;
            string buttonContent = button.Content.ToString();

            _calculatorModel.TryOperator(buttonContent);
            _mainWindow.Log(oldState, "Oper_Click");
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            var oldState = _calculatorModel.state;
            _calculatorModel.TryResult();
            _mainWindow.Log(oldState, "Result_Click");
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            _calculatorModel.state = State.First;
            _calculatorModel.Result = 0;
            _calculatorModel.SetDialText(_calculatorModel.Result.ToString());
            _calculatorModel.SetFirstNumber(0);
            _calculatorModel.SetSecondNumber(0);
            _calculatorModel.SetLastOperation(string.Empty);
            _calculatorModel.CanBeRefreshed = true;
            _calculatorModel.MathOperator = string.Empty;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (_calculatorModel.DialText.Length > 0)
            {
                string v = _calculatorModel.DialText.Remove(_calculatorModel.DialText.Length - 1);
                _calculatorModel.SetDialText(v);
            }
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            if (_calculatorModel.IsHistoryVisible)
            {
                _mainWindow.HistoryListView.Visibility = Visibility.Collapsed;
                _calculatorModel.IsHistoryVisible = false;
            }
            else
            {
                _mainWindow.HistoryListView.Visibility = Visibility.Visible;
                _calculatorModel.IsHistoryVisible = true;
            }
        }
    }
}