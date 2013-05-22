using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using 背单词对战.model;
using System.Windows.Resources;

namespace 背单词对战.model
{
    class transDOC
    {
        public static string str = "null";
        private int count = 0;
        private words w = new words();

        public void transDoc()
        {
            //str = "price 价格 ambulance 救护车";
            storeToWords();
        }

        public void storeToWords()
        {
            int coun = 0;
            int len = str.Length;
            while (coun < len)
            {
                string tempWord = null;
                string tempAns = null;
                count = 0;
                while (count < 2)
                {
                    if (coun < len)
                    {
                        if (str[coun] == ' ') count++;
                        else
                        {
                            if (count == 0)
                                tempWord += str[coun];
                            else tempAns += str[coun];
                        }
                    }
                    coun++;
                    if (coun == len) break;
                }
                w.add(tempWord, tempAns);
            }
        }
    }
}
