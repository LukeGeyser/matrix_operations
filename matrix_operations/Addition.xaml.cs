using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace matrix_operations
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Addition : Page
    {
        public Addition()
        {
            this.InitializeComponent();
        }

        private void RowsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RowsComboBox.SelectedItem.ToString() == "1")
            {

                Debug.WriteLine("1");
            }
            else if (RowsComboBox.SelectedItem.ToString() == "2")
            {
                Debug.WriteLine("2");
            }
            else if (RowsComboBox.SelectedItem.ToString() == "3")
            {
                Debug.WriteLine("3");
            }
        }

        private void ColumnsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
