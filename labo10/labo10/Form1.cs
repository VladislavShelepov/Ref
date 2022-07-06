using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labo10
{ 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool flagDe = false;
        bool flagEn = false;
        public string KeyGen(int degr)
        {
            var sb = new StringBuilder(2 ^ degr);
            var rnd = new Random();
            for (int i = 0; i < sb.Capacity; i++)
            {
                sb.Append(rnd.Next(0, 10));
            }
            string str = sb.ToString();
            BigInteger pNumber = new BigInteger();
            pNumber = BigInteger.Parse(str);
            if (pNumber.IsEven)
                pNumber++;
            while (!pNumber.IsProbablyPrime())
                pNumber += 2;
            return string.Format("{0}", pNumber);
        }

        private BigInteger modInverse(BigInteger a, BigInteger n)
        {
            BigInteger i = n, v = 0, d = 1;
            while (a > 0)
            {
                BigInteger t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }

        private void generateKeyButton_Click(object sender, EventArgs e)
        {
            textBoxQ.Text = KeyGen(60);
            textBoxP.Text = KeyGen(55);
            string eNumber = KeyGen(50);
            BigInteger ph = (BigInteger.Parse(textBoxP.Text) - 1) * (BigInteger.Parse(textBoxQ.Text) - 1);
            while (BigInteger.GreatestCommonDivisor(ph, BigInteger.Parse(eNumber)) !=1)
            {
                eNumber = KeyGen(50);
            }
            BigInteger nNumber = BigInteger.Parse(textBoxQ.Text) * BigInteger.Parse(textBoxP.Text);
            textBoxN.Text = string.Format("{0}", nNumber);
            BigInteger dNumber = EuclidExtended(BigInteger.Parse(eNumber), ph);
            while (dNumber < 0)
            {
                eNumber = KeyGen(50);
                dNumber = EuclidExtended(BigInteger.Parse(eNumber), ph);
            }
            textBoxE.Text = eNumber;
            textBoxD.Text = string.Format("{0}", dNumber);
            textBoxD.Text = string.Format("{0}", dNumber);
            flagDe = true;
            flagEn = true;
        }

        private void setKeyButton_Click(object sender, EventArgs e)
        {
            if (textBoxQ.Text == "" || (!BigInteger.Parse(textBoxQ.Text).IsProbablyPrime()))
            {
                MessageBox.Show("Q введено неправильно", "Введите заново");
                return;
            }
            if (textBoxP.Text == "" || (!BigInteger.Parse(textBoxP.Text).IsProbablyPrime()))
            {
                MessageBox.Show("P введено неправильно", "Введите заново");
                return;
            }
            BigInteger ph = (BigInteger.Parse(textBoxP.Text) - 1) * (BigInteger.Parse(textBoxQ.Text) - 1);
            if (textBoxE.Text == "" || (BigInteger.GreatestCommonDivisor(ph, BigInteger.Parse(textBoxE.Text)) != 1) || (BigInteger.Parse(textBoxE.Text)) > (BigInteger.Parse(textBoxP.Text) * BigInteger.Parse(textBoxQ.Text)))
            {
                MessageBox.Show("E введено неправильно", "Введите заново");
                return;
            }
            if (BigInteger.Parse(textBoxP.Text) == BigInteger.Parse(textBoxQ.Text))
            {
                MessageBox.Show("p и q должны быть различны", "Введите заново");
                return;
            }
            //BigInteger dNumber = EuclidExtended(BigInteger.Parse(textBoxE.Text), ph);
            //BigInteger dNumber = BigInteger.ModPow(BigInteger.Parse(textBoxE.Text), ph - 2, ph);
            BigInteger dNumber = modInverse(BigInteger.Parse(textBoxE.Text), BigInteger.Parse(ph.ToString()));
            textBoxD.Text = string.Format("{0}", dNumber);
            if (dNumber < 0)
            {
              MessageBox.Show("D сгенерировано неправильно", "Введите заново");
              return;
            }
            BigInteger nNumber = (BigInteger.Parse(textBoxP.Text)) * (BigInteger.Parse(textBoxQ.Text));
            textBoxN.Text = string.Format("{0}", nNumber);
            flagEn = true;
            flagDe = true;
        }

        private void textBoxP_TextChanged(object sender, EventArgs e)
        {
            flagDe = false;
        }

        private void textBoxQ_TextChanged(object sender, EventArgs e)
        {
            flagDe = false;
        }

        private void textBoxE_TextChanged(object sender, EventArgs e)
        {
            flagEn = false;
        }

        private void buttonUploadDe_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ".";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    try
                    {
                        string fileContent;
                        fileContent = File.ReadAllText(filePath);
                        var temp = BigInteger.Parse(fileContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                        enTextBox1.Text = String.Join(" ", fileContent);
                    }
                    catch
                    {
                        byte[] fileContent = Array.Empty<byte>();
                        fileContent = File.ReadAllBytes(filePath);
                        var temp = fileContent[0];
                        var flag = BitConverter.GetBytes(int.Parse(temp.ToString()))[0];
                        enTextBox1.Text = String.Join(" ", fileContent);
                    }
                }
            }
        }

        private void buttonUpload2_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ".";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    try
                    {
                        string fileContent;
                        fileContent = File.ReadAllText(filePath);
                        var temp = BigInteger.Parse(fileContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                        deTextBox1.Text = String.Join(" ", fileContent);
                    }
                    catch
                    {
                        byte[] fileContent = Array.Empty<byte>();
                        fileContent = File.ReadAllBytes(filePath);
                        var temp = fileContent[0];
                        var flag = BitConverter.GetBytes(int.Parse(temp.ToString()))[0];
                        deTextBox1.Text = String.Join(" ", fileContent);
                    }
                }
            }
        }

        private void buttonSaveEn_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = ".";
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    filePath = saveFileDialog.FileName;
            }
            
            
                string encryptedText = enTextBox2.Text;
                byte[] array = System.Text.Encoding.Default.GetBytes(encryptedText);
                File.WriteAllBytes(filePath, array);
            
        }

        private void buttonSaveDe_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = ".";
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    filePath = saveFileDialog.FileName;
            }
            try
            {
                string[] decryptedText = deTextBox2.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                byte[] array = new Byte[decryptedText.Length];
                int i = 0;
                foreach (var c in decryptedText)
                {
                    array[i] = BitConverter.GetBytes(int.Parse(c))[0];
                    i += 1;
                }
                File.WriteAllBytes(filePath, array);
            }
            catch
            {
                string decryptedText = deTextBox2.Text;
                byte[] array = System.Text.Encoding.Default.GetBytes(decryptedText);
                File.WriteAllBytes(filePath, array);
            }
        }
        public BigInteger EuclidExtended(BigInteger a, BigInteger b)
        {
            var si2 = new BigInteger(1);
            var ti2 = new BigInteger(0);
            var si1 = new BigInteger(0);
            var ti1 = new BigInteger(1);
            while (b != 0)
            {
                var k = a / b;
                var si = si2 - k * si1;
                var ti = ti2 - k * ti1;
                si2 = si1;
                ti2 = ti1;
                si1 = si;
                ti1 = ti;
                var r = a % b;
                a = b;
                b = r;
            }
            return si2;
        }
        long inverse(long a, long n)
        {
            long x = 0;
            x = extended_euclid(a, n);
            return x;
        }
        long extended_euclid(long a, long b)
        {
            long q, r, x1, x2, y1, y2;
            long x = 0;
            long y = 0;
            long d = 0;
            if (b == 0)
            {
                d = a;
                x = 1;
                y = 0;
                return x;
            }
            x2 = 1;
            x1 = 0;
            y2 = 0;
            y1 = 1;
            while (b > 0)
            {
                q = a / b;
                r = a - q * b;
                x = x2 - q * x1;
                y = y2 - q * y1;
                a = b;
                b = r;
                x2 = x1;
                x1 = x;
                y2 = y1;
                y1 = y;
            }
            d = a;
            x = x2;
            y = y2;
            return x;
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            if (flagEn == true)
            {
                BigInteger eNumber = BigInteger.Parse(textBoxE.Text);
                BigInteger nNumber = BigInteger.Parse(textBoxN.Text);
                BigInteger tmp;
                string encodingString = enTextBox1.Text;
                string[] result = new string[encodingString.Length];
                int i = 0;
                foreach (var c in encodingString)
                {
                    tmp = BigInteger.ModPow(c, eNumber, nNumber);
                    result[i] = tmp.ToString();
                    i++;
                }
                enTextBox2.Text = string.Join(" ", result);
            }
            else
            {
                MessageBox.Show("Неверные ключи", "Введите заново");
                return;
            }

        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            if (flagDe == true)
            {
                BigInteger dNumber = BigInteger.Parse(textBoxD.Text);
                BigInteger nNumber = BigInteger.Parse(textBoxN.Text);
                BigInteger tmp;
                string encodingString = deTextBox1.Text;
                string[] encodingStrings = encodingString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string result = null;
                foreach (var c in encodingStrings)
                {
                    tmp = BigInteger.Parse(c);
                    tmp = BigInteger.ModPow(tmp, dNumber, nNumber);
                    Console.WriteLine(tmp);
                    int newSmb = int.Parse(tmp.ToString());
                    char newChar = Convert.ToChar(newSmb);
                    result += newChar;
                }
                deTextBox2.Text = result;
            }
            else
            {
                MessageBox.Show("Неверные ключи", "Введите заново");
                return;
            }
        }

        private void textBoxN_TextChanged(object sender, EventArgs e)
        {
            flagEn = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveKeys_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    //Read the contents of the file into a stream
                    var fileStream = new FileStream(filePath, FileMode.Create);
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        string tmp = textBoxD.Text + " " + textBoxN.Text;

                        writer.WriteLine(tmp);
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    using (StreamReader sr = new StreamReader(fileStream, Encoding.GetEncoding(1251)))
                    {
                        string temp = string.Empty;
                        while (sr.Peek() != -1)
                        {
                            temp = sr.ReadLine();
                            var temp1 = temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            textBoxD.Text = temp1[0];
                            textBoxN.Text = temp1[1];
                        }
                    }
                    fileStream.Close();
                }
            }
        }

        private void setKeyButton2_Click(object sender, EventArgs e)
        {
            flagDe = true;
        }
    }
    public static class PrimeExtensions
    {
        // Random generator (thread safe)
        private static ThreadLocal<Random> s_Gen = new ThreadLocal<Random>(
          () => {
              return new Random();
          }
        );

        // Random generator (thread safe)
        private static Random Gen
        {
            get
            {
                return s_Gen.Value;
            }
        }

        public static Boolean IsProbablyPrime(this BigInteger value, int witnesses = 10)
        {
            if (value <= 1)
                return false;
            if (witnesses <= 0)
                witnesses = 10;
            BigInteger d = value - 1;
            int s = 0;
            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            Byte[] bytes = new Byte[value.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < witnesses; i++)
            {
                do
                {
                    Gen.NextBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= value - 2);

                BigInteger x = BigInteger.ModPow(a, d, value);
                if (x == 1 || x == value - 1)
                    continue;
                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, value);
                    if (x == 1)
                        return false;
                    if (x == value - 1)
                        break;
                }
                if (x != value - 1)
                    return false;
            }
            return true;
        }
    }

}
