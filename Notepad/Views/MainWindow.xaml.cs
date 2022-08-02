using Microsoft.Win32;
using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool doesFileExist = false;
        private string fileName = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            this.notepadText.Clear();
            this.notepadText.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;

            DataContext = new MainViewModel();
        }

        private void lineMeterMethod()
        {
            /*this.lineMeter.Inlines.Clear();

            for (int i = 1; i >= this.notepadText.LineCount; i++)
                this.lineMeter.Inlines.Add(this.notepadText.LineCount.ToString() + ".");*/
        }

        private void fileMenu_Click(object sender, RoutedEventArgs e)
        {
            fileContextMenu.IsOpen = true;
        }

        private void saveFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";

                sfd.ShowDialog();

                if (sfd.FileName != String.Empty)
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        string noteText = notepadText.Text;

                        sw.Write(noteText);

                        sw.Close();
                        fs.Close();
                    }

                    doesFileExist = true;
                    fileName = sfd.FileName;

                    this.Title = sfd.Title;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!doesFileExist) saveFile_Click(null, null);

                else
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        string noteText = notepadText.Text;

                        sw.Write(noteText);

                        sw.Close();
                        fs.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string noteText = notepadText.Text;
                string textFile = string.Empty;

                if (fileName != string.Empty)
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        textFile = sw.ToString();

                        sw.Close();
                        fs.Close();
                    }
                }

                if ((!doesFileExist) || (noteText != textFile))
                {
                    string messageBoxText = "Do you want to save changes?";
                    string caption = "You can loose your progress!";
                    MessageBoxButton button = MessageBoxButton.YesNoCancel;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

                    if (result == MessageBoxResult.Yes)
                    {
                        saveFile_Click(null, null);
                        this.Close();
                    }

                    else if (result == MessageBoxResult.No) this.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow nextWindow = new MainWindow();
            nextWindow.Show();
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string noteText = notepadText.Text;

                if (noteText != String.Empty)
                {
                    string messageBoxText = "Do you want to save changes before opening file?";
                    string caption = "You can loose your progress!";
                    MessageBoxButton button = MessageBoxButton.YesNoCancel;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

                    if (result == MessageBoxResult.Yes)
                    {
                        this.saveFile_Click(null, null);
                        this.openFileDialogProcedure();
                    }

                    else if (result == MessageBoxResult.No) openFileDialogProcedure();
                }

                else openFileDialogProcedure();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openFileDialogProcedure()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            openFileDialog.Title = "Choose a file";
            openFileDialog.ShowDialog();

            this.Title = openFileDialog.FileName;

            FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            try
            {

                if (openFileDialog.FileName != String.Empty)
                {
                    notepadText.Clear();
                    notepadText.Text = sr.ReadToEnd();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                if (fs != null)
                {
                    sr.Close();
                    fs.Close();
                }
            }

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            this.editContextMenu.IsOpen = true;
        }

        private void styleButton_Click(object sender, RoutedEventArgs e)
        {
            this.styleContextMenu.IsOpen = true;

            if (notepadText.Text == String.Empty) undoText.Cursor = Cursors.Hand;
        }

        private void lineWrapping_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)lineWrapping.IsChecked)
            {
                notepadText.TextWrapping = TextWrapping.Wrap;
                notepadText.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }

            else
            {
                notepadText.TextWrapping = TextWrapping.NoWrap;
                notepadText.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            }
        }

        private void magFontSize_Click(object sender, RoutedEventArgs e)
        {
            this.notepadText.FontSize += 2;
            this.lineMeter.FontSize += 2;

        }

        private void redFontSize_Click(object sender, RoutedEventArgs e)
        {
            if (this.notepadText.FontSize > 5) this.notepadText.FontSize -= 2;
            if (this.lineMeter.FontSize > 5) this.lineMeter.FontSize -= 2;
        }

        private void restoreFontSize_Click(object sender, RoutedEventArgs e)
        {
            this.notepadText.FontSize = 15;
            this.lineMeter.FontSize = 15;
        }

        private void undoText_Click(object sender, RoutedEventArgs e)
        {
            this.notepadText.Undo();
        }

        private void copyText_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(notepadText.SelectedText);
        }

        private void pasteText_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Paste();
        }

        private void cutText_Click(object sender, RoutedEventArgs e)
        {
            notepadText.Cut();
        }

        private void KeyDown_Event(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.N) && Keyboard.IsKeyDown(Key.LeftCtrl)
                && (Keyboard.IsKeyDown(Key.LeftShift))) MenuItem_Click(null, null);

            else if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.S))
                save_Click(null, null);

            else if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftShift)
                && Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.S))
                saveFile_Click(null, null);

            else if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.O))
                open_Click(null, null);

            this.lineMeterMethod();
        }

        private void lineMeterOnOff_Click(object sender, RoutedEventArgs e)
        {
            if (lineMeterOnOff.IsChecked)
            {
                lineMeter.Visibility = Visibility.Visible;
                notepadText.SetValue(Grid.ColumnSpanProperty, 1);
            }

            else
            {
                lineMeter.Visibility = Visibility.Hidden;
                notepadText.SetValue(Grid.ColumnSpanProperty, 2);
            }
        }
    }
}