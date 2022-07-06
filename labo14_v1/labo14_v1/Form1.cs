using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labo14_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public MD5 checkHashAlice = new MD5();
        public MD5 checkHashBob = new MD5();
        public void sendErrorFromAlice()
        {
            (this.OwnedForms[0] as Form3).textBoxChatBob.Text += "Ошибка проверки ЭП сообщения на стороне Алисы \r\n";
            return;
        }

        public void sendErrorFromBob()
        {
            (this.OwnedForms[1] as Form2).textBoxChatAlice.Text += "Ошибка проверки ЭП сообщения на стороне Боба \r\n";
            return;
        }
        public void recieveFromBob()
        {
            //Расшифровываем сообщение
            BigInteger tmpTest;
            string encodingStringTest = commonData.EncMes;
            string[] encodingStringsTest = encodingStringTest.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string resultTest = null;
            int iTest = 0;
            foreach (var c in encodingStringsTest)
            {
                tmpTest = BigInteger.Parse(c);
                tmpTest = tmpTest - BigInteger.Parse(textBoxZSB.Text[iTest % textBoxZSB.Text.Length].ToString());
                int newSmb = int.Parse(tmpTest.ToString());
                char newChar = Convert.ToChar(newSmb);
                resultTest += newChar;
                iTest++;
            }
            commonData.deMesFromBob = string.Join(" ", resultTest);
            //Считаем хэш
            checkHashBob.Value = commonData.deMesFromBob;
            hashTextBoxRight.Text = checkHashBob.MD;

            //Расшифровываем полученный с клиента хэш
            BigInteger eNumber = BigInteger.Parse(textBoxEBobServ.Text);
            BigInteger nNumber = BigInteger.Parse(textBoxNBobServ.Text);
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
                textBoxSignServ.Text = "ЭП прошла проверку";
                sendToAlice();
            }
            else
            {
                textBoxSignServ.Text = "ЭП не прошла проверку";
                // MessageBox.Show("Ошибка проверки ЭП сообщения", "!!!!!!!");
                (this.OwnedForms[0] as Form3).textBoxChatBob.Text += "Ошибка проверки ЭП сообщения на стороне сервера \r\n";
                return;
            }

        }
        public void recieveFromAlice()
        {
            //Расшифровываем сообщение
            BigInteger tmpTest;
            string encodingStringTest = commonData.EncMes;
            string[] encodingStringsTest = encodingStringTest.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string resultTest = null;
            int iTest = 0;
            foreach (var c in encodingStringsTest)
            {
                tmpTest = BigInteger.Parse(c);
                tmpTest = tmpTest - BigInteger.Parse(textBoxZSA.Text[iTest % textBoxZSA.Text.Length].ToString());
                int newSmb = int.Parse(tmpTest.ToString());
                char newChar = Convert.ToChar(newSmb);
                resultTest += newChar;
                iTest++;
            }
            commonData.deMesFromAlice = string.Join(" ", resultTest);
            //Считаем хэш
            checkHashAlice.Value = commonData.deMesFromAlice;
            hashTextBoxRight.Text = checkHashAlice.MD;

            //Расшифровываем полученный с клиента хэш
            BigInteger eNumber = BigInteger.Parse(textBoxEAliceServ.Text);
            BigInteger nNumber = BigInteger.Parse(textBoxNAliceServ.Text);
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
                textBoxSignServ.Text = "ЭП прошла проверку";
                sendToBob();
            }
            else
            {
                textBoxSignServ.Text = "ЭП не прошла проверку";
                //MessageBox.Show("Ошибка проверки ЭП сообщения", "!!!!!!!");
                (this.OwnedForms[1] as Form2).textBoxChatAlice.Text += "Ошибка проверки ЭП сообщения на стороне сервера \r\n";
                return;
            }

        }

        public void sendToBob()
        {
            //Зашифровываем Hash
            BigInteger dNumber = BigInteger.Parse(textBoxDServ.Text);
            BigInteger nNumber = BigInteger.Parse(textBoxNServ.Text);
            BigInteger tmp;
            string encodingString = hashTextBoxRight.Text;
            string[] result = new string[encodingString.Length];
            int i = 0;
            foreach (var c in encodingString)
            {
                tmp = BigInteger.ModPow(c, dNumber, nNumber);
                result[i] = tmp.ToString();
                i++;
            }
            string enHashForBob = string.Join(" ", result);
            //Зашифровываем сообщение
            BigInteger tmpMes;
            string encodingStringMes = commonData.deMesFromAlice;
            string[] resultMes = new string[encodingStringMes.Length];
            int iMes = 0;
            foreach (var c in encodingStringMes)
            {
                tmpMes = c + BigInteger.Parse(textBoxZSB.Text[iMes % textBoxZSB.Text.Length].ToString());
                resultMes[iMes] = tmpMes.ToString();
                iMes++;
            }
            commonData.EncMesForBob = string.Join(" ", resultMes);
            //Отправляем Бобу
            (this.OwnedForms[0] as Form3).enHashTextBoxRight.Text = enHashForBob;
            (this.OwnedForms[0] as Form3).recieveFromServ();
        }



        public void sendToAlice()
        {
            //Зашифровываем Hash
            BigInteger dNumber = BigInteger.Parse(textBoxDServ.Text);
            BigInteger nNumber = BigInteger.Parse(textBoxNServ.Text);
            BigInteger tmp;
            string encodingString = hashTextBoxRight.Text;
            string[] result = new string[encodingString.Length];
            int i = 0;
            foreach (var c in encodingString)
            {
                tmp = BigInteger.ModPow(c, dNumber, nNumber);
                result[i] = tmp.ToString();
                i++;
            }
            string enHashForAlice = string.Join(" ", result);
            //Зашифровываем сообщение
            BigInteger tmpMes;
            string encodingStringMes = commonData.deMesFromBob;
            string[] resultMes = new string[encodingStringMes.Length];
            int iMes = 0;
            foreach (var c in encodingStringMes)
            {
                tmpMes = c + BigInteger.Parse(textBoxZSA.Text[iMes % textBoxZSA.Text.Length].ToString());
                resultMes[iMes] = tmpMes.ToString();
                iMes++;
            }
            commonData.EncMesForAlice = string.Join(" ", resultMes);
            //Отправляем Алисе
            (this.OwnedForms[1] as Form2).enHashTextBoxRight.Text = enHashForAlice;
            (this.OwnedForms[1] as Form2).recieveFromServ();
    }
        private void Form1_Load(object sender, EventArgs e)
        {
            //RSA 
            textBoxQServ.Text = fromOldLabs.KeyGen(60);
            textBoxPServ.Text = fromOldLabs.KeyGen(55);
            string eNumber = fromOldLabs.KeyGen(50);
            BigInteger ph = (BigInteger.Parse(textBoxPServ.Text) - 1) * (BigInteger.Parse(textBoxQServ.Text) - 1);
            while (BigInteger.GreatestCommonDivisor(ph, BigInteger.Parse(eNumber)) != 1)
            {
                eNumber = fromOldLabs.KeyGen(50);
            }
            BigInteger nNumber = BigInteger.Parse(textBoxQServ.Text) * BigInteger.Parse(textBoxPServ.Text);
            textBoxNServ.Text = string.Format("{0}", nNumber);
            BigInteger dNumber = fromOldLabs.EuclidExtended(BigInteger.Parse(eNumber), ph);
            while (dNumber < 0)
            {
                eNumber = fromOldLabs.KeyGen(50);
                dNumber = fromOldLabs.EuclidExtended(BigInteger.Parse(eNumber), ph);
            }
            textBoxEServ.Text = eNumber;
            commonData.ServE = textBoxEServ.Text;
            textBoxDServ.Text = string.Format("{0}", dNumber);
            commonData.ServN = textBoxNServ.Text;

            //Диффи-Хеллман (Без Z)
            BigInteger P, g, Q, XaServ, XbServ, YaServ, YbServ;
            //Для Алисы
            P = 0;
            g = 0;
            Q = 0;
            while (!P.IsProbablyPrime())
            {
                g = BigInteger.Parse(fromOldLabs.KeyGen(50));
                P = 2 * g + 1;
            }
            textBoxPa.Text = string.Format("{0}", P);
            commonData.Pa = textBoxPa.Text;
            while ((Q < 1) || (Q > (P - 1)))
            {
                BigInteger tmp = BigInteger.Parse(fromOldLabs.KeyGen(30));
                Q = tmp % P;
            }
            textBoxQa.Text = string.Format("{0}", Q);
            commonData.Qa = textBoxQa.Text;

            //Для Боба
            P = 0;
            g = 0;
            Q = 0;
            while (!P.IsProbablyPrime())
            {
                g = BigInteger.Parse(fromOldLabs.KeyGen(50));
                P = 2 * g + 1;
            }
            textBoxPb.Text = string.Format("{0}", P);
            commonData.Pb = textBoxPb.Text;
            while ((Q < 1) || (Q > (P - 1)))
            {
                BigInteger tmp = BigInteger.Parse(fromOldLabs.KeyGen(30));
                Q = tmp % P;
            }
            textBoxQb.Text = string.Format("{0}", Q);
            commonData.Qb = textBoxQb.Text;



            XaServ = 0; //Для Алисы
            XbServ = 0; //Для Боба
            while ((XaServ < 1) || (XaServ > BigInteger.Parse(textBoxPa.Text)))
            {
                Random rand = new Random();
                XaServ = BigInteger.Parse(fromOldLabs.KeyGen(25)) + rand.Next(0, 1);
            }
            textBoxXAServ.Text = string.Format("{0}", XaServ);
            while ((XbServ < 1) || (XbServ > BigInteger.Parse(textBoxPb.Text)))
            {
                Random rand = new Random();
                XbServ = BigInteger.Parse(fromOldLabs.KeyGen(26)) + rand.Next(0, 1);
            }
            textBoxXBServ.Text = string.Format("{0}", XbServ);

            YaServ = BigInteger.ModPow(BigInteger.Parse(commonData.Qa), XaServ, BigInteger.Parse(commonData.Pa));
            textBoxYAServ.Text = string.Format("{0}", YaServ);
            YbServ = BigInteger.ModPow(BigInteger.Parse(commonData.Qb), XbServ, BigInteger.Parse(commonData.Pb));
            textBoxYBServ.Text = string.Format("{0}", YbServ);

            //Вызываются формы Алисы и Боба
            Form3 clientBob = new Form3(this);
            //clientBob.ShowInTaskbar = false;
            clientBob.Owner = this;
            clientBob.Show();


            Form2 clientAlice = new Form2(this);
           // clientAlice.ShowInTaskbar = false;
            clientAlice.Owner = this;
            clientAlice.Show();
            //Обмен ключами 
            (this.OwnedForms[1] as Form2).textBoxNServAlice.Text = textBoxNServ.Text; //RSA
            (this.OwnedForms[1] as Form2).textBoxEServAlice.Text = textBoxEServ.Text; //RSA
            (this.OwnedForms[1] as Form2).textBoxYServAlice.Text = textBoxYAServ.Text; //Диффи
            (this.OwnedForms[0] as Form3).getRSAKeysFromAlice(); //RSA от Алисы Бобу
            (this.OwnedForms[0] as Form3).textBoxYServBob.Text = textBoxYBServ.Text; //Диффи


            //Диффи-Хеллман (Z)
            BigInteger ZaServ;
            ZaServ = BigInteger.ModPow(BigInteger.Parse(textBoxYAlice.Text), BigInteger.Parse(textBoxXAServ.Text), BigInteger.Parse(textBoxPa.Text));
            textBoxZSA.Text = string.Format("{0}", ZaServ);

            BigInteger ZbServ;
            ZbServ = BigInteger.ModPow(BigInteger.Parse(textBoxYBob.Text), BigInteger.Parse(textBoxXBServ.Text), BigInteger.Parse(textBoxPb.Text));
            textBoxZSB.Text = string.Format("{0}", ZbServ);

            bool Check = BigInteger.Parse(commonData.Pb) == BigInteger.Parse(textBoxPb.Text);

            (this.OwnedForms[0] as Form3).getSesKeys();
            (this.OwnedForms[1] as Form2).getSesKeys();
        }

        private void generateKeyButton_Click(object sender, EventArgs e) // Все происходит автомотически, не нужно нажимать
        {
            BigInteger ZaServ;
            ZaServ = BigInteger.ModPow(BigInteger.Parse(textBoxYAlice.Text), BigInteger.Parse(textBoxXAServ.Text), BigInteger.Parse(textBoxPa.Text));
           textBoxZSA.Text = string.Format("{0}", ZaServ);

            BigInteger ZbServ;
            ZbServ = BigInteger.ModPow(BigInteger.Parse(textBoxYBob.Text), BigInteger.Parse(textBoxXBServ.Text), BigInteger.Parse(textBoxPb.Text));
            textBoxZSB.Text = string.Format("{0}", ZbServ);

            bool Check = BigInteger.Parse(commonData.Pb) == BigInteger.Parse(textBoxPb.Text);

            (this.OwnedForms[0] as Form3).getSesKeys();
            (this.OwnedForms[1] as Form2).getSesKeys();
        }

        private void buttonWrongHashToAlice_Click(object sender, EventArgs e) //Для проверки отправки с ошибкой
        {
            //Считаем неверный хэш
            string wrongHash = commonData.deMesFromBob;
            wrongHash += "компрометация ключей!!";
            checkHashBob.Value = wrongHash;
            hashTextBoxRight.Text = checkHashBob.MD;
            //Зашифровываем Hash
            BigInteger dNumber = BigInteger.Parse(textBoxDServ.Text);
            BigInteger nNumber = BigInteger.Parse(textBoxNServ.Text);
            BigInteger tmp;
            string encodingString = hashTextBoxRight.Text;
            string[] result = new string[encodingString.Length];
            int i = 0;
            foreach (var c in encodingString)
            {
                tmp = BigInteger.ModPow(c, dNumber, nNumber);
                result[i] = tmp.ToString();
                i++;
            }
            string enHashForAlice = string.Join(" ", result);
            //Зашифровываем сообщение
            BigInteger tmpMes;
            string encodingStringMes = commonData.deMesFromBob;
            string[] resultMes = new string[encodingStringMes.Length];
            int iMes = 0;
            foreach (var c in encodingStringMes)
            {
                tmpMes = c + BigInteger.Parse(textBoxZSA.Text[iMes % textBoxZSA.Text.Length].ToString());
                resultMes[iMes] = tmpMes.ToString();
                iMes++;
            }
            commonData.EncMesForAlice = string.Join(" ", resultMes);
            //Отправляем Алисе
            (this.OwnedForms[1] as Form2).enHashTextBoxRight.Text = enHashForAlice;
            (this.OwnedForms[1] as Form2).recieveFromServ();
        }

        private void buttonWrongHashToBob_Click(object sender, EventArgs e)
        {
            //Считаем неверный хэш
            string wrongHash = commonData.deMesFromAlice;
            wrongHash += "компрометация ключей!!";
            checkHashAlice.Value = wrongHash;
            hashTextBoxRight.Text = checkHashAlice.MD;
            //Зашифровываем Hash
            BigInteger dNumber = BigInteger.Parse(textBoxDServ.Text);
            BigInteger nNumber = BigInteger.Parse(textBoxNServ.Text);
            BigInteger tmp;
            string encodingString = hashTextBoxRight.Text;
            string[] result = new string[encodingString.Length];
            int i = 0;
            foreach (var c in encodingString)
            {
                tmp = BigInteger.ModPow(c, dNumber, nNumber);
                result[i] = tmp.ToString();
                i++;
            }
            string enHashForBob = string.Join(" ", result);
            //Зашифровываем сообщение
            BigInteger tmpMes;
            string encodingStringMes = commonData.deMesFromAlice;
            string[] resultMes = new string[encodingStringMes.Length];
            int iMes = 0;
            foreach (var c in encodingStringMes)
            {
                tmpMes = c + BigInteger.Parse(textBoxZSB.Text[iMes % textBoxZSB.Text.Length].ToString());
                resultMes[iMes] = tmpMes.ToString();
                iMes++;
            }
            commonData.EncMesForBob = string.Join(" ", resultMes);
            //Отправляем Бобу
            (this.OwnedForms[0] as Form3).enHashTextBoxRight.Text = enHashForBob;
            (this.OwnedForms[0] as Form3).recieveFromServ();
        }
    }
}
