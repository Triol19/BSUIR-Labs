using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{

    public class OnRecievedEventArgs : EventArgs
    {
        private String data;

        public OnRecievedEventArgs(String data)
        {
            this.data = data;
        }

        public String Data
        {
            get
            {
                return data;
            }
        }
    }

    public delegate void OnRecievedHandler(object sender, OnRecievedEventArgs e);


    class ComPort
    {
        public event OnRecievedHandler OnRecived;

        private SerialPort port;
        public String Name { get; private set; }

        public ComPort(String name, int speed)
        {
            this.Name = name;

            try
            {
                port = new SerialPort(name, speed, Parity.None, 8, StopBits.One); //Инициализация: порт, скорость передачи, паритет, размера байта, коли-во стоп-битов
                port.ReadBufferSize = 2048;
                port.WriteBufferSize = 2048;
                port.Open();
            }
            catch (Exception e)
            {
                throw;
            }

            port.ErrorReceived += new SerialErrorReceivedEventHandler(serialPort_ErrorReceived);
            port.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) //Получение данных
        {
            byte[] data = new byte[port.BytesToRead];
            port.Read(data, 0, data.Length);


            Encoding enc = Encoding.GetEncoding(1251);
            String readBuffer = enc.GetString(data);

            OnRecievedEventArgs arg = new OnRecievedEventArgs(readBuffer);
            OnRecived(this, arg);
        }

        private void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show(e.EventType.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void serialPort_SendData(String data) //Отправка данных
        {
            try
            {
                Encoding enc = Encoding.GetEncoding(1251);
                byte[] package_b = enc.GetBytes(data);

                while (port.BytesToRead != 0)     //наличие данных во входном буффере       
                    Thread.Sleep(20);            

                port.RtsEnable = true; // Передатчик ON, т.к. по умолчанию наход-ся в р-ме приёма.
                port.Write(package_b, 0, package_b.Length);

                Thread.Sleep(100);      // пауза для корректного завершения работы передатчика
                port.RtsEnable = false; // Передатчик OFF
            }
            catch(Exception ex)
            {
                port.RtsEnable = false;
                throw ex;
            }
        }

        public void close()
        {
            /*Проверка состояния состоит в проверке наличия данных во входном
            буфере. Может использоваться, например, для контроля доступности среды
            передачи.*/
            while (port.BytesToRead != 0)
            {
                Thread.Sleep(50);
            }
            port.Close();
        }

        public bool isActive()
        {
            return port.IsOpen;
        }

    }
}
