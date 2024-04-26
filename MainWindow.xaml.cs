﻿using System;
using System.IO;
using System.Windows;

namespace ArrayToFile
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveToFileButton_Click(object sender, RoutedEventArgs e)
        {
            string arrayInput = ArrayInputTextBox.Text;
            string[] elements = arrayInput.Split(',');

            try
            {
                using (StreamWriter writer = new StreamWriter("array.txt"))
                {
                    foreach (string element in elements)
                    {
                        writer.WriteLine(element);
                    }
                }
                StatusMessageLabel.Content = "Масив був успішно збережений у файл.";
            }
            catch (Exception ex)
            {
                StatusMessageLabel.Content = $"Помилка збереження масиву у файл: {ex.Message}";
            }
        }
    }
}