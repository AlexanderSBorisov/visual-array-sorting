using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Sorting
{

    public partial class Form1 : Form
    {

        public static class Globals
        {
            public static int arraySize = 250;
            public static int frameSize = 4;
            public static int timeout = 10;
            public static Thread MathThread;

        }

        public class SortView
        {

            PictureBox[] picArray;
            //Here we place pictureboxes with heights mapped to math array.
            public void ViewInit(Form form, SortStore store)
            {
                picArray = new PictureBox[Globals.arraySize];
                SortStore s = store;
                for (int i = 0; i < s.Array.Length; i++)
                {
                    picArray[i] = new PictureBox();
                    picArray[i].Size = new Size(Globals.frameSize, s.Array[i]);
                    picArray[i].BackColor = Color.FromArgb(0, 0, 0);
                    picArray[i].Visible = true;
                    picArray[i].Location = new Point(i * Globals.frameSize, 20);
                    picArray[i].Name = i.ToString();
                    form.Controls.Add(picArray[i]);
                    form.Update();
                }

            }

            //here we handle our observable - store class, witch is modified by math class
            //hadling is all in changing the colour and size of pictureboxes
            //This metod is for SET animation
            public void ViewUpdate(int value, int index)
            {
                //invoke GUI thread action to update picturebox with new value
                picArray[index].Invoke((Action)(() =>
                {
                    picArray[index].Size = new Size(Globals.frameSize + 1, value);
                    //Blink
                    picArray[index].BackColor = Color.FromArgb(255, 0, 0); 
                    picArray[index].Update();
                }));

                //Sleep on math thread
                //This simulates blink
                Thread.Sleep(Globals.timeout);

                picArray[index].Invoke((Action)(() =>
                {
                    picArray[index].Size = new Size(Globals.frameSize, value);
                    picArray[index].BackColor = Color.FromArgb(0, 0, 0);
                    picArray[index].Update();
                }));
            }

            //This metod is for GET animation
            public void ViewUpdate(int index)
            {
                picArray[index].Invoke((Action)(() =>
                {
                    picArray[index].Size = new Size(Globals.frameSize + 1, picArray[index].Height);
                    picArray[index].BackColor = Color.FromArgb(0, 255, 0);
                    picArray[index].Update();
                }));

                Thread.Sleep(Globals.timeout);

                picArray[index].Invoke((Action)(() =>
                {
                    picArray[index].Size = new Size(Globals.frameSize, picArray[index].Height);
                    picArray[index].BackColor = Color.FromArgb(0, 0, 0);
                    picArray[index].Update();
                }));
            }


        }


        public class SortStore
        {
            public int[] Array;
            public event Action<int, int> ValueChanged;
            public event Action<int> ValueAccessed;

            //initialize array of random numbers
            public void StoreInit()
            {
                Array = new int[Globals.arraySize];
                //Fill array with numbers
                for (int i = 0; i < Array.Length; i++)
                {
                    Array[i] = i;
                }
                //Randomize array with Knuth alghoritm
                Random rand = new Random();
                for (var i = 0; i < Array.Length; i++)
                {
                    int r = i + (int)(rand.NextDouble() * (Array.Length - i));
                    int t = Array[r];
                    Array[r] = Array[i];
                    Array[i] = t;
                }
            }

            //it was impossible to implement setter for array using its index, so I used indexer on class
            public int this[int index]
            {
                get
                {
                    //Blink green on reads
                    ValueAccessed(index);
                    return Array[index];

                }
                set
                {
                    //Blink red om writes and display results
                    Array[index] = value;
                    ValueChanged(value, index);
                }
            }


        }

        public class SortMath
        {

            //Given "s" as array object, we simply need to sort it without thinking about view logic
            //There is some conventions:
            //Must use .Array.Lenght if we need array lenght.
            //Also you cannot use array-specific code such as CopyTo, you have only indexes and values. Implement specfic code manaually.
            //Or implement array methods in SortStore class.
            public void BubbleSort(SortStore s)
            {

                int buffer = 0;
                for (int m = 0; m <= s.Array.Length - 2; m++)
                {
                    for (int i = 0; i <= s.Array.Length - 2; i++)
                    {
                        if (s[i] > s[i + 1])
                        {
                            buffer = s[i + 1];
                            s[i + 1] = s[i];
                            s[i] = buffer;
                        }
                    }
                }
            }

            public void LooksLikeBubbleSort(SortStore s)
            {

                int buffer = 0;
                for (int m = 0; m <= s.Array.Length - 2; m++)
                {
                    for (int i = m + 1; i <= s.Array.Length - 2; i++)
                    {
                        if (s[m] > s[i])
                        {
                            buffer = s[m];
                            s[m] = s[i];
                            s[i] = buffer;

                        }

                    }
                }

            }


            public void InsertionSort(SortStore s)
            {

                for (int i = 0; i < s.Array.Length - 1; i++)
                {
                    int j = i + 1;

                    while (j > 0)
                    {
                        if (s[j - 1] > s[j])
                        {
                            int temp = s[j - 1];
                            s[j - 1] = s[j];
                            s[j] = temp;

                        }
                        j--;
                    }
                }

            }


            public void RadixSort(SortStore s)
            {

                int[] t = new int[s.Array.Length];
                int r = 4;
                int b = 32;
                int[] count = new int[1 << r];
                int[] pref = new int[1 << r];
                int groups = (int)Math.Ceiling((double)b / (double)r);
                int mask = (1 << r) - 1;

                for (int c = 0, shift = 0; c < groups; c++, shift += r)
                {

                    for (int j = 0; j < count.Length; j++)
                        count[j] = 0;

                    for (int i = 0; i < s.Array.Length; i++)
                        count[(s[i] >> shift) & mask]++;

                    pref[0] = 0;
                    for (int i = 1; i < count.Length; i++)
                        pref[i] = pref[i - 1] + count[i - 1];

                    for (int i = 0; i < s.Array.Length; i++)
                        t[pref[(s[i] >> shift) & mask]++] = s[i];

                    //  Instead of t.CopyTo(s, 0);
                    foreach (int i in t)
                    {
                        s[i] = t[i];
                    }

                }
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {

            //Destroy running math thread and clean up all pictures
            CleanUp();

            //There was dilhemma - to use new class instaces every time, or use singletons and static classes. 
            //I choose new classes, actually there are already exists Globals class, so I don't want to create more global classes.
            
            SortView v = new SortView();
            SortStore s = new SortStore();
            SortMath m = new SortMath();

            if (cbSortSelector.Text == "Bubble sort")
            {
                Globals.arraySize = 250;
                Globals.frameSize = 4;
                //we need separate thread for non UI blocking sort
                Globals.MathThread = new Thread(() => { m.BubbleSort(s); });
            }


            if (cbSortSelector.Text == "Not so bubble sort")
            {
                Globals.arraySize = 250;
                Globals.frameSize = 4;
                Globals.MathThread = new Thread(() => { m.LooksLikeBubbleSort(s); });
            }

            if (cbSortSelector.Text == "Radix sort")
            {
                Globals.arraySize = 300;
                Globals.frameSize = 3;
                Globals.MathThread = new Thread(() => { m.RadixSort(s); });
            }

            if (cbSortSelector.Text == "Insertion sort")
            {
                Globals.arraySize = 200;
                Globals.frameSize = 4;
                Globals.MathThread = new Thread(() => { m.InsertionSort(s); });
            }


            s.StoreInit();
            v.ViewInit(this, s);

            //connect store class with view class, while store class will be changed by math class
            s.ValueChanged += v.ViewUpdate;
            s.ValueAccessed += v.ViewUpdate;


            if (Globals.MathThread != null)
                Globals.MathThread.Start();

        }


        public void CleanUp()
        {

            if (Globals.MathThread != null)
            {
                if (Globals.MathThread.IsAlive)
                    Globals.MathThread.Abort();
            }

            for (int i = 0; i < 1000; i++)
            {
                PictureBox p = this.Controls[i.ToString()] as PictureBox;
                if (p != null)
                {
                    p.Dispose();
                }
            }
        }

        public Form1()
        {
            InitializeComponent();


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Globals.timeout = trackBar1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }





    }
}

