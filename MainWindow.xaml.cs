
//Author: Nehan Hossain
//Date created: September 24, 2024
//Date last modified : September 30, 2024
// Project: assignment 1
// Description:This file contains all the C# code for COSC-2100_assignment1

//inports
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

//namesspace
namespace COSC_2100_assingment1
{
    public partial class MainWindow : Window
    {
        //Counter that counts up after enter is clicked
        int counter = 0; 

        //contaner for all the numbers inputed
        private List<int> numbers = new List<int>();


        //genarates main window
        public MainWindow()
        {
            InitializeComponent();
        }

        //fungction for enter button 
        private void enter_Click(object sender, RoutedEventArgs e)
        {
            //takes the input cnd checks if everything it is valid
            string theInput = input.Text;
            int number = Validation(theInput); 

            //if number is above or equel to zero it adds to the counter and list while displayng all the information
            if (number >= 0)
            {
                counter++;
                numbers.Add(number);
                mainOutput.Text += number + Environment.NewLine;

                if (counter == 7)
                {
                    day.Content = " ";
                }
                else {
                    day.Content = "Day " + (counter + 1).ToString();
                }

                //makes shure that the input text box is clear
                input.Clear();


                //if the counter reaches 7 it calculates and displays the avrage of all the numbers and disabels the enter button
                if (counter == 7)
                {
                    float average = (float)numbers.Average();
                    seconderyOutput.Text = "Avrage messages per day: " + average.ToString();
                    enter.IsEnabled = false;
                    return;
                }
            }

        }

        //Checks if the number is a positive whole number below or equal to 1000
        private static int Validation(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please dont leave the input empty.");
            }
            else if (!int.TryParse(input, out int result))
            {
                MessageBox.Show("Please enter a possitive whole number.");
            }
            else if (result > 1000)
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

        // clears numbers, input, secondaryOutput and primaryOutput sets counter to zero sets day to zero and enabals enter button
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            numbers.Clear();
            input.Clear();
            seconderyOutput.Clear();
            mainOutput.Clear();
            counter = 0; 
            day.Content = "Day 1"; 
            enter.IsEnabled = true; 
        }

        //exit botton, exits program
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}