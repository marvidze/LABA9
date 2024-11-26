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
        private List<int>[] MC = new List<int>[SIZE];

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

        void CreateHashTableOpenAddress()
        {
            for (int i = 0; i < SIZE; i++)
            {
                bool flag = true;
                M1[i] = rnd.Next(1, SIZE);
                int hashCode = GetHashCodeMultiplicationMethod(M1[i], SIZE);
                if (MOA[hashCode] == 0)
                {
                    MOA[hashCode] = M1[i];
                }
                else
                {
                    for (int j = hashCode; j < SIZE; j++)
                    {
                        if (MOA[j] == 0)
                        {
                            MOA[j] = M1[i];
                            break;
                        }
                        if (j == SIZE - 1)
                        {
                            for (int k = 0; k < hashCode; k++)
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
        }

        void CreateHashTableСhainsMethod()
        {
            for (int i = 0; i < SIZE; i++)
            {
                int hash = GetHashCodeMultiplicationMethod(M1[i], SIZE);
                if (MC[hash] == null)
                {
                    MC[hash] = new List<int>() { M1[i] };
                }
                else
                {
                    MC[hash].Add(M1[i]);
                }
            }
        }

        /// <summary>
        /// Вызов функции после нажатия на кнопку
        /// </summary>
        /// <param name="sender">...</param>
        /// <param name="e">...</param>
        private void ButtonCalculateClick(object sender, EventArgs e)
        {
            int foundKeysChain = 0;
            int comparisonsChain = 0;
            double comparChain = 0;
            int foundKeys = 0;
            int comparisons = 0;
            double compar = 0;

            CreateHashTableOpenAddress();
            CreateHashTableСhainsMethod();

            // Заполнение поискового массива ключами.
            for (int i = 0; i < SIZE; i++)
            {
                M2[i] = rnd.Next(1, 20000);
            }

            int StartTimeA = Environment.TickCount;
            {
                for (int i = 0; i < SIZE; i++)
                {
                    comparisons = 0;
                    int hashCode = GetHashCodeMultiplicationMethod(M2[i], SIZE);
                    if (MOA[hashCode] == M2[i])
                    {
                        comparisons++;
                        foundKeys++;
                    }
                    else
                    {
                        for (int j = hashCode + 1; j < SIZE; j++)
                        {
                            if (MOA[j] == M2[i])
                            {
                                comparisons++;
                                foundKeys++;
                                break;
                            }
                            comparisons++;
                            if (j == SIZE - 1)
                            {
                                for (int k = 0; k < hashCode; k++)
                                {
                                    if (MOA[k] == M2[i])
                                    {
                                        comparisons++;
                                        foundKeys++;
                                        break;
                                    }
                                    comparisons++;
                                }
                                break;
                            }
                        }
                    }
                    compar += comparisons;
                }
                compar /= SIZE;
            }
            int ResultTimeA = Environment.TickCount - StartTimeA;
            textBoxTimeOpenAdres.Text = ResultTimeA.ToString();
            textBoxComparsionOpenAdres.Text = compar.ToString("F2");
            textBoxFindOpenAdres.Text = foundKeys.ToString();

            int StartTimeB = Environment.TickCount;
            {
                for (int i = 0; i < SIZE; i++)
                {
                    comparisonsChain = 0;
                    int hashCode = GetHashCodeMultiplicationMethod(M2[i], SIZE);
                    if (MC[hashCode] != null)
                    {
                        for (int j = 0; j < MC[hashCode].Count; j++)
                        {
                            comparisonsChain++;
                            if (MC[hashCode][j] == M2[i])
                            {
                                foundKeysChain++;
                                break;
                            }
                        }
                    }
                    comparChain += comparisonsChain;
                }
            }
            comparChain /= SIZE;
            int ResultTimeB = Environment.TickCount - StartTimeB;
            textBoxTimeChain.Text = ResultTimeB.ToString();
            textBoxComparisonChain.Text = comparChain.ToString("F2");
            textBoxFindChain.Text = foundKeys.ToString();
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

