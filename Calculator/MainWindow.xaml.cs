using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _currentNumber, _lastNumber;
        private Operation _operation;
        public MainWindow()
        {
            InitializeComponent();
            LabelResult.Content = "0";
        }

        public enum Operation
        {
            Multiply,
            Divide,
            Subtract,
            Add
        }

        private void ButtonNumber_OnClick(object sender, RoutedEventArgs e)
        {
            var buttonNumber = ((Button)sender).Content.ToString();
            _currentNumber = buttonNumber == "0" & _currentNumber == 0 ? 0 : double.Parse($"{LabelResult.Content}{buttonNumber}");
            LabelResult.Content = $"{_currentNumber}";
        }

        private void ButtonAc_OnClick(object sender, RoutedEventArgs e)
        {
            _lastNumber = 0;
            _currentNumber = 0;
            LabelResult.Content = $"{_currentNumber}";
        }

        private void ButtonPlusMinus_OnClick(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(LabelResult.Content.ToString(), out _currentNumber)) return;
            _currentNumber *= -1;
            LabelResult.Content = $"{_currentNumber}";
        }

        private void ButtonPercent_OnClick(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(LabelResult.Content.ToString(), out var tempNumber)) return;
            tempNumber = tempNumber / 100;
            if (_currentNumber != tempNumber) tempNumber *= _lastNumber;
            LabelResult.Content = $"{tempNumber}";
        }

        private void ButtonOperation_OnClick(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(LabelResult.Content.ToString(), out _currentNumber)) return;
            switch (((Button)sender).Content.ToString())
            {
                case "/":
                    _operation = Operation.Divide;
                    break;
                case "*":
                    _operation = Operation.Multiply;
                    break;
                case "-":
                    _operation = Operation.Subtract;
                    break;
                case "+":
                    _operation = Operation.Add;
                    break;
            }

            _lastNumber = _currentNumber;
            LabelResult.Content = "0";
        }

        private void ButtonPoint_OnClick(object sender, RoutedEventArgs e)
        {
            if (LabelResult.Content.ToString().Contains(".")) return;
            LabelResult.Content = $"{_currentNumber}.";
        }

        private void ButtonEquals_OnClick(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(LabelResult.Content.ToString(), out _currentNumber)) return;
            switch (_operation)
            {
                case Operation.Multiply:
                    _currentNumber = _lastNumber * _currentNumber;
                    break;
                case Operation.Divide:
                    _currentNumber = _lastNumber / _currentNumber;
                    break;
                case Operation.Subtract:
                    _currentNumber = _lastNumber - _currentNumber;
                    break;
                case Operation.Add:
                    _currentNumber = _lastNumber + _currentNumber;
                    break;
            }

            LabelResult.Content = $"{_currentNumber}";
        }
    }
}
