using System.IO.Ports;

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

        public bool OpenPort(int timeoutInSeconds)
        {
            int elapsedTime = 0;

            while (elapsedTime < timeoutInSeconds * 1000)
            {
                // Seri portu açıksa kapat kapalıysa aç
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
                    MessageBox.Show("Seri port açılamadı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                elapsedTime += 1000;
            }
            return false; // Belirtilen süre içinde port açılamazsa false döndür
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
