using System;
using System.Linq;
using System.Security.Claims;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace pr23106_golobokovdmitry_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string inputText = InputTextBox.Text;
                if (string.IsNullOrWhiteSpace(inputText) || !Regex.IsMatch(inputText, "^[a-zA-Z\\s.,!?]+$"))
                {
                    MessageBox.Show("Пожалуйста, введите корректное предложение на английском языке.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                int vowelCount = 0;
                string vowels = "AEIOUaeiou";
                foreach (char c in inputText)
                {
                    if (vowels.Contains(c))
                    {
                        vowelCount++;
                    }
                }

                string[] words = inputText.Split(' ', '.', ',', '!', '?');
                string longestWord = "";
                foreach (string word in words)
                {
                    if (word.Length > longestWord.Length)
                    {
                        longestWord = word;
                    }
                }

                VowelCountTextBlock.Text = "Количество гласных: " + vowelCount;
                LongestWordTextBlock.Text = "Самое длинное слово: " + longestWord;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}