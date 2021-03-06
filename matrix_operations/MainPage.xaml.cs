﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace matrix_operations
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {            
            this.InitializeComponent();
            MyFrame.Navigate(typeof(Home));
            TitleTextBlock.Text = "Home";
            BackButton.Visibility = Visibility.Collapsed;
            IconsListBox.SelectedItem = IconsListBox.Items[0];
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeListBoxItem.IsSelected)
            {
                BackButton.Visibility = Visibility.Collapsed;
                MyFrame.Navigate(typeof(Home));
                TitleTextBlock.Text = "Home";
                if (MySplitView.IsPaneOpen)
                {
                    HamburgerButton_Click(this, new RoutedEventArgs());
                }
                
            }
            else if (AdditionListBoxItem.IsSelected)
            {
                BackButton.Visibility = Visibility.Visible;
                MyFrame.Navigate(typeof(Addition));
                TitleTextBlock.Text = "Matrix Addition";
                if (MySplitView.IsPaneOpen)
                {
                    HamburgerButton_Click(this, new RoutedEventArgs());
                }
            }
            else if (SubtractionListBoxItem.IsSelected)
            {
                BackButton.Visibility = Visibility.Visible;
                MyFrame.Navigate(typeof(Subtraction));
                TitleTextBlock.Text = "Matrix Subtraction";
                if (MySplitView.IsPaneOpen)
                {
                    HamburgerButton_Click(this, new RoutedEventArgs());
                }
            }
            else if (MultiplicationListBoxItem.IsSelected)
            {
                BackButton.Visibility = Visibility.Visible;
                MyFrame.Navigate(typeof(Multiplication));
                TitleTextBlock.Text = "Matrix Multiplication";
                if (MySplitView.IsPaneOpen)
                {
                    HamburgerButton_Click(this, new RoutedEventArgs());
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {            
            IconsListBox.SelectedItem = IconsListBox.Items[0];
        }

        private void ExitListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ExitBoxItem.IsSelected)
            {
                Debug.WriteLine("Exited Application");
                DisplayContent();
            }            
        }

        private async void DisplayContent()
        {           
            CustomDialog dialog = new CustomDialog();
            await dialog.ShowAsync();

            if (dialog.result == Result.Yes)
            {
                Application.Current.Exit();
            }
            else if (dialog.result == Result.No)
            {
                ExitBoxItem.IsSelected = false;
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationView.PreferredLaunchViewSize = new Size(900, 750);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(500, 500));
        }

        public static async void ShowNullCustomDialogAsync()
        {
            InputIsNullCustomDialog dialog = new InputIsNullCustomDialog();
            await dialog.ShowAsync();
            if (dialog.nullDialogResult == NullDialogResult.Retry)
            {
                return;
            }
        }

        public static async void ShowUnexpectedErrorAysnc()
        {
            UnexpectedErrorDialog dialog = new UnexpectedErrorDialog();
            await dialog.ShowAsync();
            if (dialog.unexpectedErrorResult == UnexpectedErrorResult.Close)
            {
                return;
            }
        }

    }
}
