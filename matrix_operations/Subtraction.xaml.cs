﻿using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace matrix_operations
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Subtraction : Page
    {
        #region Variables
        public string row;
        public string column;

        public double[,] leftMatrix;
        public double[,] leftMatrixTemp;
        public double[,] rightMatrix;
        public double[,] rightMatrixTemp;
        #endregion

        public Subtraction()
        {
            this.InitializeComponent();
            r0c0.Visibility = Visibility.Collapsed;
            r1c0.Visibility = Visibility.Collapsed;
            r2c0.Visibility = Visibility.Collapsed;
            r0c1.Visibility = Visibility.Collapsed;
            r1c1.Visibility = Visibility.Collapsed;
            r2c1.Visibility = Visibility.Collapsed;
            r0c2.Visibility = Visibility.Collapsed;
            r1c2.Visibility = Visibility.Collapsed;
            r2c2.Visibility = Visibility.Collapsed;
            c3r0c0.Visibility = Visibility.Collapsed;
            c3r1c0.Visibility = Visibility.Collapsed;
            c3r2c0.Visibility = Visibility.Collapsed;
            c3r0c1.Visibility = Visibility.Collapsed;
            c3r1c1.Visibility = Visibility.Collapsed;
            c3r2c1.Visibility = Visibility.Collapsed;
            c3r0c2.Visibility = Visibility.Collapsed;
            c3r1c2.Visibility = Visibility.Collapsed;
            c3r2c2.Visibility = Visibility.Collapsed;
        }

        private void RowsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            row = RowsComboBox.SelectedItem.ToString();
            if (column == null)
            {
                column = "1";
            }

            CheckRowsColumns(row, column);
        }

        private void ColumnsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (row == null)
            {
                row = "1";
            }
            column = ColumnsComboBox.SelectedItem.ToString();
            CheckRowsColumns(row, column);
        }

        private void CheckRowsColumns(string rows, string columns)
        {
            // left Side
            r0c0.Visibility = Visibility.Collapsed;
            r1c0.Visibility = Visibility.Collapsed;
            r2c0.Visibility = Visibility.Collapsed;
            r0c1.Visibility = Visibility.Collapsed;
            r1c1.Visibility = Visibility.Collapsed;
            r2c1.Visibility = Visibility.Collapsed;
            r0c2.Visibility = Visibility.Collapsed;
            r1c2.Visibility = Visibility.Collapsed;
            r2c2.Visibility = Visibility.Collapsed;
            // right side
            c3r0c0.Visibility = Visibility.Collapsed;
            c3r1c0.Visibility = Visibility.Collapsed;
            c3r2c0.Visibility = Visibility.Collapsed;
            c3r0c1.Visibility = Visibility.Collapsed;
            c3r1c1.Visibility = Visibility.Collapsed;
            c3r2c1.Visibility = Visibility.Collapsed;
            c3r0c2.Visibility = Visibility.Collapsed;
            c3r1c2.Visibility = Visibility.Collapsed;
            c3r2c2.Visibility = Visibility.Collapsed;

            if (rows == "1" || rows == null)
            {
                if (columns == null || columns == "1")
                {
                    // left Side
                    r0c0.Visibility = Visibility.Visible;
                    // right Side
                    c3r0c0.Visibility = Visibility.Visible;
                }
                else if (columns == "2")
                {
                    // left Side
                    r0c0.Visibility = Visibility.Visible;
                    r0c1.Visibility = Visibility.Visible;
                    // right Side
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r0c1.Visibility = Visibility.Visible;
                }
                else if (columns == "3")
                {
                    // left Side
                    r0c0.Visibility = Visibility.Visible;
                    r0c1.Visibility = Visibility.Visible;
                    r0c2.Visibility = Visibility.Visible;
                    // right Side
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r0c1.Visibility = Visibility.Visible;
                    c3r0c2.Visibility = Visibility.Visible;
                }
            }
            else if (rows == "2")
            {
                if (columns == null || columns == "1")
                {
                    // left Side
                    r0c0.Visibility = Visibility.Visible;
                    r1c0.Visibility = Visibility.Visible;
                    // right Side
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r1c0.Visibility = Visibility.Visible;
                }
                else if (columns == "2")
                {
                    // left Side
                    r0c0.Visibility = Visibility.Visible;
                    r1c0.Visibility = Visibility.Visible;
                    r0c1.Visibility = Visibility.Visible;
                    r1c1.Visibility = Visibility.Visible;
                    // right Side
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r1c0.Visibility = Visibility.Visible;
                    c3r0c1.Visibility = Visibility.Visible;
                    c3r1c1.Visibility = Visibility.Visible;
                }
                else if (columns == "3")
                {
                    // left Side
                    r0c0.Visibility = Visibility.Visible;
                    r1c0.Visibility = Visibility.Visible;
                    r0c1.Visibility = Visibility.Visible;
                    r1c1.Visibility = Visibility.Visible;
                    r0c2.Visibility = Visibility.Visible;
                    r1c2.Visibility = Visibility.Visible;
                    // right Side
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r1c0.Visibility = Visibility.Visible;
                    c3r0c1.Visibility = Visibility.Visible;
                    c3r1c1.Visibility = Visibility.Visible;
                    c3r0c2.Visibility = Visibility.Visible;
                    c3r1c2.Visibility = Visibility.Visible;
                }
            }
            else if (rows == "3")
            {
                if (columns == null || columns == "1")
                {
                    // left Side
                    r0c0.Visibility = Visibility.Visible;
                    r1c0.Visibility = Visibility.Visible;
                    r2c0.Visibility = Visibility.Visible;
                    // right Side
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r1c0.Visibility = Visibility.Visible;
                    c3r2c0.Visibility = Visibility.Visible;
                }
                else if (columns == "2")
                {
                    // left Side
                    r0c0.Visibility = Visibility.Visible;
                    r1c0.Visibility = Visibility.Visible;
                    r2c0.Visibility = Visibility.Visible;
                    r0c1.Visibility = Visibility.Visible;
                    r1c1.Visibility = Visibility.Visible;
                    r2c1.Visibility = Visibility.Visible;
                    // right Side
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r1c0.Visibility = Visibility.Visible;
                    c3r2c0.Visibility = Visibility.Visible;
                    c3r0c1.Visibility = Visibility.Visible;
                    c3r1c1.Visibility = Visibility.Visible;
                    c3r2c1.Visibility = Visibility.Visible;
                }
                else if (columns == "3")
                {
                    // left Side
                    r0c0.Visibility = Visibility.Visible;
                    r1c0.Visibility = Visibility.Visible;
                    r2c0.Visibility = Visibility.Visible;
                    r0c1.Visibility = Visibility.Visible;
                    r1c1.Visibility = Visibility.Visible;
                    r2c1.Visibility = Visibility.Visible;
                    r0c2.Visibility = Visibility.Visible;
                    r1c2.Visibility = Visibility.Visible;
                    r2c2.Visibility = Visibility.Visible;
                    // right Side
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r1c0.Visibility = Visibility.Visible;
                    c3r2c0.Visibility = Visibility.Visible;
                    c3r0c1.Visibility = Visibility.Visible;
                    c3r1c1.Visibility = Visibility.Visible;
                    c3r2c1.Visibility = Visibility.Visible;
                    c3r0c2.Visibility = Visibility.Visible;
                    c3r1c2.Visibility = Visibility.Visible;
                    c3r2c2.Visibility = Visibility.Visible;
                }
            }
        }

        private void CalculateResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InstantiateLeftMatrix(row, column);
                leftMatrix = leftMatrixTemp;
                InstantiateRigihtMatrix(row, column);
                rightMatrix = rightMatrixTemp;
                CalculateAnswer(row, column, leftMatrix, rightMatrix);
            }
            catch (FormatException)
            {
                MainPage.ShowNullCustomDialogAsync();
            }
            catch (Exception)
            {
                MainPage.ShowUnexpectedErrorAysnc();
            }
        }

        private void CalculateAnswer(string rows, string columns, double[,] leftMatrix, double[,] rightMatrix)
        {
            if (rows == "1" || rows == null)
            {
                if (columns == null || columns == "1")
                {
                    Rr0c0.Text = (leftMatrix[0, 0] - rightMatrix[0, 0]).ToString();
                }
                else if (columns == "2")
                {
                    Rr0c0.Text = (leftMatrix[0, 0] - rightMatrix[0, 0]).ToString();
                    Rr0c1.Text = (leftMatrix[0, 1] - rightMatrix[0, 1]).ToString();
                }
                else if (columns == "3")
                {
                    Rr0c0.Text = (leftMatrix[0, 0] - rightMatrix[0, 0]).ToString();
                    Rr0c1.Text = (leftMatrix[0, 1] - rightMatrix[0, 1]).ToString();
                    Rr0c2.Text = (leftMatrix[0, 2] - rightMatrix[0, 2]).ToString();
                }
            }
            else if (rows == "2")
            {
                if (columns == null || columns == "1")
                {
                    Rr0c0.Text = (leftMatrix[0, 0] - rightMatrix[0, 0]).ToString();
                    Rr1c0.Text = (leftMatrix[1, 0] - rightMatrix[1, 0]).ToString();
                }
                else if (columns == "2")
                {
                    Rr0c0.Text = (leftMatrix[0, 0] - rightMatrix[0, 0]).ToString();
                    Rr0c1.Text = (leftMatrix[0, 1] - rightMatrix[0, 1]).ToString();
                    Rr1c0.Text = (leftMatrix[1, 0] - rightMatrix[1, 0]).ToString();
                    Rr1c1.Text = (leftMatrix[1, 1] - rightMatrix[1, 1]).ToString();
                }
                else if (columns == "3")
                {
                    Rr0c0.Text = (leftMatrix[0, 0] - rightMatrix[0, 0]).ToString();
                    Rr0c1.Text = (leftMatrix[0, 1] - rightMatrix[0, 1]).ToString();
                    Rr0c2.Text = (leftMatrix[0, 2] - rightMatrix[0, 2]).ToString();
                    Rr1c0.Text = (leftMatrix[1, 0] - rightMatrix[1, 0]).ToString();
                    Rr1c1.Text = (leftMatrix[1, 1] - rightMatrix[1, 1]).ToString();
                    Rr1c2.Text = (leftMatrix[1, 2] - rightMatrix[1, 2]).ToString();
                }
            }
            else if (rows == "3")
            {
                if (columns == null || columns == "1")
                {
                    Rr0c0.Text = (leftMatrix[0, 0] - rightMatrix[0, 0]).ToString();
                    Rr1c0.Text = (leftMatrix[1, 0] - rightMatrix[1, 0]).ToString();
                    Rr2c0.Text = (leftMatrix[2, 0] - rightMatrix[2, 0]).ToString();
                }
                else if (columns == "2")
                {
                    Rr0c0.Text = (leftMatrix[0, 0] - rightMatrix[0, 0]).ToString();
                    Rr0c1.Text = (leftMatrix[0, 1] - rightMatrix[0, 1]).ToString();
                    Rr1c0.Text = (leftMatrix[1, 0] - rightMatrix[1, 0]).ToString();
                    Rr1c1.Text = (leftMatrix[1, 1] - rightMatrix[1, 1]).ToString();
                    Rr2c0.Text = (leftMatrix[2, 0] - rightMatrix[2, 0]).ToString();
                    Rr2c1.Text = (leftMatrix[2, 1] - rightMatrix[2, 1]).ToString();
                }
                else if (columns == "3")
                {
                    Rr0c0.Text = (leftMatrix[0, 0] - rightMatrix[0, 0]).ToString();
                    Rr0c1.Text = (leftMatrix[0, 1] - rightMatrix[0, 1]).ToString();
                    Rr0c2.Text = (leftMatrix[0, 2] - rightMatrix[0, 2]).ToString();
                    Rr1c0.Text = (leftMatrix[1, 0] - rightMatrix[1, 0]).ToString();
                    Rr1c1.Text = (leftMatrix[1, 1] - rightMatrix[1, 1]).ToString();
                    Rr1c2.Text = (leftMatrix[1, 2] - rightMatrix[1, 2]).ToString();
                    Rr2c0.Text = (leftMatrix[2, 0] - rightMatrix[2, 0]).ToString();
                    Rr2c1.Text = (leftMatrix[2, 1] - rightMatrix[2, 1]).ToString();
                    Rr2c2.Text = (leftMatrix[2, 2] - rightMatrix[2, 2]).ToString();
                }
            }
        }

        private void InstantiateLeftMatrix(string rows, string columns)
        {
            if (rows == "1" || rows == null)
            {
                if (columns == null || columns == "1")
                {
                    leftMatrixTemp = new double[1, 1] { { double.Parse(r0c0.Text) } };
                }
                else if (columns == "2")
                {
                    leftMatrixTemp = new double[1, 2] { { double.Parse(r0c0.Text), double.Parse(r0c1.Text) } };
                }
                else if (columns == "3")
                {
                    leftMatrixTemp = new double[1, 3] { { double.Parse(r0c0.Text), double.Parse(r0c1.Text), double.Parse(r0c2.Text) } };
                }
            }
            else if (rows == "2")
            {
                if (columns == null || columns == "1")
                {
                    leftMatrixTemp = new double[2, 1] { { double.Parse(r0c0.Text) },
                                                     { double.Parse(r1c0.Text)} };
                }
                else if (columns == "2")
                {
                    leftMatrixTemp = new double[2, 2] { { double.Parse(r0c0.Text), double.Parse(r0c1.Text) },
                                                     { double.Parse(r1c0.Text), double.Parse(r1c1.Text) } };
                }
                else if (columns == "3")
                {
                    leftMatrixTemp = new double[2, 3] { { double.Parse(r0c0.Text), double.Parse(r0c1.Text), double.Parse(r0c2.Text) },
                                                     { double.Parse(r1c0.Text), double.Parse(r1c1.Text), double.Parse(r1c2.Text) } };
                }
            }
            else if (rows == "3")
            {
                if (columns == null || columns == "1")
                {
                    columns = "1";
                    leftMatrixTemp = new double[3, 1] { { double.Parse(r0c0.Text) },
                                                     { double.Parse(r1c0.Text) },
                                                     { double.Parse(r2c0.Text) }};
                }
                else if (columns == "2")
                {
                    leftMatrixTemp = new double[3, 2] { { double.Parse(r0c0.Text), double.Parse(r0c1.Text) },
                                                     { double.Parse(r1c0.Text), double.Parse(r1c1.Text) },
                                                     { double.Parse(r2c0.Text), double.Parse(r2c1.Text) }};
                }
                else if (columns == "3")
                {
                    leftMatrixTemp = new double[3, 3] { { double.Parse(r0c0.Text), double.Parse(r0c1.Text), double.Parse(r0c2.Text) },
                                                     { double.Parse(r1c0.Text), double.Parse(r1c1.Text), double.Parse(r1c2.Text) },
                                                     { double.Parse(r2c0.Text), double.Parse(r2c1.Text), double.Parse(r2c2.Text) }};
                }
            }
        }

        private void InstantiateRigihtMatrix(string rows, string columns)
        {
            if (rows == "1" || rows == null)
            {
                if (columns == null || columns == "1")
                {
                    rightMatrixTemp = new double[1, 1] { { double.Parse(c3r0c0.Text) } };
                }
                else if (columns == "2")
                {
                    rightMatrixTemp = new double[1, 2] { { double.Parse(c3r0c0.Text), double.Parse(c3r0c1.Text) } };
                }
                else if (columns == "3")
                {
                    rightMatrixTemp = new double[1, 3] { { double.Parse(c3r0c0.Text), double.Parse(c3r0c1.Text), double.Parse(c3r0c2.Text) } };
                }
            }
            else if (rows == "2")
            {
                if (columns == null || columns == "1")
                {
                    rightMatrixTemp = new double[2, 1] { { double.Parse(c3r0c0.Text) },
                                                     { double.Parse(c3r1c0.Text)} };
                }
                else if (columns == "2")
                {
                    rightMatrixTemp = new double[2, 2] { { double.Parse(c3r0c0.Text), double.Parse(c3r0c1.Text) },
                                                     { double.Parse(c3r1c0.Text), double.Parse(c3r1c1.Text) } };
                }
                else if (columns == "3")
                {
                    rightMatrixTemp = new double[2, 3] { { double.Parse(c3r0c0.Text), double.Parse(c3r0c1.Text), double.Parse(c3r0c2.Text) },
                                                     { double.Parse(c3r1c0.Text), double.Parse(c3r1c1.Text), double.Parse(c3r1c2.Text) } };
                }
            }
            else if (rows == "3")
            {
                if (columns == null || columns == "1")
                {
                    columns = "1";
                    rightMatrixTemp = new double[3, 1] { { double.Parse(c3r0c0.Text) },
                                                     { double.Parse(c3r1c0.Text) },
                                                     { double.Parse(c3r2c0.Text) }};
                }
                else if (columns == "2")
                {
                    rightMatrixTemp = new double[3, 2] { { double.Parse(c3r0c0.Text), double.Parse(c3r0c1.Text) },
                                                     { double.Parse(c3r1c0.Text), double.Parse(c3r1c1.Text) },
                                                     { double.Parse(c3r2c0.Text), double.Parse(c3r2c1.Text) }};
                }
                else if (columns == "3")
                {
                    rightMatrixTemp = new double[3, 3] { { double.Parse(c3r0c0.Text), double.Parse(c3r0c1.Text), double.Parse(c3r0c2.Text) },
                                                     { double.Parse(c3r1c0.Text), double.Parse(c3r1c1.Text), double.Parse(c3r1c2.Text) },
                                                     { double.Parse(c3r2c0.Text), double.Parse(c3r2c1.Text), double.Parse(c3r2c2.Text) }};
                }
            }
        }

    }
}
