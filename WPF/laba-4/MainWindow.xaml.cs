using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfBaldGame
{
    public partial class MainWindow : Window
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly Random _random = new Random();
        private readonly List<string> _words = new List<string>();
        private readonly HashSet<string> _usedWords = new HashSet<string>();
        private int _score;
        private char _letter;

        public MainWindow()
        {
            InitializeComponent();
            LoadWords();
        }

        private void LoadWords()
        {
            using var reader = new StreamReader("slovar.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                _words.Add(line.Trim().ToLower());
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch.Restart();
            _score = 0;
            _usedWords.Clear();
            WordsListBox.Items.Clear();
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
            WordTextBox.Focus();
            GenerateLetter();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch.Stop();
            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            WordTextBox.Clear();
            LetterTextBlock.Text = string.Empty;
            MessageBox.Show($"Game over! Your score: {_score}");
        }

        private void WordTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            var word = WordTextBox.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(word) || _usedWords.Contains(word))
            {
                WordTextBox.Clear();
                return;
            }
            if (!word.StartsWith(_letter.ToString()))
            {
                MessageBox.Show("Word must start with the given letter.");
                WordTextBox.Clear();
                return;
            }
            if (!Regex.IsMatch(word, @"^[a-z]+$"))
            {
                MessageBox.Show("Word can contain only letters.");
                WordTextBox.Clear();
                return;
            }
            if (!_words.Contains(word))
            {
                MessageBox.Show("Word not found in dictionary.");
                WordTextBox.Clear();
                return;
            }
            _usedWords.Add(word);
            WordsListBox.Items.Add(word);
            _score += word.Length;
            WordTextBox.Clear();
            GenerateLetter();
        }

        private void GenerateLetter()
        {
            _letter = (char)_random.Next('a', 'z' + 1);
            LetterTextBlock.Text = _letter.ToString().ToUpper();
        }
    }
}