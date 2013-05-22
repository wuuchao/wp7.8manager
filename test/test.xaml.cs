using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using 背单词对战.model;


namespace 背单词对战.view.test
{
    public partial class test : PhoneApplicationPage
    {
        private testResult t = new testResult();
        private words w = new words();
        private int count = 0;
        private int max = 0;
        public test()
        {
            InitializeComponent();
            answer.Text = w.getAns(count);
            max = words.Count;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (word.Text != "")
            {
                t.add(word.Text, answer.Text);
                if (word.Text == w.getWords(count))
                {
                    t.setResult(count, 1);
                }
                else
                {
                    t.setResult(count, 0);
                }
                count++;
                if (max == count)
                {
                    this.NavigationService.Navigate(new Uri("/view/test/showResult.xaml", UriKind.Relative));
                }
                answer.Text = w.getAns(count);
                word.Text = "";
            }
            else
            {
                word.Text = "先输入结果吧";
            }
        }

    }
}