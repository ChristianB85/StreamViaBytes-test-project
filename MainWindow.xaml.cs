﻿using System.Windows;
using System.IO;
using System.Text;


namespace PatientenAkten
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string DIR_PATH = @"C:\Users\dynar\OneDrive\Desktop\UDemy\PatientenAkten\PatientenAkten\files\";
        public const string FILE_ENDING = ".txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string content = textBoxContent.Text;
            string filename = textBoxFileName.Text;
            

            using (FileStream fs = File.Create(DIR_PATH + @"\" + filename + FILE_ENDING))
            {
                byte[] contentConvertedToByte = Encoding.ASCII.GetBytes(content);
                fs.Write(contentConvertedToByte, 0, contentConvertedToByte.Length);
            }

            MessageBox.Show("Datei wurde angelegt.");
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            string filename = textBoxFileName.Text;
            
            using (FileStream fs = File.OpenRead(DIR_PATH + @"\" + filename + FILE_ENDING))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();
                    textBoxContent.Text = content;
                }
            }
        }
    }
}