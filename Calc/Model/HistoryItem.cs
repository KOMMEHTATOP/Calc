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
        public string key;
        public string value;

        public HistoryItem(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
        public override string ToString()
        {
            return $"{key} \n{value}";
        }

    }
}
