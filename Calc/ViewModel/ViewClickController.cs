using Calc.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    button.Click += Number_Click;
                }
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
    

