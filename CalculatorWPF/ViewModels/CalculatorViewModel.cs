using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using CalculatorWPF.Models;
using CalculatorWPF.Source;

namespace CalculatorWPF.ViewModels
{
    internal class CalculatorViewModel : Conductor<object>
    {
        private readonly Calculator _calculator;
        private CalcAction _lastCalcAction = CalcAction.Answer;


        private string _logTxtBox;
        public string LogTxtBox
        {
            get { return _logTxtBox; }
            set
            {
                _logTxtBox = value;
                NotifyOfPropertyChange(() => LogTxtBox);
            }
        }

        private string _inputNumbersTxtBox;
        public string InputNumbersTxtBox
        {
            get { return _inputNumbersTxtBox; }
            set
            {
                _inputNumbersTxtBox = value;
                NotifyOfPropertyChange(() => InputNumbersTxtBox);
            }
        }

        public CalculatorViewModel()
        {
            _calculator = new Calculator();
        }

        public void KeyPressed(KeyEventArgs args)
        {
            #region обработка цифр
            if (args.Key == Key.D1 || args.Key == Key.NumPad1)
            {
                NumberPressed("1");
                return;
            }
            if (args.Key == Key.D2 || args.Key == Key.NumPad2)
            {
                NumberPressed("2");
                return;
            }
            if (args.Key == Key.D3 || args.Key == Key.NumPad3)
            {
                NumberPressed("3");
                return;
            }
            if (args.Key == Key.D4 || args.Key == Key.NumPad4)
            {
                NumberPressed("4");
                return;
            }
            if (args.Key == Key.D5 || args.Key == Key.NumPad5)
            {
                NumberPressed("5");
                return;
            }
            if (args.Key == Key.D6 || args.Key == Key.NumPad6)
            {
                NumberPressed("6");
                return;
            }
            if (args.Key == Key.D7 || args.Key == Key.NumPad7)
            {
                NumberPressed("7");
                return;
            }
            if (args.Key == Key.D8 || args.Key == Key.NumPad8)
            {
                NumberPressed("8");
                return;
            }
            if (args.Key == Key.D9 || args.Key == Key.NumPad9)
            {
                NumberPressed("9");
                return;
            }
            if (args.Key == Key.D0 || args.Key == Key.NumPad0)
            {
                NumberPressed("0");
                return;
            }
            if (args.Key == Key.Decimal)
            {
                NumberPressed(",");
                return;
            }
            #endregion

            #region обработка действий
            if (args.Key == Key.Back)
            {
                ActionPressed(CalcAction.Remove);
                return;
            }
            if (args.Key == Key.Delete)
            {
                ActionPressed(CalcAction.Reset);
                return;
            }
            if (args.Key == Key.Divide || args.Key == Key.Decimal)
            {
                ActionPressed(CalcAction.Divide);
                return;
            }
            if (args.Key == Key.Multiply)
            {
                ActionPressed(CalcAction.Multi);
                return;
            }
            if (args.Key == Key.Add || args.Key == Key.OemPlus)
            {
                ActionPressed(CalcAction.Sum);
                return;
            }
            if (args.Key == Key.Subtract)
            {
                ActionPressed(CalcAction.Minus);
                return;
            }
            if (args.Key == Key.Enter)
            {
                ActionPressed(CalcAction.Answer);
                return;
            }
            #endregion
        }

        public void TextMove(object sender)
        {
            var txtBox = sender as TextBox;
            txtBox.CaretIndex = txtBox.Text.Length;

            var rect = txtBox.GetRectFromCharacterIndex(txtBox.CaretIndex);
            txtBox.ScrollToHorizontalOffset(rect.Right);
        }

        public void NumberPressed(string input)
        {


            InputNumbersTxtBox += input;
            //LogTxtBox += input;
        }

        public void ActionPressed(CalcAction calcAction)
        {
            if (!string.IsNullOrEmpty(InputNumbersTxtBox) || !string.IsNullOrEmpty(LogTxtBox))
            {
                if (calcAction == CalcAction.Reset)
                {
                    InputNumbersTxtBox = string.Empty;
                    LogTxtBox = string.Empty;
                    _calculator.Reset();
                    return;
                }

                if (calcAction == CalcAction.Remove)
                {
                    if (InputNumbersTxtBox.Length > 0)
                    {
                        InputNumbersTxtBox = InputNumbersTxtBox.Remove(InputNumbersTxtBox.Length - 1);
                        //LogTxtBox = LogTxtBox.Remove(LogTxtBox.Length - 1);
                    }
                    return;
                }

                if (calcAction == CalcAction.Answer)
                {
                    if (InputNumbersTxtBox.Length != 0)
                    {
                        _calculator.Calculate(InputNumbersTxtBox, _lastCalcAction);
                    }

                    InputNumbersTxtBox = _calculator.Answer.ToString();
                    LogTxtBox = string.Empty;
                    _calculator.Reset();
                    return;
                }
                else
                {
                    if (calcAction == CalcAction.Root)
                    {
                        LogTxtBox += calcAction.GetDescription() + InputNumbersTxtBox;
                        _calculator.Calculate(InputNumbersTxtBox, calcAction);
                    }
                    else
                    {
                        LogTxtBox += InputNumbersTxtBox + calcAction.GetDescription();
                        _calculator.Calculate(InputNumbersTxtBox, _lastCalcAction);
                        _lastCalcAction = calcAction;

                    }
                    InputNumbersTxtBox = string.Empty;
                    //_lastCalcAction = calcAction;

                }
            }
        }



    }
}
