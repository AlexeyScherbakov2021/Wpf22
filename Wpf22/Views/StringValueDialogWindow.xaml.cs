using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf22.Views
{
    /// <summary>
    /// Логика взаимодействия для StringValueDialogWindow.xaml
    /// </summary>
    public partial class StringValueDialogWindow 
    {
        public string Message { get => MessageTextBlock.Text; set => MessageTextBlock.Text = value; }

        public string Value { get => ValueTextBox.Text; set => ValueTextBox.Text = value; }


        public StringValueDialogWindow()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            if (!(e.Source is Button button)) return;

            DialogResult = !button.IsCancel;
            Close();
        }
    }
}
