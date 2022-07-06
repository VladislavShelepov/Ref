using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labo14_v1
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();


        }
        public void ChageOwnerBackground()
        {
            this.Owner.BackColor = Color.Yellow;
        }
        public void recieveFromServ()
        {
            //Расшифровываем сообщение
            BigInteger tmpTest;
            string encodingStringTest = commonData.EncMesForAlice;
            string[] encodingStringsTest = encodingStringTest.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string resultTest = null;
            int iTest = 0;
            foreach (var c in encodingStringsTest)
            {
                tmpTest = BigInteger.Parse(c);
                tmpTest = tmpTest - BigInteger.Parse(textBoxZServAlice.Text[iTest % textBoxZServAlice.Text.Length].ToString());
                int newSmb = int.Parse(tmpTest.ToString());
                char newChar = Convert.ToChar(newSmb);
                resultTest += newChar;
                iTest++;
            }
            commonData.deMesToAlice = string.Join(" ", resultTest);
            //Считаем хэш
            checkHashServ.Value = commonData.deMesToAlice;
            hashTextBoxRight.Text = checkHashServ.MD;

            //Расшифровываем полученный с сервера хэш
            BigInteger eNumber = BigInteger.Parse(textBoxEServAlice.Text);
            BigInteger nNumber = BigInteger.Parse(textBoxNServAlice.Text);
            BigInteger tmp;
            string encodingString = enHashTextBoxRight.Text;
            string[] encodingStrings = encodingString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string result = null;
            foreach (var c in encodingStrings)
            {
                tmp = BigInteger.Parse(c);
                tmp = BigInteger.ModPow(tmp, eNumber, nNumber);
                Console.WriteLine(tmp);
                int newSmb = int.Parse(tmp.ToString());
                char newChar = Convert.ToChar(newSmb);
                result += newChar;
            }
            deHashTextBoxRight.Text = result;
            if (deHashTextBoxRight.Text == hashTextBoxRight.Text)
            {
                textBoxSignAlice.Text = "ЭП прошла проверку";
                //отображение в чате
                textBoxChatAlice.Text += "Боб отправил сообщение: \r\n";
                textBoxChatAlice.Text += commonData.deMesToAlice;
                textBoxChatAlice.Text += "\r\n";
            }
            else
            {
                textBoxSignAlice.Text = "ЭП не прошла проверку";
                //MessageBox.Show("Ошибка проверки ЭП сообщения", "!!!!!!!");
                (this.Owner as Form1).sendErrorFromAlice();
                return;
            }

        }
        public MD5 toHashAlice = new MD5();
        public MD5 checkHashServ = new MD5();
        public void getSesKeys()
        {
            BigInteger ZAlice;
            ZAlice = BigInteger.ModPow(BigInteger.Parse(textBoxYServAlice.Text), BigInteger.Parse(textBoxXAlice.Text), BigInteger.Parse(commonData.Pa));
            textBoxZServAlice.Text = string.Format("{0}", ZAlice);
        }
        public Form2(Form1 f)
        {
            InitializeComponent();
           // f.BackColor = Color.Yellow;
        }
        private void Form2_Load(object sender, EventArgs e) // Когда вызывается форма
        {
            commonData.deMesFromAlice = "";
            //Генерация ключей
            textBoxQAlice.Text = fromOldLabs.KeyGen(60);
            textBoxPAlice.Text = fromOldLabs.KeyGen(55);
            string eNumber = fromOldLabs.KeyGen(50);
            BigInteger ph = (BigInteger.Parse(textBoxPAlice.Text) - 1) * (BigInteger.Parse(textBoxQAlice.Text) - 1);
            while (BigInteger.GreatestCommonDivisor(ph, BigInteger.Parse(eNumber)) != 1)
            {
                eNumber = fromOldLabs.KeyGen(50);
            }
            BigInteger nNumber = BigInteger.Parse(textBoxQAlice.Text) * BigInteger.Parse(textBoxPAlice.Text);
            textBoxNAlice.Text = string.Format("{0}", nNumber);
            BigInteger dNumber = fromOldLabs.EuclidExtended(BigInteger.Parse(eNumber), ph);
            while (dNumber < 0)
            {
                eNumber = fromOldLabs.KeyGen(50);
                dNumber = fromOldLabs.EuclidExtended(BigInteger.Parse(eNumber), ph);
            }
            textBoxEAlice.Text = eNumber;
            commonData.AliceE = textBoxEAlice.Text;
            textBoxDAlice.Text = string.Format("{0}", dNumber);
            commonData.AliceN = textBoxNAlice.Text;
            
            //Обмен ключами
            textBoxNServAlice.Text = commonData.ServN;
            textBoxEServAlice.Text = commonData.ServE;
            (this.Owner as Form1).textBoxNAliceServ.Text = textBoxNAlice.Text;
            (this.Owner as Form1).textBoxEAliceServ.Text = textBoxEAlice.Text;
            textBoxNBobAlice.Text = commonData.BobN;
            textBoxEBobAlice.Text = commonData.BobE;

            BigInteger XAlice = 0;
            while ((XAlice < 1) || (XAlice > BigInteger.Parse(commonData.Qa)))
            {
                Random rand = new Random();
                XAlice = BigInteger.Parse(fromOldLabs.KeyGen(25)) + rand.Next(0, 1);
            }
            textBoxXAlice.Text = string.Format("{0}", XAlice);
            BigInteger YAlice = 0;
            YAlice = BigInteger.ModPow(BigInteger.Parse(commonData.Qa), XAlice, BigInteger.Parse(commonData.Pa));
            textBoxYAlice.Text = string.Format("{0}", YAlice);
            (this.Owner as Form1).textBoxYAlice.Text = textBoxYAlice.Text;
        }

        private void buttonSendAlice_Click(object sender, EventArgs e)
        {
            //Получаем Hash
            toHashAlice.Value = textBoxMesAlice.Text;
            hashTextBoxAlice.Text = toHashAlice.MD;
            //Зашифровываем Hash
            BigInteger dNumber = BigInteger.Parse(textBoxDAlice.Text);
            BigInteger nNumber = BigInteger.Parse(textBoxNAlice.Text);
            BigInteger tmp;
            string encodingString = hashTextBoxAlice.Text;
            string[] result = new string[encodingString.Length];
            int i = 0;
            foreach (var c in encodingString)
            {
                tmp = BigInteger.ModPow(c, dNumber, nNumber);
                result[i] = tmp.ToString();
                i++;
            }
            enHashTextBoxAlice.Text = string.Join(" ", result);
            //Зашифровываем сообщение
            BigInteger tmpMes;
            string encodingStringMes = textBoxMesAlice.Text;
            string[] resultMes = new string[encodingStringMes.Length];
            int iMes = 0;
            foreach (var c in encodingStringMes)
            {
                tmpMes = c + BigInteger.Parse(textBoxZServAlice.Text[iMes % textBoxZServAlice.Text.Length].ToString()) ;
                resultMes[iMes] = tmpMes.ToString();
                iMes++;
            }
            commonData.EncMes = string.Join(" ", resultMes);

            //Отправляем на сервер
            (this.Owner as Form1).enHashTextBoxRight.Text = enHashTextBoxAlice.Text;
            (this.Owner as Form1).recieveFromAlice();


            BigInteger tmpTest;
            string encodingStringTest = commonData.EncMes;
            string[] encodingStringsTest = encodingStringTest.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string resultTest = null;
            int iTest = 0;
            foreach (var c in encodingStringsTest)
            {
                tmpTest = BigInteger.Parse(c);
                 tmpTest = tmpTest - BigInteger.Parse(textBoxZServAlice.Text[iTest % textBoxZServAlice.Text.Length].ToString());
                int newSmb = int.Parse(tmpTest.ToString());
                char newChar = Convert.ToChar(newSmb);
                resultTest += newChar;
                iTest++;
            }
            string Test = string.Join(" ", resultTest);
            bool check = Test == encodingStringMes;

            textBoxChatAlice.Text += "Вы отправили сообщение: \r\n";
            textBoxChatAlice.Text += textBoxMesAlice.Text;
            textBoxChatAlice.Text += "\r\n";
            textBoxMesAlice.Text = "";

        }

        private void buttonWrongHashAlice_Click(object sender, EventArgs e)
        {
            //Получаем неверный Hash
            string wrongMesAlice = textBoxMesAlice.Text;
            wrongMesAlice += "компрометация ключей!!";
            toHashAlice.Value = wrongMesAlice;
            hashTextBoxAlice.Text = toHashAlice.MD;
            //Зашифровываем Hash
            BigInteger dNumber = BigInteger.Parse(textBoxDAlice.Text);
            BigInteger nNumber = BigInteger.Parse(textBoxNAlice.Text);
            BigInteger tmp;
            string encodingString = hashTextBoxAlice.Text;
            string[] result = new string[encodingString.Length];
            int i = 0;
            foreach (var c in encodingString)
            {
                tmp = BigInteger.ModPow(c, dNumber, nNumber);
                result[i] = tmp.ToString();
                i++;
            }
            enHashTextBoxAlice.Text = string.Join(" ", result);
            //Зашифровываем сообщение
            BigInteger tmpMes;
            string encodingStringMes = textBoxMesAlice.Text;
            string[] resultMes = new string[encodingStringMes.Length];
            int iMes = 0;
            foreach (var c in encodingStringMes)
            {
                tmpMes = c + BigInteger.Parse(textBoxZServAlice.Text[iMes % textBoxZServAlice.Text.Length].ToString());
                resultMes[iMes] = tmpMes.ToString();
                iMes++;
            }
            commonData.EncMes = string.Join(" ", resultMes);
            //Отображение в чате
            textBoxChatAlice.Text += "Вы отправили сообщение: \r\n";
            textBoxChatAlice.Text += textBoxMesAlice.Text;
            textBoxChatAlice.Text += "\r\n";
            textBoxMesAlice.Text = "";
            //Отправляем на сервер
            (this.Owner as Form1).enHashTextBoxRight.Text = enHashTextBoxAlice.Text;
            (this.Owner as Form1).recieveFromAlice();



        }

        private void buttonUploadAlice_Click(object sender, EventArgs e)
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
                    if (Path.GetExtension(filePath) == ".txt")
                    //try
                    {
                        string fileContent;
                        fileContent = File.ReadAllText(filePath);
                        //var temp = BigInteger.Parse(fileContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                        textBoxMesAlice.Text = String.Join(" ", fileContent);
                    }
                    else
                    //catch
                    {
                        byte[] fileContent = new byte[5244880];
                        //byte[] fileContent = Array.Empty<byte>();
                        fileContent = File.ReadAllBytes(filePath);
                        var tempo = fileContent[0];
                        var flag = BitConverter.GetBytes(int.Parse(tempo.ToString()))[0];
                        textBoxMesAlice.Text = String.Join("", fileContent);
                    }
                }
            }
        }

        private void buttonSaveLastMesAlice_Click(object sender, EventArgs e)
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


            string encryptedText = commonData.deMesToAlice;
            byte[] array = System.Text.Encoding.Default.GetBytes(encryptedText);
            File.WriteAllBytes(filePath, array);
        }
    }
}
