using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab2
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

        public int numberOfPacket = 1;
        public bool falseCRC = false;

        private SerialPort port;
        public String Name { get; private set; }

        public ComPort(String name, int speed)
        {
            this.Name = name;

            try
            {
                port = new SerialPort(name, speed, Parity.None, 8, StopBits.One); //Инициализация: порт, скорость передачи, 
                //паритет, размера байта, коли-во стоп-битов
                port.ReadBufferSize = 204800;
                port.WriteBufferSize = 204800;
                port.Open();
            }
            catch (Exception e)
            {
                throw;
            }

            port.ErrorReceived += new SerialErrorReceivedEventHandler(serialPort_ErrorReceived);
            port.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
        }


        private byte prevByte = 0xFF;

        private bool isPacket = false;
        private List<bool> receiveData = new List<bool>();
        private int flagCount = 0;

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) //Получение данных
        {
            byte[] data = new byte[port.BytesToRead + 1];
            data[0] = prevByte; // 1111 1111
            port.Read(data, 1, data.Length-1);

            BitArray source = new BitArray(data);

            int i = Package.startFlag.Length;
            while (i < source.Length)
            {
                if (!isPacket) // Поиск начала пакета
                {
                    while (i < source.Length)
                    {
                        if (BitOperations.test(Package.startFlag, source, i))
                        {
                            isPacket = true;
                            i++;
                            flagCount = 0;

                            break;
                        }
                        i++;
                    }
                }
                else // Поиск конца пакета
                {
                    while (i < source.Length)
                    {
                        if (flagCount < Package.startFlag.Length)
                        {
                            receiveData.Add(source[i]);
                            i++;

                            flagCount++;
                        }
                        else
                        {
                            if (BitOperations.test(Package.startFlag, source, i))
                            {
                                isPacket = false;
                                //i += startFlag.Length;
                                i++;

                                receiveData.RemoveRange(receiveData.Count - Package.startFlag.Length + 1, Package.startFlag.Length - 1); //удаляем ране записанный (ошибочно?) флаг в интервале

                                byte[] packetData = Package.Unpackaging(receiveData, numberOfPacket);
                                numberOfPacket++;

                                Encoding enc = Encoding.GetEncoding(1251);
                                String readBuffer = enc.GetString(packetData);

                                OnRecievedEventArgs arg = new OnRecievedEventArgs(readBuffer);
                                OnRecived(this, arg);

                                receiveData.Clear();
                                break;
                            }
                            else
                            {
                                receiveData.Add(source[i]);
                                i++;
                            }
                        }                        
                    }
                }                
            }
            prevByte = data.Last();
        }

        private void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show(e.EventType.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void serialPort_SendData(String data, int packageLength) //Отправка данных
        {
            try
            {
                Encoding enc = Encoding.GetEncoding(1251);
                byte[] package = enc.GetBytes(data);

                package = Package.Packaging(package, packageLength, falseCRC); // Запаковываем в пакет длиной packageLength

                packageLength++;

                while (port.BytesToRead != 0) //наличие данных во входном буффере         
                    Thread.Sleep(20);

                port.RtsEnable = true; // Передатчик ON, т.к. по умолчанию наход-ся в р-ме приёма.
                port.Write(package, 0, package.Length);

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

        public bool isConnected()
        {
            if (port == null)
                return false;
            else
                return port.IsOpen;
        }
    }
}
