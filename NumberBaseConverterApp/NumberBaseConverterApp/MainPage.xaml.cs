using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace NumberBaseConverterApp
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            string numberString = NumberTextBox.Text;
            int baseTo = Convert.ToInt32(((ComboBoxItem)BaseToComboBox.SelectedItem).Content);
            int baseFrom = Convert.ToInt32(((ComboBoxItem)BaseFromComboBox.SelectedItem).Content);

            int numberDecimal = ConvertToDecimal(numberString, baseFrom);
            string result = ConvertFromDecimal(numberDecimal, baseTo);

            ResultTextBlock.Text = result;
        }

        private int ConvertToDecimal(string number, int baseFrom)
        {
            int result = 0;
            int power = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = GetValueOfDigit(number[i]);
                result += digit * (int)Math.Pow(baseFrom, power);
                power++;
            }

            return result;
        }

        private string ConvertFromDecimal(int number, int baseTo)
        {
            string result = string.Empty;

            while (number > 0)
            {
                int remainder = number % baseTo;
                char digit = GetDigitOfValue(remainder);
                result = digit + result;
                number /= baseTo;
            }

            return result;
        }

        private int GetValueOfDigit(char digit)
        {
            if (char.IsDigit(digit))
                return int.Parse(digit.ToString());
            else
                return digit - 'A' + 10;
        }

        private char GetDigitOfValue(int value)
        {
            if (value < 10)
                return value.ToString()[0];
            else
                return (char)('A' + value - 10);
        }
    }
}
