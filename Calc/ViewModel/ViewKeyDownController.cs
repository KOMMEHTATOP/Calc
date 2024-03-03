using Calc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calc.ViewModel
{
    public class ViewKeyDownController
    {
        private MainWindow _mainWindow;
        private CalculatorModel _calculatorModel;

        public ViewKeyDownController(MainWindow mainWindow, CalculatorModel calculatorModel)
        {
            _mainWindow = mainWindow;
            _calculatorModel = calculatorModel;
        }

        //private void CheckKeyNumber(Key key, string num)
        //{
        //    if (_calculatorModel.DialText == "0" && _calculatorModel.CanBeRefreshed)
        //    {
        //        _calculatorModel.SetDialText(string.Empty);
        //        _calculatorModel.CanBeRefreshed = false;
        //    }
        //    if (key == Key.Decimal && _calculatorModel.DialText.Contains(","))
        //    {
        //        return;
        //    }

        //    _calculatorModel.SetDialText(_calculatorModel.DialText + num);
        //}

        private void _mainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                    _calculatorModel.TrySetNumber("0");
                    break;
                case Key.NumPad1:
                    _calculatorModel.TrySetNumber("1");
                    break;
                case Key.NumPad2:
                    _calculatorModel.TrySetNumber("2");
                    break;
                case Key.NumPad3:
                    _calculatorModel.TrySetNumber("3");
                    break;
                case Key.NumPad4:
                    _calculatorModel.TrySetNumber("4");
                    break;
                case Key.NumPad5:
                    _calculatorModel.TrySetNumber("5");
                    break;
                case Key.NumPad6:
                    _calculatorModel.TrySetNumber("6");
                    break;
                case Key.NumPad7:
                    _calculatorModel.TrySetNumber("7");
                    break;
                case Key.NumPad8:
                    _calculatorModel.TrySetNumber("8");
                    break;
                case Key.NumPad9:
                    _calculatorModel.TrySetNumber("9");
                    break;
                case Key.Decimal:
                    _calculatorModel.TrySetNumber(",");
                    break;
                case Key.Add:
                    _calculatorModel.TryOperator("+");
                    break;
                case Key.Subtract:
                    _calculatorModel.TryOperator("-");
                    break;
                case Key.Enter:
                    _calculatorModel.TryResult();
                    break;
                default:
                    break;
            }
        }

        public void Subscribe()
        {
            _mainWindow.PreviewKeyDown += _mainWindow_PreviewKeyDown;
        }
    }
}
