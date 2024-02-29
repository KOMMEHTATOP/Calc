using Calc.Model;
using Calc.ViewModel;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc
{
    public partial class MainWindow : Window
    {
        public CalculatorModel calculatorModel;

        public MainWindow()
        {
            InitializeComponent();
            calculatorModel = new CalculatorModel();
            Loaded += MainWindow_Loaded;
            Dial.Text = calculatorModel.result.ToString();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in OnlyNumbers.Children)
            {
                if (item is Button button)
                {
                    button.Click += Number_Click;
                }
            }
            calculatorModel.DialTextChanged += OnDialTextChanged;
            calculatorModel.LastOpTextChanged += OnLastOperationChanged;
        }

        private void OnDialTextChanged(string text)
        {
            Dial.Text = text;
        }

        private void OnLastOperationChanged(string text)
        {
            LastOperation.Text = text;
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var oldState = calculatorModel.state;
            Button button = sender as Button;
            string buttonContent = button.Content.ToString();

            if (calculatorModel.state == State.First)
            {
                calculatorModel.firstState.OnNumberClicked(buttonContent, this);
            }
            else if (calculatorModel.state == State.Opers)
            {
                calculatorModel.opersState.OnNumberClicked(buttonContent, this);
            }
            else if (calculatorModel.state == State.Second)
            {
                calculatorModel.secondState.OnNumberClicked(buttonContent, this);
            }
            else
            {
                calculatorModel.resultState.OnNumberClicked(buttonContent, this);
            }
            Log(oldState, "Number_Click");
        }

        private void Oper_Click(object sender, RoutedEventArgs e)
        {
            calculatorModel.canBeRefreshed = true;

            var oldState = calculatorModel.state;
            Button button = sender as Button;
            string buttonContent = button.Content.ToString();

            if (calculatorModel.state == State.First)
            {
                calculatorModel.firstState.OnOperClicked(buttonContent, this);
            }
            else if (calculatorModel.state == State.Opers)
            {
                calculatorModel.opersState.OnOperClicked(buttonContent, this);
            }
            else if (calculatorModel.state == State.Second)
            {
                calculatorModel.secondState.OnOperClicked(buttonContent, this);
            }
            else
            {
                calculatorModel.resultState.OnOperClicked(buttonContent, this);
            }
            Log(oldState, "Oper_Click");
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            var oldState = calculatorModel.state;
            Button button = sender as Button;
            string buttonContent = button.Content.ToString();
            if (calculatorModel.state == State.First)
            {
                calculatorModel.firstState.OnResultClicked(buttonContent, this);
            }
            else if (calculatorModel.state == State.Opers)
            {
                calculatorModel.opersState.OnResultClicked(buttonContent, this);
            }
            else if (calculatorModel.state == State.Second)
            {
                calculatorModel.secondState.OnResultClicked(buttonContent, this);
            }
            else
            {
                calculatorModel.resultState.OnResultClicked(buttonContent, this);
            }
            Log(oldState, "Result_Click");
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            calculatorModel.state = State.First;
            calculatorModel.result = 0;
            Dial.Text = calculatorModel.result.ToString();
            calculatorModel.firstNumber = 0;
            calculatorModel.secondNumber = 0;
            LastOperation.Text = string.Empty;
            calculatorModel.canBeRefreshed = true;
            calculatorModel.mathOperator = string.Empty;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Dial.Text.Length > 0)
            {
                Dial.Text = Dial.Text.Remove(Dial.Text.Length - 1);
            }
        }
        private void Log(State oldState, string source)
        {
            //MessageBox.Show($"{source} = {oldState} to {calculatorModel.state}, " +
            //    $"first={calculatorModel.firstNumber}, " +
            //    $"second = {calculatorModel.secondNumber} " +
            //    $"result = {calculatorModel.result} operator = {calculatorModel.mathOperator}");
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            if (calculatorModel.isHistoryVisible)
            {
                HistoryListView.Visibility = Visibility.Collapsed;
                calculatorModel.isHistoryVisible = false;
            }
            else
            {
                HistoryListView.Visibility = Visibility.Visible;
                calculatorModel.isHistoryVisible = true;
            }
        }
    }
}