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

namespace postfixCalculator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            string answer = EvalutatePostFix().ToString();
            TxtAnswer.Text = answer;
        }

        private double EvalutatePostFix() {
            lstOperation.Items.Clear();
            Stack postFixStack = new Stack();
            postFixStack.Clear();
            string expression = TxtNumber1.Text;
            string tempnum = " ";
            double tempAnswer = 0;
            string tempString = " ";
            

            foreach (char token in expression) {
                if (token == ' '){
                    if(tempnum == "") {

                    } else {
                        postFixStack.Push(tempnum);
                        tempString = "After push operation: ";
                        tempString += postFixStack.ToString();
                        lstOperation.Items.Add(tempString);
                        tempnum = " ";
                    }
                    
                } else if(token == '+' || token == '-' || token == '/' || token == '*') {
                    if(token == '+') {
                        double num1 = double.Parse(postFixStack.Pop().ToString());
                        double num2 = double.Parse(postFixStack.Pop().ToString());
                        tempAnswer = num2 + num1;
                        tempString = "After + operation: ";
                    } else if(token == '-') {
                        double num1 = double.Parse(postFixStack.Pop().ToString());
                        double num2 = double.Parse(postFixStack.Pop().ToString());
                        tempAnswer = num2 - num1;
                        tempString = "After - operation: ";
                    } else if(token == '/') {
                        double num1 = double.Parse(postFixStack.Pop().ToString());
                        double num2 = double.Parse(postFixStack.Pop().ToString());
                        tempAnswer = num2 / num1;
                        tempString = "After / operation: ";
                    } else if (token == '*') {
                        double num1 = double.Parse(postFixStack.Pop().ToString());
                        double num2 = double.Parse(postFixStack.Pop().ToString());
                        tempAnswer = num2 * num1;
                        tempString = "After * operation: ";
                    }
                    tempnum = tempAnswer.ToString();
                    postFixStack.Push(tempnum);
                    tempnum = "";
                    tempString += postFixStack.ToString();
                    lstOperation.Items.Add(tempString);
                } else tempnum += token;
            }

            double answer = double.Parse(postFixStack.Pop().ToString());

            return answer;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}
