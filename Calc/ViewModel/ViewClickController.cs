using Calc.Model;
using NUnit.Framework.Constraints;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace Calc.ViewModel
{
    public class ViewClickController
    {
        private MainWindow _mainWindow;
        private CalculatorModel _calculatorModel;
        public ViewClickController(MainWindow mainWindow, CalculatorModel calculatorModel)
        {
            _mainWindow = mainWindow;
            _calculatorModel = calculatorModel;
        }

        public void Subscribe()
        {
            foreach (var item in _mainWindow.OnlyNumbers.Children)
            {
                if (item is Button button)
                {
                    button.Focusable = false;
                    button.Click += Number_Click;
                }
            }
            _mainWindow.Plus.Click += Oper_Click;
            _mainWindow.Plus.Focusable = false;
            _mainWindow.Minus.Click += Oper_Click;
            _mainWindow.Minus.Focusable = false;
            _mainWindow.Multiply.Click += Oper_Click;
            _mainWindow.Multiply.Focusable = false;
            _mainWindow.Divide.Click += Oper_Click;
            _mainWindow.Divide.Focusable = false;
            _mainWindow.DivideOne.Click += Oper_Click;
            _mainWindow.DivideOne.Focusable = false;
            _mainWindow.Sqr.Click += Oper_Click;
            _mainWindow.Sqr.Focusable = false;
            _mainWindow.KorenDva.Click += Oper_Click;
            _mainWindow.KorenDva.Focusable = false;
            _mainWindow.Result.Click += Result_Click;
            _mainWindow.Result.Focusable = false;
            _mainWindow.RefreshAll.Click += Refresh_Click;
            _mainWindow.RefreshAll.Focusable = false;
            _mainWindow.Delete.Click += Delete_Click;
            _mainWindow.Delete.Focusable = false;
            _mainWindow.History.Click += History_Click;
            _mainWindow.History.Focusable = false;
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
            _calculatorModel.RefreshOn();
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
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var oldState = _calculatorModel.state;
            Button button = sender as Button;
            string buttonContent = button.Content.ToString();

            _calculatorModel.TrySetNumber(buttonContent);
            _mainWindow.Log(oldState, "Number_Click");
        }
    }
}


