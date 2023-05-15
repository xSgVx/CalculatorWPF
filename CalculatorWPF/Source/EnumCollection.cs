using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF.Source
{
    enum CalcAction
    {
        Answer = 0,
        Remove,
        Reset,
        [Description("/")] Divide,
        [Description("*")] Multi,
        [Description("+")] Sum,
        [Description("-")] Minus,
        [Description("√")] Root,
        [Description("^")] Power,
    }

}
