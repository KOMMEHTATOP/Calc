using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calc.ViewModel
{
    public class Contoller : INotifyPropertyChanged
    {
        public string СontentOnButton { get; set; }
        public double Number { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void ButtonTextOnNumber(string text)
        {
            if (double.TryParse(text, out double result))
            {
                Number = result;
            }
            else
            {
                MessageBox.Show("IsNotANumber"); //это логика, возможно переместить позже. 
            }
        }
    }
}
