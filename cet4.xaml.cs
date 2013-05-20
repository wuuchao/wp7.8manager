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

namespace 背单词对战.listWords
{
    public partial class cet4 : PhoneApplicationPage
    {
        private int count = 0;
        private int max = 0;
        private words list = new words();
        public cet4()
        {
            InitializeComponent();
            word.Text = list.getWords(0);
            answer.Opacity = 0;
        }

        private void result_Click(object sender, RoutedEventArgs e)
        {
            answer.Opacity = 100;
            answer.Text = list.getAns(count);
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            answer.Opacity = 0;
            count++;
            word.Text = list.getWords(count);
            if (word.Text == "exceed limit")
            {
                this.NavigationService.Navigate(new Uri("/view/test/test.xaml", UriKind.Relative));
            }
        }

    }
}