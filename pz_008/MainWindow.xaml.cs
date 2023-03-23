using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace pz_008
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Font currentFont;
        private string currentFileName;
        public MainWindow()
        {
            InitializeComponent();
            currentFont = personText.Font;
            currentFileName = "fromNotepad";
        }

        private void changeFontSize (int size)
        {
            currentFont = new Font(currentFont.FontFamily, size, currentFont.Style);
            personText.Font = currentFont;
        }
        private void changeFontStyle(FontStyle style)
        {
            currentFont = new Font(currentFont.FontFamily, currentFont.Size, style);
            personText.Font = currentFont;
        }

        private void saveFile (string fileName)
        {
            if (fileName == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                SaveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = SaveFileDialog.FileName;
                }
                else return;
            }
            File.WriteAllText(fileName, personText.Text);
            currentFileName = fileName;
        }

        private void btnSizePlus_Click(object sender, RoutedEventArgs e)
        {
            changeFontSize((int)(currentFont.Size + 2));
        }

        private void btnSizeMinus_Click(object sender, RoutedEventArgs e)
        {
            changeFontSize((int)(currentFont.Size - 2));
        }

        private void btnBold_Click(object sender, RoutedEventArgs e)
        {
            if (currentFont.Style.HasFlag(FontStyle.Bold))
            {
                changeFontStyle(currentFont.Style && ~FontStyle.Bold);
            }    
            else
            {
                changeFontStyle(currentFont.Style || FontStyle.Bold);
            }
        }

        private void btnItalic_Click(object sender, RoutedEventArgs e)
        {
            if (currentFont.Style.HasFlag(FontStyle.Italic))
            {
                changeFontStyle(currentFont.Style && ~FontStyle.Italic);
            }
            else
            {
                changeFontStyle(currentFont.Style || FontStyle.Italic);
            }
        }

        private void btnUnderlined_Click(object sender, RoutedEventArgs e)
        {
            if (currentFont.Style.HasFlag(FontStyle.Underline))
            {
                changeFontStyle(currentFont.Style && ~FontStyle.Underline);
            }
            else
            {
                changeFontStyle(currentFont.Style || FontStyle.Underline);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            saveFile(currentFileName);
        }

        private void btnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            saveFile("");
        }
    }
}
