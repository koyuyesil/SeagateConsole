using System.Diagnostics;
using System.IO.Ports;

namespace SeagateConsole
{
    public partial class SerialTestConsole : Form
    {
        SerialPortManager PM = new SerialPortManager("COM3", 115200);
        public SerialTestConsole()
        {
            //VSPE Virtual Serial Ports Emulator Yazılımı ile sanal port oluşturabilirsiniz.
            //https://eterlogic.com/Products.VSPE.html
            InitializeComponent();
            
            PM.SerialPort.DataReceived += SerialPort_DataReceived;
            //PM.OpenPort(5);
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            PM.ClosePort();
            PM.SerialPort.PortName = tbxPortName.Text;
            PM.SerialPort.BaudRate = Convert.ToInt32(tbxBaudRate.Text);
            PM.SerialPort.DataBits = 8;
            PM.SerialPort.Parity = Parity.None;
            PM.SerialPort.StopBits = StopBits.One;

            Debug.WriteLine("Port bekleniyor...");

            bool portOpened = await Task.Run(() => PM.OpenPort(5));

            Invoke(new Action(() =>
            {
                if (portOpened)
                {
                    Debug.WriteLine("Port başarıyla açıldı!");
                }
                else
                {
                    Debug.WriteLine("Port açılamadı.");
                }
            }));
        }

        private void SerialTestConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            PM.ClosePort();
        }

        private void textBoxConsole_Click(object sender, EventArgs e)
        {
            textBoxConsole.SelectionStart = textBoxConsole.TextLength;
            textBoxConsole.ScrollToCaret();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Veri alındığında bu metod çalışır
            string receivedData = PM.SerialPort.ReadExisting();

            // TextBox'a gelen veriyi ekleyin (UI işlemleri için Invoke kullanın)
            Invoke(new Action(() =>
            {
                textBoxConsole.AppendText(receivedData);
                textBoxConsole.SelectionStart = textBoxConsole.TextLength;
                textBoxConsole.ScrollToCaret();
            }));


            // Veri alındığında bu metod çalışır
            //int bytesToRead = serialPort.BytesToRead; // Alınan bayt sayısını kontrol et

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
                PM.SerialPort.Write(dataBytes, 0, dataBytes.Length);
            }
             
            // İşlemin tamamlanması için bu etkinliği işaretle texboxa yazı yazamaz.
            // e.Handled = true; // ve diğer tüm olayları bloke eder
        }

        private void textBoxConsole_KeyDown(object sender, KeyEventArgs e)
        {
            // e.Alt,e.Control,e.KeyCode,e.KeyData,e.KeyValue,e.Shift




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
    }
}
