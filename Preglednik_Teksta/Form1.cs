using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Preglednik_Teksta
{
    public partial class Form1 : Form
    {

        public bool fileOpened = false;

        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;

                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        textBox2.Text = fileContent;
                        textBox1.Text = filePath;
                        fileOpened = true;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox4.Text;
            string path = textBox3.Text + "\\" + name +".txt";
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(textBox2.Text);
                }
            }
            else
            { 
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(textBox2.Text);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string d = "";
            string content = textBox2.Text;
            for (int i = 0; i < content.Length; i++)
            {
                d += content.ElementAt(i).ToString().ToUpper();  
            }
            textBox2.Text = d;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string d = "";
            string content = textBox2.Text;
            for (int i = 0; i < content.Length; i++)
            {
                d += content.ElementAt(i).ToString().ToLower();
            }
            textBox2.Text = d;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            fontDialog1.Font = textBox2.Font;
            fontDialog1.Color = textBox2.ForeColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                textBox2.Font = fontDialog1.Font;
                textBox2.ForeColor = fontDialog1.Color;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.TextAlign = HorizontalAlignment.Left;
            radioButton2.Checked = false;
            radioButton3.Checked = false;  
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.TextAlign = HorizontalAlignment.Center;
            radioButton1.Checked = false;
            radioButton3.Checked = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.TextAlign = HorizontalAlignment.Right;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
    }
}
