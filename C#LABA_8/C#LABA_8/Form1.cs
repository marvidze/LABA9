using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_LABA_8
{
    public partial class Form1 : Form
    {
        //private static int key = 45678;
        //int keyInt = 45678;
        //private static int quad = key * key;
        //private static int address = 1000;
        //const int HASH_SIZE = 3;
        //const int PROSTOE_CHISLO = 997;

        const int SIZE = 1000;
        int[] M = new int[SIZE];
        Random rnd = new Random();
        List<int>[] Mas = new List<int>[SIZE];
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void GenerateArray()
        {
            for (int i = 0; i < SIZE; i++)
            {
                M[i] = rnd.Next(1000, 100000);
            }
            Array.Clear(Mas, 0, SIZE);
        }

        private int CalculateCallizionMiddleSquare()
        {
            int h = 0;
            for(int i = 0; i < SIZE; i++)
            {
                int index = GetHashCodeMidleSquare(M[i], 3);
                if (Mas[index] == null)
                {
                    Mas[index] = new List<int>(M[i]);
                }
                else
                {
                    h++;
                }
            }
            Array.Clear(Mas, 0, SIZE);
            return h;
        }

        private int CalculateCallizionMultiplicationMethod()
        {
            int h = 0;
            for (int i = 0; i < SIZE; i++)
            {
                int index = GetHashCodeMultiplicationMethod(M[i], SIZE);
                if (Mas[index] == null)
                {
                    Mas[index] = new List<int>(M[i]);
                }
                else
                {
                    h++;
                }
            }
            Array.Clear(Mas, 0, SIZE);
            return h;
        }

        private int CalculateCallizionFoldingMethod()
        {
            int h = 0;
            for (int i = 0; i < SIZE; i++)
            {
                int index = GetHashCodeFoldingMethod(M[i], SIZE);
                if (Mas[index] == null)
                {
                    Mas[index] = new List<int>(M[i]);
                }
                else
                {
                    h++;
                }
            }
            Array.Clear(Mas, 0, SIZE);
            return h;
        }

        private int CalculateCallizionDivisionMethod()
        {
            int h = 0;
            for (int i = 0; i < SIZE; i++)
            {
                int index = GetHashCodeDivisionMethod(M[i], 997);
                if (Mas[index] == null)
                {
                    Mas[index] = new List<int>(M[i]);
                }
                else
                {
                    h++;
                }
            }
            Array.Clear(Mas, 0, SIZE);
            return h; ;
        }

        private void ButtonCalculateClick(object sender, EventArgs e)
        {
            int n = (int)numericUpDown.Value;
            int h1 = 0;
            int h2 = 0;
            int h3 = 0;
            int h4 = 0;
            int t1 = 0;
            int t2 = 0;
            int t3 = 0;
            int t4 = 0;
            for (int i = 0; i < n; i++)
            {
                GenerateArray();
                h1 = CalculateCallizionDivisionMethod();
                h2 = CalculateCallizionFoldingMethod();
                h3 = CalculateCallizionMiddleSquare();
                h4 = CalculateCallizionMultiplicationMethod();
                int min = Math.Min(Math.Min(h1, h2), Math.Min(h3, h4));
                if(min == h1) t1++;
                if(min == h2) t2++;
                if(min == h3) t3++;
                if(min == h4) t4++;
                
            }
            textBoxDivisionMethod.Text = t1.ToString();
            textBoxFolding.Text = t2.ToString();
            textBoxMiddleOfSquare.Text = t3.ToString();
            textBoxMultiplication.Text = t4.ToString();
        }
        static int GetHashCodeMidleSquare(int key, int hashSize)
        {
            int hashCode = key * key;
            int hashCodeSize = (int)Math.Log10(hashCode) + 1;
            hashCode /= (int)Math.Pow(10, (hashCodeSize - hashSize) / 2);
            hashCode %= (int)Math.Pow(10, hashSize);
            return hashCode;
        }
        static int GetHashCodeMultiplicationMethod(int key, int adress)
        {
            double A = (Math.Sqrt(5) - 1) / 2;
            double result = (key * A) % 1;
            int heshKey = (int)(result * adress);
            return heshKey;
        }

        static int GetHashCodeFoldingMethod(int key, int address)
        {
            int heshKey = 0;
            while (key > 0)
            {
                heshKey += key % address;
                key /= address;
            }
            heshKey %= address;
            return heshKey;
        }

       

        public int GetHashCodeDivisionMethod(int key, int m)
        {
            return key % m;
        }

        private void ButtonExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

       

        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
