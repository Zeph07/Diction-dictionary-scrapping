using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_scrapper
{
    class word_counter
    {
        public string word { get; set; }
        public int frequency { get; set; }

        public word_counter(string word, int frequency)
        {
            this.word = word;
            this.frequency = frequency;
        }
    }
}
