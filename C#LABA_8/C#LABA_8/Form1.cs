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

        private const int SIZE = 10000;
        private int[] M1 = new int[SIZE];
        private int[] M2 = new int[SIZE];
        private Random rnd = new Random();
        private int[] MOA = new int[SIZE];

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Метод умнжения
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="adress">Размер массива</param>
        /// <returns></returns>
        static int GetHashCodeMultiplicationMethod(int key, int adress)
        {
            double A = (Math.Sqrt(5) - 1) / 2;
            double result = (key * A) % 1;
            int heshKey = (int)(result * adress);
            return heshKey;
        }


        void CreateHashTableAndFindArray()
        {
            for (int i = 0; i < SIZE; i++)
            {
                bool flag = true;
                M1[i] = rnd.Next(0, SIZE);
                int hashCode = GetHashCodeMultiplicationMethod(M1[i], SIZE);
                if (MOA[hashCode] == 0)
                {
                    MOA[hashCode] = M1[i];
                }
                else
                {
                    for (int j = hashCode; j < SIZE - 1; j++)
                    {
                        if (MOA[j] == 0)
                        {
                            MOA[j] = M1[i];
                            break;
                        }
                        if (j == SIZE - 2)
                        {
                            for (int k = 0; k < hashCode - 1; k++)
                            {
                                if (MOA[k] == 0)
                                {
                                    MOA[k] = M1[k];
                                    break;
                                }
                                if (k == hashCode - 2)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (!flag) break;
                }
            }
            for (int i = 0;i < SIZE; i++)
            {
                M2[i] = rnd.Next(0, 20000);
            }
        }

        /// <summary>
        /// Вызов функции после нажатия на кнопку
        /// </summary>
        /// <param name="sender">...</param>
        /// <param name="e">...</param>
        private void ButtonCalculateClick(object sender, EventArgs e)
        {
            int comparisons = 0;
            int theFoundElements = 0;
            CreateHashTableAndFindArray();
            int StartTime = Environment.TickCount;
            {
                for (int i = 0; i < SIZE; i++)
                {
                    int hashCode = GetHashCodeMultiplicationMethod(M2[i], SIZE);
                    if (MOA[hashCode] == M2[i])
                    {
                        comparisons++;
                        theFoundElements++;
                    }
                    else
                    {
                        for (int j = hashCode; j < SIZE - 1; j++)
                        {
                            if (MOA[j] == M2[i])
                            {
                                comparisons++;
                                theFoundElements++;
                                break;
                            }
                            comparisons++;
                            if (j == SIZE - 2)
                            {
                                for (int k = 0; k < hashCode - 1; k++)
                                {
                                    if (MOA[k] == M2[i])
                                    {
                                        comparisons++;
                                        theFoundElements++;
                                        break;
                                    }
                                    if (k == hashCode - 2)
                                    {
                                        comparisons++;
                                        break;
                                    }
                                    comparisons++;
                                }
                            }
                        }
                    }
                }
                int ResultTime = Environment.TickCount - StartTime;
                textBoxTimeOpenAdres.Text = ResultTime.ToString();
                textBoxComparsionOpenAdres.Text = comparisons.ToString();
                textBoxFindOpenAdres.Text = theFoundElements.ToString();
            }
        }

        private void ButtonExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        //private int CalculateCallizionMiddleSquare()
        //{
        //    int h = 0;
        //    for(int i = 0; i < SIZE; i++)
        //    {
        //        int index = GetHashCodeMidleSquare(M[i], 3);
        //        if (Mas[index] == null)
        //        {
        //            Mas[index] = new List<int>(M[i]);
        //        }
        //        else
        //        {
        //            h++;
        //        }
        //    }
        //    Array.Clear(Mas, 0, SIZE);
        //    return h;
        //}

        //private int CalculateCallizionMultiplicationMethod()
        //{
        //    int h = 0;
        //    for (int i = 0; i < SIZE; i++)
        //    {
        //        int index = GetHashCodeMultiplicationMethod(M[i], SIZE);
        //        if (Mas[index] == null)
        //        {
        //            Mas[index] = new List<int>(M[i]);
        //        }
        //        else
        //        {
        //            h++;
        //        }
        //    }
        //    Array.Clear(Mas, 0, SIZE);
        //    return h;
        //}

        //private int CalculateCallizionFoldingMethod()
        //{
        //    int h = 0;
        //    for (int i = 0; i < SIZE; i++)
        //    {
        //        int index = GetHashCodeFoldingMethod(M[i], SIZE);
        //        if (Mas[index] == null)
        //        {
        //            Mas[index] = new List<int>(M[i]);
        //        }
        //        else
        //        {
        //            h++;
        //        }
        //    }
        //    Array.Clear(Mas, 0, SIZE);
        //    return h;
        //}

        //private int CalculateCallizionDivisionMethod()
        //{
        //    int h = 0;
        //    for (int i = 0; i < SIZE; i++)
        //    {
        //        int index = GetHashCodeDivisionMethod(M[i], 997);
        //        if (Mas[index] == null)
        //        {
        //            Mas[index] = new List<int>(M[i]);
        //        }
        //        else
        //        {
        //            h++;
        //        }
        //    }
        //    Array.Clear(Mas, 0, SIZE);
        //    return h; ;
        //}


        //static int GetHashCodeMidleSquare(int key, int hashSize)
        //{
        //    long hashCode = (long)key * (long)key;
        //    if (hashCode < (int)Math.Pow(10, hashSize))
        //    {
        //        return (int)hashCode;
        //    }
        //    int hashCodeSize = (int)Math.Log10(hashCode) + 1;
        //    hashCode /= (int)Math.Pow(10, (hashCodeSize - hashSize) / 2);
        //    hashCode %= (int)Math.Pow(10, hashSize);
        //    return (int)hashCode;
        //}
       

        //public int GetHashCodeDivisionMethod(int key, int m)
        //{
        //    return key % m;
        //}

        /// <summary>
        /// Метод свертывания
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="address">Размер массива</param>
        /// <returns></returns>
        //int GetHashCodeFoldingMethod(int key, int address)
        //{
        //    int heshKey = 0;
        //    while (key > 0)
        //    {
        //        heshKey += key % address;
        //        key /= address;
        //    }
        //    heshKey %= address;
        //    return heshKey;
        //}

        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //int n = (int)numericUpDown.Value;
        //int h1 = 0;
        //int h2 = 0;
        //int h3 = 0;
        //int h4 = 0;
        //int t1 = 0;
        //int t2 = 0;
        //int t3 = 0;
        //int t4 = 0;
        //for (int i = 0; i < n; i++)
        //{
        //    GenerateArray();
        //    h1 = CalculateCallizionDivisionMethod();
        //    h2 = CalculateCallizionFoldingMethod();
        //    h3 = CalculateCallizionMiddleSquare();
        //    h4 = CalculateCallizionMultiplicationMethod();
        //    int min = Math.Min(Math.Min(h1, h2), Math.Min(h3, h4));
        //    if (min == h1) t1++;
        //    if (min == h2) t2++;
        //    if (min == h3) t3++;
        //    if (min == h4) t4++;
        //}
        //textBoxDivisionMethod.Text = t1.ToString();
        //textBoxFolding.Text = t2.ToString();
        //textBoxMiddleOfSquare.Text = t3.ToString();
        //textBoxMultiplication.Text = t4.ToString();

    }
}
