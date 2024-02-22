using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeagateConsole
{
    public partial class SerialTestConsole : Form
    {
        SerialPort serialPort;
        public SerialTestConsole()
        {
            InitializeComponent();
            // SerialPort nesnesini oluştur
            serialPort = new SerialPort();
            serialPort.PortName = "COM11"; // Kullanılacak seri portun adını belirtin
            serialPort.BaudRate = 115200;   // Baud hızını ayarlayın (örneğin, 9600)
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataReceived += SerialPort_DataReceived; // Veri alındığında çalışacak olayı belirtin

            ConnectToSerial();
        }

        private void ConnectToSerial()
        {
            // Seri portu aç
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seri port açılamadı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Veri alındığında bu metod çalışır
            string receivedData = serialPort.ReadExisting();

            // TextBox'a gelen veriyi ekleyin (UI işlemleri için Invoke kullanın)
            Invoke(new Action(() =>
            {
                textBoxConsole.AppendText(receivedData);
            }));


            // Veri alındığında bu metod çalışır
            int bytesToRead = serialPort.BytesToRead; // Alınan bayt sayısını kontrol et

            //if (bytesToRead > 0)
            //{
            //    byte[] buffer = new byte[bytesToRead];

            //    // Seri porttan veriyi oku
            //    serialPort.Read(buffer, 0, bytesToRead);

            //    // Okunan baytları stringe çevir
            //    string receivedData = Encoding.ASCII.GetString(buffer);

            //    // TextBox'a gelen veriyi ekleyin (UI işlemleri için Invoke kullanın)
            //    Invoke(new Action(() =>
            //    {
            //        textBoxConsole.AppendText(receivedData);
            //    }));
            //}


        }

        private void textBoxConsole_KeyPress(object sender, KeyPressEventArgs e)
        {
            byte[] dataBytes = null;

            // Özel tuşları kontrol et
            if (e.KeyChar == (char)Keys.Enter)
            {
                dataBytes = new byte[] { 13, 10 }; // CR (Carriage Return) ve LF (Line Feed)
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                dataBytes = new byte[] { 8 }; // Backspace
            }
            else if (e.KeyChar == (char)Keys.Tab)
            {
                dataBytes = new byte[] { 9 }; // Tab
            }
            else if (Char.IsDigit(e.KeyChar) || Char.IsLetter(e.KeyChar))
            {
                // Numerik veya harf tuşlara basıldığında ASCII değeriyle gönder
                dataBytes = new byte[] { (byte)e.KeyChar };
            }

            // Seri porta baytları gönder
            if (dataBytes != null)
            {
                serialPort.Write(dataBytes, 0, dataBytes.Length);
            }

            // İşlemin tamamlanması için bu etkinliği işaretle
            //e.Handled = true;
        }

        private void textBoxConsole_KeyDown(object sender, KeyEventArgs e)
        {
            //byte[] dataBytes = null;

            //// Özel tuşları kontrol et
            //if (e.Control && e.KeyCode == Keys.C)
            //{
            //    // Ctrl + C tuş kombinasyonu
            //    dataBytes = new byte[] { 3 }; // ETX (End of Text)
            //}
            //else if (e.Control && e.KeyCode == Keys.V)
            //{
            //    // Ctrl + V tuş kombinasyonu
            //    dataBytes = new byte[] { 22 }; // SYN (Synchronous Idle)
            //}
            //else if (e.Control && e.KeyCode == Keys.X)
            //{
            //    // Ctrl + X tuş kombinasyonu
            //    dataBytes = new byte[] { 24 }; // CAN (Cancel)
            //}
            //else if (e.Control && e.KeyCode == Keys.Z)
            //{
            //    // Ctrl + X tuş kombinasyonu
            //    dataBytes = new byte[] { 26 }; // CAN (Cancel)
            //}
            //else if (e.KeyCode == Keys.Enter)
            //{
            //    // Enter tuşu basıldığında yeni satır ekle
            //    dataBytes = new byte[] { 13, 10 }; // CR (Carriage Return) ve LF (Line Feed)
            //}
            //else if (e.KeyCode == Keys.Back)
            //{
            //    // Backspace tuşu basıldığında bir karakteri sil
            //    dataBytes = new byte[] { 8 }; // Backspace
            //}
            //else if (e.KeyCode == Keys.Tab)
            //{
            //    // Tab tuşu basıldığında tab karakteri gönder
            //    dataBytes = new byte[] { 9 }; // Tab
            //}
            //else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            //{
            //    // Numerik tuşlara basıldığında ASCII değeriyle gönder
            //    dataBytes = new byte[] { (byte)e.KeyCode };
            //}
            //else
            //{
            //    // Diğer tuşlarda basıldığında, tuşun ASCII değerini bayt olarak seri porta gönder
            //    dataBytes = new byte[] { (byte)e.KeyValue };
            //}

            //// Seri porta baytları gönder
            //if (dataBytes != null)
            //{
            //    serialPort.Write(dataBytes, 0, dataBytes.Length);

            //}

            //// İşlemin tamamlanması için bu etkinliği işaretle
            //e.Handled = true;

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToSerial();
        }


    }
}
