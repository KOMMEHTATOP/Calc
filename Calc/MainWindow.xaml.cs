﻿using Calc.Model;
using Calc.ViewModel;
using System.Diagnostics;
using System.IO;
using System.Windows;


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
            ViewClickController viewClickController = new ViewClickController(this, calculatorModel);
            ModelUpdateController modelUpdateController = new ModelUpdateController(this, calculatorModel);
            ViewKeyDownController viewKeyDownController = new ViewKeyDownController(this, calculatorModel);
            viewKeyDownController.Subscribe();
            viewClickController.Subscribe();
            modelUpdateController.Subscribe();
        }

        public void Log(State oldState, string source)
        {
            //MessageBox.Show($"{source} = {oldState} to {calculatorModel.state}, " +
            //    $"first={calculatorModel.FirstNumber}, " +
            //    $"second = {calculatorModel.SecondNumber} " +
            //    $"result = {calculatorModel.Result} operator = {calculatorModel.MathOperator}");
        }
    }
}