using Calc.Model;
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
        }

        private void OnSecondNumberChanged(decimal secondNumber)
        {

        }

        private void OnFirstNumberChanged(decimal firstNumber)
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

    }
}
