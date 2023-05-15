using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorWPF.Source;

namespace CalculatorWPF.Models
{
    internal class Calculator
    {
        public double Answer => _answer;
        private double _answer = double.NaN;

        public void Calculate(string sValue, CalcAction calcAction)
        {
            double value = double.NaN;
            if (double.TryParse(sValue, out value))
            {
                if (_answer.Equals(double.NaN))
                {
                    if (calcAction == CalcAction.Root)
                    {
                        _answer = Math.Sqrt(value);
                        return;
                    }

                    _answer = value;
                    return;
                }

                switch (calcAction)
                {
                    case CalcAction.Sum:
                        _answer += value;
                        break;

                    case CalcAction.Minus:
                        _answer -= value;
                        break;

                    case CalcAction.Divide:
                        if (_answer != 0)
                        {
                            _answer /= value;
                        }
                        break;

                    case CalcAction.Multi:
                        _answer *= value;
                        break;

                    case CalcAction.Root:
                        _answer = Math.Sqrt( value);
                        break;

                    case CalcAction.Power:
                        _answer = Math.Pow(_answer, value);
                        break;

                    default:
                        break;
                }
            }
        }

        public void Reset()
        {
            _answer = double.NaN;
        }

    }
}
