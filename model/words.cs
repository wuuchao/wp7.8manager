using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 背单词对战.model
{
    class words
    {
        private static String []Words = new String [200];
        private static String[] answers = new String[200];
        public static int Count = 0;

        public words()
        {
        }

        public void add(String word, String answer) {
            if (Count < 200)
            {
                Words[Count] = word;
                answers[Count] = answer;
                Count++;
            }
        }

        public void clean()
        {
            Count = 0;
        }

        public String getWords(int count)
        {
            if (count < Count) return Words[count];
            else return "exceed limit";
        }

        public String getAns(int count)
        {
            if (count < Count) return answers[count];
            else return "exceed limit";
        }
    }
}
