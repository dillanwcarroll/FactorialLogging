using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Factorialiser.Classes;

namespace Factorialiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NLog.Logger nlogger = NLog.LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoad;
            Closed += OnClosed;
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            
            nlogger.Trace("Main Window Loaded");
        }

        private void OnClosed(object sender, EventArgs e)
        {
            nlogger.Trace("Main Window Closed");
        }

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // check if textboxInput.Text is empty (or only contains white space), 
                // if this is the case then throw a NullValueException
                if (String.IsNullOrWhiteSpace(textBoxInput.Text))throw new NullValueException();

                //declare a variable here called input or datatype int
                int input;

                try
                {
                    // try and parse the text input into textboxInput into an integer and assign it to input
                    // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: input successfully parsed"
                    input = int.Parse(textBoxInput.Text);
                    nlogger.Debug("MainForm.buttonCalculate_Click: input successfully parsed");
                }
                catch
                {
                    // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: input parse failed"
                    // throw a NotIntegerException 
                    nlogger.Debug("MainForm.buttonCalculate_Click: input parse failed");
                    throw new NotIntegerException(textBoxInput.Text);
                }

                // pass the input to the Calculator.Factorial method and store the retuen value in a variable
                // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: Calculate.Factorial suceeded"
                // change the text of labelOutput to reflect
                // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: labelOutput successfully updated"

                int fac = Calculator.Factorial(input);
                nlogger.Debug("MainForm.buttonCalculate_Click: Calculate.Factorial suceeded");
                labelOutput.Content = fac;
                nlogger.Debug("MainForm.buttonCalculate_Click: labelOutput successfully updated");

            }
            catch (NullValueException)
            {
                // clear the labelOutput text and the textboxInput.Text
                // present a message box saying ("Nothing Entered - Please enter an integer")
                // log the event as an Error Level log 
                // with the message "MainForm.buttonCalculate_Click: NullValueException message displayed"

                labelOutput.Content = "";
                textBoxInput.Text = "";
                MessageBox.Show("Nothing Entered - Please enter an integer");
                nlogger.Error("MainForm.buttonCalculate_Click: NullValueException message displayed");

            }

            // ###########
            // add additional catches here, one for each of your custom exception types, in each one
            // clear the labelOutput text and the textboxInput.Text
            // display an approprate message box message and log the event as an Error level
            // using the same format as used in the NullValueException catch
            // ##########

            catch (NumberTooHighException)
            {
                labelOutput.Content = "";
                textBoxInput.Text = "";
                MessageBox.Show("Number entered is too high");
                nlogger.Error("MainForm.buttonCalculate_Click: NumberTooHighException message displayed");
            }

            catch (NumberTooLowException)
            {
                labelOutput.Content = "";
                textBoxInput.Text = "";
                MessageBox.Show("Number entered is too low");
                nlogger.Error("MainForm.buttonCalculate_Click: NumberTooLowException message displayed");
            }

            catch (NotIntegerException)
            {
                labelOutput.Content = "";
                textBoxInput.Text = "";
                MessageBox.Show("Number entered is not an integer");
                nlogger.Error("MainForm.buttonCalculate_Click: NotIntegerException message displayed");
            }

            catch (Exception ex)
            {
                // clear the labelOutput text and the textboxInput.Text
                // present a message box saying ("Unknown Error")
                // log the event as an Fatal Level log 
                // with the message ("MainForm.buttonCalculate_Click: Unknown Error : " + ex.message)

                labelOutput.Content = "";
                textBoxInput.Text = "";
                MessageBox.Show("Unknown Error");
                nlogger.Fatal("MainForm.buttonCalculate_Click: Unknown Error : " + ex.Message);
            }


        }
    }
}
