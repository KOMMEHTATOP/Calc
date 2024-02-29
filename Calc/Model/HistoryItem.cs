using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Calc.Model
{
    public class HistoryItem
    {
        private string _key;
        public string key
        {
            get { return _key; }
            set { _key = value; }
        }

        private string _value;
        public string value
        {
            get { return _value; }
            set { _value = value; }
        }

        public HistoryItem(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
        public override string ToString()
        {
            return $"{key} {value}";
        }
    }
}
