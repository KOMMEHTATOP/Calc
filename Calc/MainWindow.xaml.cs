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
            Dial.Text = calculatorModel.Result.ToString();
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
            calculatorModel.HistoryViewChanged += OnHistoryViewChanged;
            calculatorModel.FirstNumberChanged += OnFirstNumberChanged;
        }

        private void OnFirstNumberChanged(double firstNumber)
        {
            
        }

        private void OnHistoryViewChanged(HistoryItem historyItem)
        {
            HistoryListView.Items.Add(historyItem);
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
                calculatorModel.firstState.OnNumberClicked(buttonContent, calculatorModel);
            }
            else if (calculatorModel.state == State.Opers)
            {
                calculatorModel.opersState.OnNumberClicked(buttonContent, calculatorModel);
            }
            else if (calculatorModel.state == State.Second)
            {
                calculatorModel.secondState.OnNumberClicked(buttonContent, calculatorModel);
            }
            else
            {
                calculatorModel.resultState.OnNumberClicked(buttonContent, calculatorModel);
            }
            Log(oldState, "Number_Click");
        }

        private void Oper_Click(object sender, RoutedEventArgs e)
        {
            calculatorModel.CanBeRefreshed = true;

            var oldState = calculatorModel.state;
            Button button = sender as Button;
            string buttonContent = button.Content.ToString();

            if (calculatorModel.state == State.First)
            {
                calculatorModel.firstState.OnOperClicked(buttonContent, calculatorModel);
            }
            else if (calculatorModel.state == State.Opers)
            {
                calculatorModel.opersState.OnOperClicked(buttonContent, calculatorModel);
            }
            else if (calculatorModel.state == State.Second)
            {
                calculatorModel.secondState.OnOperClicked(buttonContent, calculatorModel);
            }
            else
            {
                calculatorModel.resultState.OnOperClicked(buttonContent, calculatorModel);
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
                calculatorModel.firstState.OnResultClicked(buttonContent, calculatorModel);
            }
            else if (calculatorModel.state == State.Opers)
            {
                calculatorModel.opersState.OnResultClicked(buttonContent, calculatorModel);
            }
            else if (calculatorModel.state == State.Second)
            {
                calculatorModel.secondState.OnResultClicked(buttonContent, calculatorModel);
            }
            else
            {
                calculatorModel.resultState.OnResultClicked(buttonContent, calculatorModel);
            }
            Log(oldState, "Result_Click");
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            calculatorModel.state = State.First;
            calculatorModel.Result = 0;
            Dial.Text = calculatorModel.Result.ToString();
            calculatorModel.SetFirstNumber(0);
            calculatorModel.SecondNumber = 0;
            LastOperation.Text = string.Empty;
            calculatorModel.CanBeRefreshed = true;
            calculatorModel.MathOperator = string.Empty;
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
            if (calculatorModel.IsHistoryVisible)
            {
                HistoryListView.Visibility = Visibility.Collapsed;
                calculatorModel.IsHistoryVisible = false;
            }
            else
            {
                HistoryListView.Visibility = Visibility.Visible;
                calculatorModel.IsHistoryVisible = true;
            }
        }
    }
}