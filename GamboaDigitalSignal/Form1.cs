using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamboaDigitalSignal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] output = new char[100];
            int size = inputText.Text.Length;

            if (size == 0)
            {
                MessageBox.Show("Invalid Input: No input.");
            }
            if (size > 15)
            {
                MessageBox.Show("Max input is 15.");
                return;
            }
            if (FlagCounter(inputText.Text, size) == true)
            {
                MessageBox.Show("Invalid input. There are inputs that is not 0 or 1.");
                return;
            }

            for (int i=0, j=0; i < size; i++)
            {
                if (inputText.Text[i] == '0')
                {
                    if (i > 0)
                    {
                        if (inputText.Text[i - 1] == '1')
                        {
                            output[j] = '|';
                            j++;
                        }
                    }
                    output[j] = '_';
                    j++;
                   
                }
                else if(inputText.Text[i] == '1')
                {
                    if (i > 0)
                    {
                        if (inputText.Text[i - 1] == '0')
                        {
                            output[j] = '|';
                            j++;
                        }
                    }
                    output[j] = '¯';
                    j++;
                   
                }

     
            }
            outputTextBox.Text = new string(output);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char[] output = new char[100];
            int size = inputText.Text.Length;
            int flag = 0;
            if (size == 0)
            {
                MessageBox.Show("Invalid Input: No input.");
            }

            if (size > 15)
            {
                MessageBox.Show("Max input is 15.");
                return;
            }
            if (FlagCounter(inputText.Text, size) == true)
            {
                MessageBox.Show("Invalid input. There are inputs that is not 0 or 1.");
                return;
            }

            for (int i=0, j=0; i<size; i++)
            {
                if(i==0)
                {
                    if (inputText.Text[i] == '1')
                    {
                        output[j] = '¯';
                        j++;
                        flag = 1;
                    }
                    else if(inputText.Text[i] == '0')
                    {
                        output[j] = '_';
                        j++;
                    }
                }

                else if (i > 0)
                {
                    if (inputText.Text[i] == '1')
                    {
                       if(flag == 1)
                        {
                            output[j] = '|';
                            j++;
                            output[j] = '_';
                            j++;
                            flag = 0;
                        }
                       else if(flag == 0)
                        {
                            output[j] = '|';
                            j++;
                            output[j] = '¯';
                            j++;
                            flag = 1;
                        }
                    }

                    else if(inputText.Text[i] == '0')
                    {
                        if(flag == 1)
                        {
                            output[j] = '¯';
                            j++;
                        }
                        else if(flag == 0)
                        {
                            output[j] = '_';
                            j++;
                        }
                    }
                }

            }
            outputTextBox.Text = new string(output);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            char[] output = new char[100];
            int size = inputText.Text.Length;
            int flag = 0;

            if (size == 0)
            {
                MessageBox.Show("Invalid Input: No input.");
            }

            if (size>15)
            {
                MessageBox.Show("Max input is 15.");
                return;
            }

            if (FlagCounter(inputText.Text, size) == true)
            {
                MessageBox.Show("Invalid input. There are inputs that is not 0 or 1.");
                return;
            }

            for (int i = 0, j = 0; i < size; i++)
            {
                if (inputText.Text[i] == '0')
                {
                    output[j] = '–';
                    j++;
                }

                else if(inputText.Text[i] == '1')
                {
                    if (flag == 0)
                    {
                        if (i > 0) { 
                        if(inputText.Text[i-1] == '1')
                        {
                            output[j] = '|';
                            j++;
                        }
                        }
                        output[j] = '¯';
                        flag = 1;
                        j++;
                    }
                    else if(flag == 1)
                    {
                        if (i > 0)
                        {
                            if (inputText.Text[i - 1] == '1')
                            {
                                output[j] = '|';
                                j++;
                            }
                        }
                        output[j] = '_';
                        flag = 0;
                        j++;
                    }
                }
            }
            outputTextBox.Text = new string(output);
        }

        bool FlagCounter(String text, int size)
        {
            bool flag = false;
            int count1 = 0;
            int count0 = 0;
            for(int i=0; i<size; i++)
            {
                if(text[i] == '1')
                {
                    count1++;
                }
                if(text[i] == '0')
                {
                    count0++;
                }
            }

            int total = count1 + count0;
            if(size != total)
            {
                flag = true;
            }
            
            return flag;
        }
    }
}
