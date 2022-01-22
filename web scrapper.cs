using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;


namespace web_scrapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            

                //Use webClient to download content from website and put into text box
                var strpage = string.Empty;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (WebClient Client = new WebClient())
                {
                    strpage = Client.DownloadString(txt1.Text);
                }

                TEXT.Text = strpage;

            
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            TEXT.Clear();
        }

        private void btn_count_Click(object sender, EventArgs e)
        {  //create array to separate the words in the textbox
            string allWords = TEXT.Text;
            string[] wordsArray = allWords.Split(' ', ',', '.', '!', '=');
            //change the array into a list
            //create word_counter class to count
            List<word_counter> wordCounters = new List<word_counter>();

            foreach (string w in wordsArray)
            {
                word_counter foundWord = wordCounters.Find(x => x.word == w);
                if (foundWord == null)
                {   //the word is not in the list, add it
                    wordCounters.Add(new word_counter(w, 1));
                }
                else
                {   //the word is found in the list increment the frequency
                    foundWord.frequency++;
                }
            }

            listView1.Columns.Add("frequency", 70);
            listView1.Columns.Add("Word", 100);
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Sorting = SortOrder.Descending;


            foreach (word_counter word in wordCounters)
            {
                string[] rowItem = new string[] { word.frequency.ToString("D5"), word.word };
                listView1.Items.Add(new ListViewItem(rowItem));

            }
        }

        private void searchbox_Click(object sender, EventArgs e)
        {

            // Call FindItemWithText with the contents of the textbox.
            ListViewItem foundItem = listView1.FindItemWithText(txtsearch.Text, true, 0, false);
            if (foundItem != null)
            {
                listView1.TopItem = foundItem;
                foundItem.BackColor = Color.LightSteelBlue;
            }
            else
            {
                MessageBox.Show("word not found");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {// load the text file to text box 
            StringBuilder sb = new StringBuilder();

            using (StreamReader sr = new StreamReader(@"C:\Users\sir\My Documents\Visual Studio 2012\projects\web scrapper\Oxford English Dictionary.txt"))
            {                             
                              
                while (sr.Peek() >= 0)
                
                {
                sb.Append(sr.ReadLine());
                
                }
            }
            textBox1.Text = sb.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nonEnglish = string.Empty;

            // Get words that are different in TEXT compared to textBox1
            foreach (string change in CompareStrings(TEXT.Text, textBox1.Text))
            {
                nonEnglish += "" + change;
            }


            txt_noneng.Text = "Words Not In the Dictionary:\n" + nonEnglish;
           
            }

        private IEnumerable<string> CompareStrings(string p1, string p2)
        {
                IEnumerable<string> set1 = p1.Split(' ').Distinct();
                IEnumerable<string> set2 = p2.Split(' ').Distinct();

                // Compare and return the Difference
                 return set1.Except(set2).ToList();

        }

        

       
        }


        }
     



      



