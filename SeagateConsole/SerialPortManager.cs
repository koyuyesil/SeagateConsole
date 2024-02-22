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
        public SerialPort _serialPort;

        public SerialPortManager(string portName, int baudRate)
        {
            this._portName = portName;
            this._baudRate = baudRate;
            this._serialPort = new SerialPort(portName, baudRate);
        }

        public bool WaitForPort(int timeoutInSeconds)
        {
            int elapsedTime = 0;

            while (elapsedTime < timeoutInSeconds * 1000)
            {
                try
                {
                    if (!_serialPort.IsOpen)
                    {
                        _serialPort.Open();
                        return true;
                    }
                }
                catch (Exception)
                {
                    // Port açılamadı, beklemeye devam et
                }
                
                elapsedTime += 1000;
            }

            return false; // Belirtilen süre içinde port açılamazsa false döndür
        }

        public void ClosePort()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }
    }
}
