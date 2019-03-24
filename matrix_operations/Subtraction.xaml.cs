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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace matrix_operations
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Subtraction : Page
    {
        public string row;
        public string column;

        public string rowRight;
        public string columnRight;

        public int[,] leftMatrix;
        public int[,] leftMatrixTemp;
        public int[,] rightMatrix;
        public int[,] rightMatrixTemp;

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
            r0c0.Visibility = Visibility.Collapsed;
            r1c0.Visibility = Visibility.Collapsed;
            r2c0.Visibility = Visibility.Collapsed;
            r0c1.Visibility = Visibility.Collapsed;
            r1c1.Visibility = Visibility.Collapsed;
            r2c1.Visibility = Visibility.Collapsed;
            r0c2.Visibility = Visibility.Collapsed;
            r1c2.Visibility = Visibility.Collapsed;
            r2c2.Visibility = Visibility.Collapsed;

            if (rows == "1" || rows == null)
            {
                if (columns == null || columns == "1")
                {
                    r0c0.Visibility = Visibility.Visible;
                }
                else if (columns == "2")
                {
                    r0c0.Visibility = Visibility.Visible;
                    r0c1.Visibility = Visibility.Visible;
                }
                else if (columns == "3")
                {
                    r0c0.Visibility = Visibility.Visible;
                    r0c1.Visibility = Visibility.Visible;
                    r0c2.Visibility = Visibility.Visible;
                }
            }
            else if (rows == "2")
            {
                if (columns == null || columns == "1")
                {
                    r0c0.Visibility = Visibility.Visible;
                    r1c0.Visibility = Visibility.Visible;
                }
                else if (columns == "2")
                {
                    r0c0.Visibility = Visibility.Visible;
                    r1c0.Visibility = Visibility.Visible;
                    r0c1.Visibility = Visibility.Visible;
                    r1c1.Visibility = Visibility.Visible;
                }
                else if (columns == "3")
                {
                    r0c0.Visibility = Visibility.Visible;
                    r1c0.Visibility = Visibility.Visible;
                    r0c1.Visibility = Visibility.Visible;
                    r1c1.Visibility = Visibility.Visible;
                    r0c2.Visibility = Visibility.Visible;
                    r1c2.Visibility = Visibility.Visible;
                }
            }
            else if (rows == "3")
            {
                if (columns == null || columns == "1")
                {
                    r0c0.Visibility = Visibility.Visible;
                    r1c0.Visibility = Visibility.Visible;
                    r2c0.Visibility = Visibility.Visible;
                }
                else if (columns == "2")
                {
                    r0c0.Visibility = Visibility.Visible;
                    r1c0.Visibility = Visibility.Visible;
                    r2c0.Visibility = Visibility.Visible;
                    r0c1.Visibility = Visibility.Visible;
                    r1c1.Visibility = Visibility.Visible;
                    r2c1.Visibility = Visibility.Visible;
                }
                else if (columns == "3")
                {
                    r0c0.Visibility = Visibility.Visible;
                    r1c0.Visibility = Visibility.Visible;
                    r2c0.Visibility = Visibility.Visible;
                    r0c1.Visibility = Visibility.Visible;
                    r1c1.Visibility = Visibility.Visible;
                    r2c1.Visibility = Visibility.Visible;
                    r0c2.Visibility = Visibility.Visible;
                    r1c2.Visibility = Visibility.Visible;
                    r2c2.Visibility = Visibility.Visible;
                }
            }

        }

        private void RowsComboBoxRight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (columnRight == null)
            {
                columnRight = "1";
            }
            rowRight = RowsComboBoxRight.SelectedItem.ToString();
            CheckRowsColumnsRight(rowRight, columnRight);
        }

        private void ColumnsComboBoxRight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rowRight == null)
            {
                rowRight = "1";
            }
            columnRight = ColumnsComboBoxRight.SelectedItem.ToString();
            CheckRowsColumnsRight(rowRight, columnRight);
        }

        private void CheckRowsColumnsRight(string rows, string columns)
        {
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
                    c3r0c0.Visibility = Visibility.Visible;
                }
                else if (columns == "2")
                {
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r0c1.Visibility = Visibility.Visible;
                }
                else if (columns == "3")
                {
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r0c1.Visibility = Visibility.Visible;
                    c3r0c2.Visibility = Visibility.Visible;
                }
            }
            else if (rows == "2")
            {
                if (columns == null || columns == "1")
                {
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r1c0.Visibility = Visibility.Visible;
                }
                else if (columns == "2")
                {
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r1c0.Visibility = Visibility.Visible;
                    c3r0c1.Visibility = Visibility.Visible;
                    c3r1c1.Visibility = Visibility.Visible;
                }
                else if (columns == "3")
                {
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
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r1c0.Visibility = Visibility.Visible;
                    c3r2c0.Visibility = Visibility.Visible;
                }
                else if (columns == "2")
                {
                    c3r0c0.Visibility = Visibility.Visible;
                    c3r1c0.Visibility = Visibility.Visible;
                    c3r2c0.Visibility = Visibility.Visible;
                    c3r0c1.Visibility = Visibility.Visible;
                    c3r1c1.Visibility = Visibility.Visible;
                    c3r2c1.Visibility = Visibility.Visible;
                }
                else if (columns == "3")
                {
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
            InstantiateLeftMatrix(row, column);
            leftMatrix = leftMatrixTemp;
            InstantiateRigihtMatrix(rowRight, columnRight);
            rightMatrix = rightMatrixTemp;
            CalculateAnswer(row, column, leftMatrix, rightMatrix);
        }

        private void CalculateAnswer(string rows, string columns, int[,] leftMatrix, int[,] rightMatrix)
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
                    leftMatrixTemp = new int[1, 1] { { int.Parse(r0c0.Text) } };
                }
                else if (columns == "2")
                {
                    leftMatrixTemp = new int[1, 2] { { int.Parse(r0c0.Text), int.Parse(r0c1.Text) } };
                }
                else if (columns == "3")
                {
                    leftMatrixTemp = new int[1, 3] { { int.Parse(r0c0.Text), int.Parse(r0c1.Text), int.Parse(r0c2.Text) } };
                }
            }
            else if (rows == "2")
            {
                if (columns == null || columns == "1")
                {
                    leftMatrixTemp = new int[2, 1] { { int.Parse(r0c0.Text) },
                                                     { int.Parse(r1c0.Text)} };
                }
                else if (columns == "2")
                {
                    leftMatrixTemp = new int[2, 2] { { int.Parse(r0c0.Text), int.Parse(r0c1.Text) },
                                                     { int.Parse(r1c0.Text), int.Parse(r1c1.Text) } };
                }
                else if (columns == "3")
                {
                    leftMatrixTemp = new int[2, 3] { { int.Parse(r0c0.Text), int.Parse(r0c1.Text), int.Parse(r0c2.Text) },
                                                     { int.Parse(r1c0.Text), int.Parse(r1c1.Text), int.Parse(r1c2.Text) } };
                }
            }
            else if (rows == "3")
            {
                if (columns == null || columns == "1")
                {
                    columns = "1";
                    leftMatrixTemp = new int[3, 1] { { int.Parse(r0c0.Text) },
                                                     { int.Parse(r1c0.Text) },
                                                     { int.Parse(r2c0.Text) }};
                }
                else if (columns == "2")
                {
                    leftMatrixTemp = new int[3, 2] { { int.Parse(r0c0.Text), int.Parse(r0c1.Text) },
                                                     { int.Parse(r1c0.Text), int.Parse(r1c1.Text) },
                                                     { int.Parse(r2c0.Text), int.Parse(r2c1.Text) }};
                }
                else if (columns == "3")
                {
                    leftMatrixTemp = new int[3, 3] { { int.Parse(r0c0.Text), int.Parse(r0c1.Text), int.Parse(r0c2.Text) },
                                                     { int.Parse(r1c0.Text), int.Parse(r1c1.Text), int.Parse(r1c2.Text) },
                                                     { int.Parse(r2c0.Text), int.Parse(r2c1.Text), int.Parse(r2c2.Text) }};
                }
            }
        }

        private void InstantiateRigihtMatrix(string rows, string columns)
        {
            if (rows == "1" || rows == null)
            {
                if (columns == null || columns == "1")
                {
                    rightMatrixTemp = new int[1, 1] { { int.Parse(c3r0c0.Text) } };
                }
                else if (columns == "2")
                {
                    rightMatrixTemp = new int[1, 2] { { int.Parse(c3r0c0.Text), int.Parse(c3r0c1.Text) } };
                }
                else if (columns == "3")
                {
                    rightMatrixTemp = new int[1, 3] { { int.Parse(c3r0c0.Text), int.Parse(c3r0c1.Text), int.Parse(c3r0c2.Text) } };
                }
            }
            else if (rows == "2")
            {
                if (columns == null || columns == "1")
                {
                    rightMatrixTemp = new int[2, 1] { { int.Parse(c3r0c0.Text) },
                                                     { int.Parse(c3r1c0.Text)} };
                }
                else if (columns == "2")
                {
                    rightMatrixTemp = new int[2, 2] { { int.Parse(c3r0c0.Text), int.Parse(c3r0c1.Text) },
                                                     { int.Parse(c3r1c0.Text), int.Parse(c3r1c1.Text) } };
                }
                else if (columns == "3")
                {
                    rightMatrixTemp = new int[2, 3] { { int.Parse(c3r0c0.Text), int.Parse(c3r0c1.Text), int.Parse(c3r0c2.Text) },
                                                     { int.Parse(c3r1c0.Text), int.Parse(c3r1c1.Text), int.Parse(c3r1c2.Text) } };
                }
            }
            else if (rows == "3")
            {
                if (columns == null || columns == "1")
                {
                    columns = "1";
                    rightMatrixTemp = new int[3, 1] { { int.Parse(c3r0c0.Text) },
                                                     { int.Parse(c3r1c0.Text) },
                                                     { int.Parse(c3r2c0.Text) }};
                }
                else if (columns == "2")
                {
                    rightMatrixTemp = new int[3, 2] { { int.Parse(c3r0c0.Text), int.Parse(c3r0c1.Text) },
                                                     { int.Parse(c3r1c0.Text), int.Parse(c3r1c1.Text) },
                                                     { int.Parse(c3r2c0.Text), int.Parse(c3r2c1.Text) }};
                }
                else if (columns == "3")
                {
                    rightMatrixTemp = new int[3, 3] { { int.Parse(c3r0c0.Text), int.Parse(c3r0c1.Text), int.Parse(c3r0c2.Text) },
                                                     { int.Parse(c3r1c0.Text), int.Parse(c3r1c1.Text), int.Parse(c3r1c2.Text) },
                                                     { int.Parse(c3r2c0.Text), int.Parse(c3r2c1.Text), int.Parse(c3r2c2.Text) }};
                }
            }
        }
    }
}
