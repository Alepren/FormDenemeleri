using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SeriPortDeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // foreach(var seriport in SerialPort.GetPortNames())
            // {
            //     comboBoxPorts.Items.Add(seriport);
            // }

            buttonDisconnect.Enabled = false;
            buttonSend.Enabled = false;


            try
            {
                string[] portNames = SerialPort.GetPortNames();

                if (portNames.Length > 0)
                {
                    comboBoxPorts.Items.AddRange(portNames);
                    comboBoxPorts.SelectedIndex = 0; 
                }
                else
                {
                    MessageBox.Show("Hiçbir seri port bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seri portlar alınırken bir hata oluştu: " + ex.Message);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBoxPorts.Text;
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits= StopBits.One;
            serialPort1.DataBits = 8;

            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Seri port bağlantısı yapılamadı.\n" +
                    $"Hata : {ex.Message}","Problem",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            if(serialPort1.IsOpen)
            {
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
                buttonSend.Enabled = true;

            }

        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();

                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
                buttonSend.Enabled = false;

            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(textBoxSender.Text);  
                textBoxSender.Clear();
            }
        }
        public delegate void veriGoster(string s);

        public void textBoxYaz(string s)
        {
            textBoxRecevier.Text += s;
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string gelenVeri = serialPort1.ReadExisting();
            textBoxRecevier.Invoke(new veriGoster(textBoxYaz),gelenVeri);
        }
    }
}
