
//Author: Nehan Hossain
//Date created: September 24, 2024
//Date last modified : September 27, 2024
// Project: assignment 1
// Description:This file contains all the C# code for COSC-2100_assignment1

using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace COSC_2100_assingment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter = 0; 
        private List<int> numbers = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            string theInput = input.Text;
            int number = Validation(theInput); 

            if (number >= 0)
            {
                counter++;
                float average = Calculation(number);
                seconderyOutput.Text = "messages per day: " + average.ToString();
                mainOutput.Text += number + Environment.NewLine; 
                day.Content = "Day " + counter.ToString();
                input.Clear();

                if (counter == 7)
                {
                    enter.IsEnabled = false;
                    return;
                }
            }
        }

        private static int Validation(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter a valid input.");
            }
            else if (!int.TryParse(input, out int result))
            {
                MessageBox.Show("Please enter a whole number.");
            }
            else if (result >= 1000)
            {
                MessageBox.Show("Please enter an input that is below 1000.");
            }
            else if (result < 0)
            {
                MessageBox.Show("please enter possitive number.");
            }
            else
            {
                return result;
            }
            return -1;
        }

        private float Calculation(int theNumber)
        {
            
            numbers.Add(theNumber);
            if (numbers.Count == 0)
            {
                return (float)theNumber; 
            }
            else
            {
                return (float)numbers.Average(); 
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            numbers.Clear();
            input.Clear();
            seconderyOutput.Clear();
            mainOutput.Clear();
            counter = 0; 
            day.Content = "Day 0"; 
            enter.IsEnabled = true; 
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}