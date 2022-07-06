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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Form1 f)
        {
            InitializeComponent();
           //f.BackColor = Color.Yellow;
        }
        public MD5 toHashBob = new MD5();
        public MD5 CheckHashServ = new MD5();
        public void getRSAKeysFromAlice()
        {
            textBoxNAliceBob.Text = commonData.AliceN;
            textBoxEAliceBob.Text = commonData.AliceE;
        }

        public void recieveFromServ()
        {
            //Расшифровываем сообщение
            BigInteger tmpTest;
            string encodingStringTest = commonData.EncMesForBob;
            string[] encodingStringsTest = encodingStringTest.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string resultTest = null;
            int iTest = 0;
            foreach (var c in encodingStringsTest)
            {
                tmpTest = BigInteger.Parse(c);
                tmpTest = tmpTest - BigInteger.Parse(textBoxZServBob.Text[iTest % textBoxZServBob.Text.Length].ToString());
                int newSmb = int.Parse(tmpTest.ToString());
                char newChar = Convert.ToChar(newSmb);
                resultTest += newChar;
                iTest++;
            }
            commonData.deMesToBob = string.Join(" ", resultTest);
            //Считаем хэш
            checkHashServ.Value = commonData.deMesToBob;
            hashTextBoxRight.Text = checkHashServ.MD;

            //Расшифровываем полученный с сервера хэш
            BigInteger eNumber = BigInteger.Parse(textBoxEServBob.Text);
            BigInteger nNumber = BigInteger.Parse(textBoxNServBob.Text);
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
                textBoxSignBob.Text = "ЭП прошла проверку";
                //отображение в чате
                textBoxChatBob.Text += "Алиса отправила сообщение: \r\n";
                textBoxChatBob.Text += commonData.deMesToBob;
                textBoxChatBob.Text += "\r\n";
            }
            else
            {
                textBoxSignBob.Text = "ЭП не прошла проверку";
                //MessageBox.Show("Ошибка проверки ЭП сообщения", "!!!!!!!");
                (this.Owner as Form1).sendErrorFromBob();
                return;
            }
        }
        public MD5 checkHashServ = new MD5();
        public void getSesKeys()
        {
            BigInteger ZBob;
            ZBob = BigInteger.ModPow(BigInteger.Parse(textBoxYServBob.Text), BigInteger.Parse(textBoxXBob.Text), BigInteger.Parse(commonData.Pb));
            textBoxZServBob.Text = string.Format("{0}", ZBob);
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            commonData.deMesFromBob = "";
            textBoxQBob.Text = fromOldLabs.KeyGen(60);
            textBoxPBob.Text = fromOldLabs.KeyGen(55);
            string eNumber = fromOldLabs.KeyGen(50);
            BigInteger ph = (BigInteger.Parse(textBoxPBob.Text) - 1) * (BigInteger.Parse(textBoxQBob.Text) - 1);
            while (BigInteger.GreatestCommonDivisor(ph, BigInteger.Parse(eNumber)) != 1)
            {
                eNumber = fromOldLabs.KeyGen(50);
            }
            BigInteger nNumber = BigInteger.Parse(textBoxQBob.Text) * BigInteger.Parse(textBoxPBob.Text);
            textBoxNBob.Text = string.Format("{0}", nNumber);
            BigInteger dNumber = fromOldLabs.EuclidExtended(BigInteger.Parse(eNumber), ph);
            while (dNumber < 0)
            {
                eNumber = fromOldLabs.KeyGen(50);
                dNumber = fromOldLabs.EuclidExtended(BigInteger.Parse(eNumber), ph);
            }
            textBoxEBob.Text = eNumber;
            commonData.BobE = textBoxEBob.Text;
            textBoxDBob.Text = string.Format("{0}", dNumber);
            commonData.BobN = textBoxNBob.Text;


            textBoxNServBob.Text = commonData.ServN;
            textBoxEServBob.Text = commonData.ServE;
            (this.Owner as Form1).textBoxNBobServ.Text = textBoxNBob.Text;
            (this.Owner as Form1).textBoxEBobServ.Text = textBoxEBob.Text;

            BigInteger XBob = 0;
            while ((XBob < 1) || (XBob > BigInteger.Parse(commonData.Qb)))
            {
                Random rand = new Random();
                XBob = BigInteger.Parse(fromOldLabs.KeyGen(25)) + rand.Next(0, 1);
            }
            textBoxXBob.Text = string.Format("{0}", XBob);
            BigInteger YBob = 0;
            YBob = BigInteger.ModPow(BigInteger.Parse(commonData.Qb), XBob, BigInteger.Parse(commonData.Pb));
            textBoxYBob.Text = string.Format("{0}", YBob);
            (this.Owner as Form1).textBoxYBob.Text = textBoxYBob.Text;
        }

        private void buttonSendBob_Click(object sender, EventArgs e)
        {
            //Получаем Hash
            toHashBob.Value = textBoxMesBob.Text;
            hashTextBoxBob.Text = toHashBob.MD;
            //Зашифровываем Hash
            BigInteger dNumber = BigInteger.Parse(textBoxDBob.Text);
            BigInteger nNumber = BigInteger.Parse(textBoxNBob.Text);
            BigInteger tmp;
            string encodingString = hashTextBoxBob.Text;
            string[] result = new string[encodingString.Length];
            int i = 0;
            foreach (var c in encodingString)
            {
                tmp = BigInteger.ModPow(c, dNumber, nNumber);
                result[i] = tmp.ToString();
                i++;
            }
            enHashTextBoxBob.Text = string.Join(" ", result);

            //Зашифровываем сообщение
            BigInteger tmpMes;
            string encodingStringMes = textBoxMesBob.Text;
            string[] resultMes = new string[encodingStringMes.Length];
            int iMes = 0;
            foreach (var c in encodingStringMes)
            {
                tmpMes = c + BigInteger.Parse(textBoxZServBob.Text[iMes % textBoxZServBob.Text.Length].ToString());
                resultMes[iMes] = tmpMes.ToString();
                iMes++;
            }
            commonData.EncMes = string.Join(" ", resultMes);

            //Отправляем на сервер
            (this.Owner as Form1).enHashTextBoxRight.Text = enHashTextBoxBob.Text;
            (this.Owner as Form1).recieveFromBob();
            //Отображаем в чате 
            textBoxChatBob.Text += "Вы отправили сообщение: \r\n";
            textBoxChatBob.Text += textBoxMesBob.Text;
            textBoxChatBob.Text += "\r\n";
            textBoxMesBob.Text = "";
        }

        private void buttonWrongHashBob_Click(object sender, EventArgs e)
        {
            //Получаем неверный Hash
            string wrongMesBob = textBoxMesBob.Text;
            wrongMesBob += "компрометация ключей!!";
            toHashBob.Value = wrongMesBob;
            hashTextBoxBob.Text = toHashBob.MD;
            //Зашифровываем Hash
            BigInteger dNumber = BigInteger.Parse(textBoxDBob.Text);
            BigInteger nNumber = BigInteger.Parse(textBoxNBob.Text);
            BigInteger tmp;
            string encodingString = hashTextBoxBob.Text;
            string[] result = new string[encodingString.Length];
            int i = 0;
            foreach (var c in encodingString)
            {
                tmp = BigInteger.ModPow(c, dNumber, nNumber);
                result[i] = tmp.ToString();
                i++;
            }
            enHashTextBoxBob.Text = string.Join(" ", result);

            //Зашифровываем сообщение
            BigInteger tmpMes;
            string encodingStringMes = textBoxMesBob.Text;
            string[] resultMes = new string[encodingStringMes.Length];
            int iMes = 0;
            foreach (var c in encodingStringMes)
            {
                tmpMes = c + BigInteger.Parse(textBoxZServBob.Text[iMes % textBoxZServBob.Text.Length].ToString());
                resultMes[iMes] = tmpMes.ToString();
                iMes++;
            }
            commonData.EncMes = string.Join(" ", resultMes);

            //Отображаем в чате 
            textBoxChatBob.Text += "Вы отправили сообщение: \r\n";
            textBoxChatBob.Text += textBoxMesBob.Text;
            textBoxChatBob.Text += "\r\n";
            textBoxMesBob.Text = "";
            //Отправляем на сервер
            (this.Owner as Form1).enHashTextBoxRight.Text = enHashTextBoxBob.Text;
            (this.Owner as Form1).recieveFromBob();

        }

        private void buttonUploadBob_Click(object sender, EventArgs e)
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
                        textBoxMesBob.Text = String.Join(" ", fileContent);
                    }
                    else
                    //catch
                    {
                        byte[] fileContent = new byte[5244880];
                        //byte[] fileContent = Array.Empty<byte>();
                        fileContent = File.ReadAllBytes(filePath);
                        var tempo = fileContent[0];
                        var flag = BitConverter.GetBytes(int.Parse(tempo.ToString()))[0];
                        textBoxMesBob.Text = String.Join("", fileContent);
                    }
                }
            }
        }

        private void buttonSaveLastMesBob_Click(object sender, EventArgs e)
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


            string encryptedText = commonData.deMesToBob;
            byte[] array = System.Text.Encoding.Default.GetBytes(encryptedText);
            File.WriteAllBytes(filePath, array);
        }
    }
}
