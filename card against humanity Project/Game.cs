//Pr0metheus 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;
namespace card_against_humanity_Project
{
    public partial class Game : Form
    {
        int count,findex,sindex,p1,p2,p3 = 0;
        List<string> lest = new List<string>();
        Random rnd = new Random();
        public Game()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        private void Game_Load(object sender, EventArgs e)
        {
            pictureBox4.Hide();
            //References

            /*In computer science and mathematics,
             the Josephus problem (or Josephus permutation) is a theoretical problem related to a certain counting-out game.
             The problem — given the number of people, starting point, direction, and number to be skipped 
             — is to choose the position in the initial circle to avoid execution. */
            pictureBox1.Image = Properties.Resources.Josephus;

            /*Kurt Godel was an Austro-Hungarian-born Austrian logician, mathematician, and analytic philosopher. */
            pictureBox2.Image = Properties.Resources.Kurt;

            /*was an English polymath. A mathematician, philosopher, inventor and mechanical engineer, 
            Babbage originated the concept of a digital programmable computer.*/
            pictureBox3.Image = Properties.Resources.Charles;

            List<string> ls = new List<string>();
            //Take Lines From text file found in Properties.Resources. can be processed using foreach  
            var Whiteklines = Properties.Resources.WhiteSen.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var Blacklines = Properties.Resources.BlackSen.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            BlackCard(Blacklines);
            /*for testing text file 
            Console.WriteLine((lines[0]));
            Console.ReadLine(); */
            addCards(Whiteklines, 15,ls);
        }
        //set random question from text file 
        private void BlackCard(string[] lines){
            button1.Text = lines[rnd.Next(0,lines.Length)];
        }        
        //Method that takes white cards and number of cards to be used as input and adds them to the listbox
        private void addCards(String[] whiteboi, int n,List<String> ls)
        {
            for (int i = 0; i < n; i++)
            {
                String str = whiteboi[rnd.Next(0, whiteboi.Length)];
                ls.Add(str);
                listBox1.Items.Add(str.ToString());              

                listBox1.HorizontalScrollbar = true;
                
                //Refresh text
                listBox1.Hide();
                listBox1.Show();
            }           
        }
        private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             String[] whiteboi = Properties.Resources.WhiteSen.Split(new[] { Environment.NewLine }, StringSplitOptions.None); 
            //Find index and value of selected item 
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                //Print, remove selected item and add new one at removed index 
                MessageBox.Show(listBox1.SelectedItem.ToString());
                //Add selected item to list so that it can be used in new listbox 
                lest.Add(listBox1.SelectedItem.ToString());
                count++;

                //Remove selected item 
                listBox1.Items.RemoveAt(index);

                if (count == 1)
                {
                    findex = index;
                }

                else if(count == 2)
                {
                    sindex = index;
                }

                if (count == 3)
                {
                    ///Insert new items 
                    listBox1.Items.Insert(index, whiteboi[rnd.Next(0, whiteboi.Length)]);
                    listBox1.Items.Insert(findex, whiteboi[rnd.Next(0, whiteboi.Length)]);
                    listBox1.Items.Insert(sindex, whiteboi[rnd.Next(0, whiteboi.Length)]);

                    //Hide listbox1 
                    listBox1.Hide();

                    ///add items to answer list box and show list box 
                    for (int i = 0; i < count; i++)
                    {
                        listBox2.Items.Add(lest[i]);
                    }
                    
                    //reset values 
                    lest.Clear();
                    count = 0;
                    findex = 0;
                    sindex = 0;
                    listBox2.Show();
                }
            }
        }
        private void ListBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String[] whiteboi = Properties.Resources.WhiteSen.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            //Find index and value of selected item 
            int index = this.listBox2.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                //Check if someone won the game
                if (p1 == 2)
                {                    
                    pictureBox4.Show();
                    pictureBox4.Image = Properties.Resources.meme1;                    
                }
                else if (p2 == 2)
                {                    
                    pictureBox4.Show();
                    pictureBox4.Image = Properties.Resources.meme2;                    
                }
                else if (p3 == 2)
                {                    
                    pictureBox4.Show();
                    pictureBox4.Image = Properties.Resources.meme3;                    
                }

                //Check which value was selected and add points to player  
                if (index == 0)
                {
                    p1++;
                }

                if (index == 1)
                {
                    p2++;
                }

                if (index == 2)
                {
                    p3++;
                }
            }
            //Reset values and add to point counter
            button2.Text = "Player 1: " + p1;
            button3.Text = "Player 2: " + p2;
            button4.Text = "Player 3: " + p3;
            //move to next round 
            listBox2.Items.Clear();
            listBox2.Hide();
            listBox1.Show();
            if (p1 !=  3 && p2 != 3 && p3 != 3)
            {
                var Blacklines = Properties.Resources.BlackSen.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                button1.Text = Blacklines[rnd.Next(0, Blacklines.Length)];
            }
            else
            {
                button1.Text = "Winner";
            }            
        }
    }
}