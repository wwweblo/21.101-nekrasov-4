using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
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

namespace var1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_btn_Click(object sender, RoutedEventArgs e)
        {

            string input = input_num.Text;

            if (!AntiRus(input))
            {
                string output = ConvertInput(input);

                input = Regex.Replace(input, @"  +", " [это_пробел] ");

                MessageBox.Show(output);
            }
            else
            {
                MessageBox.Show("Введите предложение на английском");
            }
        }
        public static bool AntiRus(string str)
        {
            // Создать регулярное выражение для поиска русских букв
            string regex = @"[а-яА-ЯёЁ]";

            // Проверить, соответствует ли строка регулярному выражению
            return Regex.IsMatch(str, regex);
        }

        private string ConvertInput(string input)
        {

            try
            {
                // Преобразовать все буквы в верхний регистр
                input = input.ToUpper();

                // Разделить строку на слова
                string[] words = input.Split(" ");

                // Преобразовать первое и последнее буквы каждого слова в заглавную
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length <= 2)
                    {
                        words[i] = words[i].ToUpper();
                    }
                    else
                    {
                        words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1, words[i].Length - 2).ToLower() + words[i].Substring(words[i].Length -  1).ToUpper();
                    }
                }

                // Объединить слова в строку
                input = string.Join(" ", words);

                return input;
            }
            catch
            {
                return "Ошбочка вышла";
            }
        }
    }
}
