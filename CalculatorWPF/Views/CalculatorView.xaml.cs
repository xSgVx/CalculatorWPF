using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CalculatorWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для CalculatorView.xaml
    /// </summary>
    public partial class CalculatorView : Window
    {
        public CalculatorView()
        {
            InitializeComponent();
        }

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //    //(sender as TextBox).ScrollToEnd();

        //    var txtBox = sender as TextBox;
        //    txtBox.CaretIndex = txtBox.Text.Length;
        //    var rect = txtBox.GetRectFromCharacterIndex(txtBox.CaretIndex);
        //    txtBox.ScrollToHorizontalOffset(rect.Right);
        //}
    }
}
