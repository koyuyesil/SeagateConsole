using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeagateConsole
{
    class SerialPortManager
    {
        private string _portName;
        private int _baudRate;
        private SerialPort serialPort;

        public SerialPort SerialPort { get => serialPort; set => serialPort = value; }

        public SerialPortManager(string portName, int baudRate)
        {
            this._portName = portName;
            this._baudRate = baudRate;
            this.SerialPort = new SerialPort(portName, baudRate);
        }

        public bool WaitForPort(int timeoutInSeconds)
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
            if (SerialPort.IsOpen)
            {
                SerialPort.Close();
            }
        }
    }
}
