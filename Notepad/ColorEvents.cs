using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Notepad
{
    public partial class MainWindow : Window
    {
        private void fontBlack_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Foreground = Brushes.Black;
        }

        private void fontDarkGray_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Foreground= Brushes.DarkGray;
        }

        private void fontGray_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Foreground = Brushes.Gray;
        }

        private void fontBlue_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Foreground = Brushes.Blue;
        }

        private void fontDarkBlue_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Foreground = Brushes.DarkBlue;
        }

        private void fontWhite_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Foreground = Brushes.White;
        }

        private void fontPurple_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Foreground = Brushes.Purple;
        }

        private void fontRed_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Foreground = Brushes.Red;
        }

        private void backgroundDarkGray_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Background = Brushes.DarkGray;
        }

        private void backgroundGray_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Background = Brushes.Gray;
        }

        private void backgroundBlue_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Background= Brushes.Blue;
        }

        private void backgroundDarkBlue_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Background = Brushes.DarkBlue;
        }

        private void backgroundWhite_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Background = Brushes.White;
        }

        private void backgroundPurple_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Background = Brushes.Purple;
        }

        private void backgroundRed_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Background = Brushes.Red;
        }
        private void dosMasterStyle_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Background = Brushes.Black;
            notepadText.Foreground = Brushes.Green;

            menu.Background = Brushes.Black;

            fileMenu.Foreground = Brushes.Green;
            edit.Foreground = Brushes.Green;
            styleButton.Foreground = Brushes.Green;
        }

        private void defaultStyle_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Background = Brushes.White;
            notepadText.Foreground = Brushes.Black;

            menu.Background = Brushes.LightGray;

            fileMenu.Foreground = Brushes.Black;
            edit.Foreground = Brushes.Black;
            styleButton.Foreground = Brushes.Black;
        }
    }
}
