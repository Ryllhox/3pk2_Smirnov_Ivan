using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pz_008_winforms
{
    public partial class Form1 : Form
    {
        private Font currentFont;
        private string currentFileName;
        public Form1()
        {
            InitializeComponent();
            currentFont = personText.Font;
            currentFileName = "";
        }

        private void changeFontSize(int size)
        {
            currentFont = new Font(currentFont.FontFamily, size, currentFont.Style);
            personText.Font = currentFont;
        }
        private void changeFontStyle(FontStyle style)
        {
            currentFont = new Font(currentFont.FontFamily, currentFont.Size, style);
            personText.Font = currentFont;
        }

        private void saveFile(string fileName)
        {
            if (fileName == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                }
                else return;
            }
            File.WriteAllText(fileName, personText.Text);
            currentFileName = fileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFile(currentFileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFile("");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentFont.Style.HasFlag(FontStyle.Bold))
            {
                changeFontStyle(currentFont.Style & ~FontStyle.Bold);
            }
            else
            {
                changeFontStyle(currentFont.Style | FontStyle.Bold);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentFont.Style.HasFlag(FontStyle.Italic))
            {
                changeFontStyle(currentFont.Style & ~FontStyle.Italic);
            }
            else
            {
                changeFontStyle(currentFont.Style | FontStyle.Italic);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (currentFont.Style.HasFlag(FontStyle.Underline))
            {
                changeFontStyle(currentFont.Style & ~FontStyle.Underline);
            }
            else
            {
                changeFontStyle(currentFont.Style | FontStyle.Underline);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            changeFontSize((int)(currentFont.Size + 2));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            changeFontSize((int)(currentFont.Size - 2));
        }
    }
}
