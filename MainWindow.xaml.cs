using System;
using System.Windows;

namespace PiT_PR3_part2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            int A, B;
            try
            {
                if (string.IsNullOrEmpty(textBoxA.Text) || string.IsNullOrEmpty(textBoxB.Text))
                    throw new Exception("Не все поля заполнены");
                A = Int32.Parse(textBoxA.Text);
                B = Int32.Parse(textBoxB.Text);
            }
            catch (Exception ex) when (ex is Exception || ex is FormatException)
            {
                MessageBox.Show(ex.Message == "Не все поля заполнены" ? ex.Message : "В полях должны быть целые числа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if ((Boolean)RadioButtonAddition.IsChecked)
                    TextBoxResult.Text = (A + B).ToString();
                else if ((Boolean)RadioButtonSubstraction.IsChecked)
                    TextBoxResult.Text = (A - B).ToString();
                else if ((Boolean)RadioButtonMultiplication.IsChecked)
                    TextBoxResult.Text = (A * B).ToString();
                else if ((Boolean)RadioButtonDivision.IsChecked)
                {
                    if (Int32.Parse(textBoxA.Text) == 0 || Int32.Parse(textBoxB.Text) == 0)
                        throw new DivideByZeroException("Деление на ноль");
                    TextBoxResult.Text = (A / B).ToString();
                }
                else
                    throw new Exception("Не выбрана операция");
            }
            catch(Exception ex) when (ex is Exception || ex is DivideByZeroException)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
