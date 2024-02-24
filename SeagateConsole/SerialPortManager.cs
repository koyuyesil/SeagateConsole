using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;

namespace SeagateConsole
{
    class SerialPortManager
    {
        private SerialPort? serialPort;
        public SerialPort SerialPort { get => serialPort; set => serialPort = value; }

        public SerialPortManager(string portName, int baudRate)
        {
            serialPort = new SerialPort(portName, baudRate);
            //SerialPort.DataBits = 8;
            //SerialPort.Parity = Parity.None;
            //SerialPort.StopBits = StopBits.One;
        }


        public bool OpenPort2(int timeoutInSeconds) {

            DateTime startTime = DateTime.Now;
            TimeSpan duration = TimeSpan.FromSeconds(timeoutInSeconds);

            while (DateTime.Now - startTime < duration)
            {
                ShowMessageBox($"Döngü çalışıyor...{DateTime.Now - startTime}");
            }

            Console.WriteLine("Döngü bitti.");
            return false;
        }

        private void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        public bool OpenPort(int timeoutInSeconds)
        {
            DateTime startTime = DateTime.Now;
            TimeSpan duration = TimeSpan.FromSeconds(timeoutInSeconds);
            while (DateTime.Now - startTime < duration)
            {
                try
                {
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }
                    serialPort.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Seri port açılamadı: " + ex.Message, "Hata");
                    //MessageBox.Show("Seri port açılamadı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        public void ClosePort()
        {
            // Seri portu kapat
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seri port kapatılamadı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
