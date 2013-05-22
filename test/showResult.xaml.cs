using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using 背单词对战.model;

namespace 背单词对战.view.test
{
    public partial class showResult : PhoneApplicationPage
    {
        private static int correct = 0;
        private static int loss = 0;
        public static string name1;
        public showResult()
        {
            InitializeComponent();
            words w = new words();
            testResult t = new testResult();
            for (int i = 0; i < words.Count; i++)
            {
                Run run = new Run();
                SolidColorBrush solidBrush = new SolidColorBrush();
                run.Text = w.getWords(i) + w.getAns(i);
                solidBrush.Color = Colors.Brown;
                run.Foreground = solidBrush;
                Paragraph myPa = new Paragraph();
                myPa.Inlines.Add(run);
                Run run1 = new Run();
                myPa.Inlines.Add(run1);
                ans.Blocks.Add(myPa);
            }
            for (int i = 0; i < words.Count; i++)
            {
                Run run = new Run();
                SolidColorBrush solidBrush = new SolidColorBrush();
                run.Text = t.getWords(i) + t.getAns(i);
                if (t.getWords(i) == w.getWords(i))
                {
                    solidBrush.Color = Colors.Green;
                    correct++;
                }
                else
                {
                    solidBrush.Color = Colors.Red;
                    loss++;
                }
                run.Foreground = solidBrush;
                Paragraph myPa = new Paragraph();
                myPa.Inlines.Add(run);
                Run run1 = new Run();
                myPa.Inlines.Add(run1);
                ans1.Blocks.Add(myPa);
            }
            result.Text = "正确："+correct+"   "+"错误："+loss;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            name1 = name.Text;
            this.NavigationService.Navigate(new Uri("/view/takeToRanks.xaml", UriKind.Relative));
        }
    }
}