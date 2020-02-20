using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.IO;
using System.Data.OleDb;
using TSD_Comp_Tabulator.ViewModels;
using Caliburn.Micro;


namespace TSD_Comp_Tabulator.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
        }

        private void TextBox_GotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
            //(sender as TextBox).Select(0, (sender as TextBox).Text.Length);
            (sender as TextBox).Focus();
            e.Handled = true;
        }

    }
}
