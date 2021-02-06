using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePad
{
    public partial class Form1 : Form
    {



        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);



        string url1;
        string url2;
        string url3;
        string url4;
        string[] portlar_list;
        bool contiune;
        bool playing1;
        bool playing2;
        bool playing3;
        bool playing4;
     
        int equal1;
        int equal2;
        int equal3;
        int equal4;
        int equal5;
        int equal6;
        int equal7;
        int equal8;
        int equal9;
        int equal0;

        bool isMute;
        bool isWorking;

        string message;

        public Form1()
        {
            InitializeComponent();


          

        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            playing2 = false;
            playing3 = false;
            playing4 = false;

            if (url1 != null && playing1 == false)
            {
                axWindowsMediaPlayer1.URL = url3;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                playing1 = true;

            }
            if (url1 != null && playing1 == true && axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                playing1 = false;

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            if (serialPort1.IsOpen == true & portlar_list.Length > 0)
            {
                serialPort1.Close();
                contiune = false;
                button4.Text = "Başlat";
                button4.BackColor = Color.Green;

            }

            else if (portlar_list.Length > 0 && portlar.Text != "Cihaz Yok")
            {
                serialPort1.Open();
                button4.Text = "Durdur";
                button4.BackColor = Color.Red;
                timer2.Enabled = true;
                timer3.Enabled = true;
                contiune = true;


            }
            else
            { MessageBox.Show("Port Bulunamadı "); }
        }

        private void portlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = portlar.SelectedItem.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Basla();
            contiune = false;
            url1 = null;
            url2 = null;
            url3 = null;
            url4 = null;
            playing1 = false;
            playing2 = false;
            playing3 = false;
            playing4 = false;
            equal1 = 0;
            equal2 = 0;
            equal3 = 0;
            equal4 = 0;
            equal5 = 0;
            equal6 = 0;
            equal7 = 0;
            equal8 = 0;
            equal9 = 0;
            isMute = false;
            isWorking=false;

        }

        public void Basla()
        {
            timer1.Enabled = true;
            timer1.Start();
            portlar_list = System.IO.Ports.SerialPort.GetPortNames();
            portlar.Items.AddRange(portlar_list);
            contiune = false;



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (portlar_list.Length == 0)
            {

                portlar_list = System.IO.Ports.SerialPort.GetPortNames();
                portlar.Items.AddRange(portlar_list);
            }
            else
            {
                serialPort1.BaudRate = 9600;
                serialPort1.StopBits = StopBits.One;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
              
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (contiune == true)
            {

                try
                {
                    message = serialPort1.ReadExisting();
                    

                 
                   
                  
                    richTextBox1.AppendText(message.ToString());
                    richTextBox1.ScrollToCaret();

                   
                   
                       
                    

                }

                catch (Exception exception)
                {


                }
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)

            {

                openFileDialog1.Filter = "Media File(*.mpg,*.dat,*.avi,*.wmv,*.wav,*.mp3)|*.wav;*.mp3;*.mpg;*.dat;*.avi;*.wmv";
                //Müzik çaların çalabileceği dosyaları FileDialog sayesinde filtreledik.
                openFileDialog1.InitialDirectory = Application.StartupPath;
                openFileDialog1.Title = "Dosya Seç";
                openFileDialog1.ShowDialog();
                url1 = openFileDialog1.FileName;
               

            }
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)

            {

                openFileDialog1.Filter = "Media File(*.mpg,*.dat,*.avi,*.wmv,*.wav,*.mp3)|*.wav;*.mp3;*.mpg;*.dat;*.avi;*.wmv";
                //Müzik çaların çalabileceği dosyaları FileDialog sayesinde filtreledik.
                openFileDialog1.InitialDirectory = Application.StartupPath;
                openFileDialog1.Title = "Dosya Seç";
                openFileDialog1.ShowDialog();
                url2 = openFileDialog1.FileName;


            }
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)

            {

                openFileDialog1.Filter = "Media File(*.mpg,*.dat,*.avi,*.wmv,*.wav,*.mp3)|*.wav;*.mp3;*.mpg;*.dat;*.avi;*.wmv";
                //Müzik çaların çalabileceği dosyaları FileDialog sayesinde filtreledik.
                openFileDialog1.InitialDirectory = Application.StartupPath;
                openFileDialog1.Title = "Dosya Seç";
                openFileDialog1.ShowDialog();
                url3 = openFileDialog1.FileName;

            }
        }

     
        private void button2_Click(object sender, EventArgs e)
        {
           
            playing1 = false;
            playing3 = false;
            playing4 = false;

            if (url2 != null && playing2 == false)
            {
                axWindowsMediaPlayer1.URL = url2;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                playing2 = true;

            }
            if (url2 != null && playing2 == true && axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                playing2 = false;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            playing1 = false;
            playing2 = false;
            playing4 = false;

            if ( url3!=null &&playing3 == false)
            {
                axWindowsMediaPlayer1.URL = url3;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                playing3 = true;

            }
            if(url3 != null && playing3 ==true && axWindowsMediaPlayer1.playState==WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                playing3 = false;

            }
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
               

            }
        }

        public void parca1()
        {
            equal1 = 0;
            equal2 = 0;
            equal3 = 0;
            equal4 = 0;
           
            playing2 = false;
            playing3 = false;
            playing4 = false;

            if (url1 != null && playing1 == false)
            {
                axWindowsMediaPlayer1.URL = url1;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                playing1 = false;

            }
    




        }
        public void parca2()
        {
            equal2 = 0;
            equal1 = 0;
            equal3 = 0;
            equal4 = 0;
            
            playing1 = false;
            playing3 = false;
            playing4 = false;

            if (url2 != null && playing2 == false)
            {
                axWindowsMediaPlayer1.URL = url2;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                playing2 = true;

            }
          
        }
        public void parca3()
        {
            equal3 = 0;
            equal1 = 0;
            equal2 = 0;
            equal4 = 0;
            playing1 = false;
            playing2 = false;
            playing4 = false;

            if (url3 != null && playing3 == false)
            {
                axWindowsMediaPlayer1.URL = url3;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                playing3 = true;

            }
           
        }
        public void parca4()
        {
            equal4 = 0;
            equal1 = 0;
            equal2 = 0;
            equal3 = 0;
            playing1 = false;
            playing2 = false;
            playing3 = false;

            if (url4 != null && playing4 == false)
            {
                axWindowsMediaPlayer1.URL = url4;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                playing4 = true;

            }
          
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            if (equal0== 0)
            { equal0= FindMyText( "0"); }

            if (equal0== 1 )
            { axWindowsMediaPlayer1.Ctlcontrols.stop();
                richTextBox1.Clear();
                equal0 = 0;
            }


            if (equal1==0)
            { equal1 = FindMyText("1"); }
         
            if(equal1==1&&playing1==false)
            {parca1();
               

            }

            if (equal2 == 0)
            { equal2 = FindMyText("2" ); }

            if (equal2 == 1 && playing2 == false )
            { parca2();
               
            }

            if (equal3 == 0)
            { equal3 = FindMyText("3"); }

            if (equal3 == 1 && playing3 == false )
            {   parca3();
              
            }

            if (equal4 == 0)
            { equal4= FindMyText("4"); }

            if (equal4 == 1  )
            {
                SendKeys.SendWait("%{TAB}");
                SendKeys.Send("%{LEFT}");
                richTextBox1.Clear();
                equal4 = 0;
               
            }

            if (equal5 == 0 )
            { equal5= FindMyText("5"); }

            if (equal5== 1 && playing4 == false)
            {   parca4();
                
            }


            if (equal6 == 0)
            { equal6 = FindMyText("6"); }

            if (equal6== 1 )
            {
                SendKeys.SendWait("%{TAB}");
                SendKeys.Send("%{RIGHT}");
                equal6 = 0;
                richTextBox1.Clear();
                
            }


            if (equal7 == 0)
            { equal7= FindMyText("7"); }

            if (equal7 == 1)
            {   VolDown();
                equal7= 0;
              
            }


            if (equal8 == 0)
            { equal8 = FindMyText("8");
             
            }

            if (equal8 == 1 )
            {
                isMute = true;
                Mute();
               
              
            }


            if (equal9 == 0)
            { equal9 = FindMyText("9"); }

            if (equal9 == 1 )
            {   VolUp();
                equal9 = 0;
             
            }




            richTextBox1.Clear();




        }
        public int FindMyText(string text)
        {
            // Initialize the return value to false by default.
            int returnValue = 0;

            // Ensure that a search string has been specified and a valid start point.
            if (text.Length > 0)
            {
                // Obtain the location of the first character found in the control
                // that matches any of the characters in the char array.
                int indexToText = richTextBox1.Find(text);
                // Determine whether the text was found in richTextBox1.
                if (indexToText >= 0)
                {
                    // Return the location of the character.
                    returnValue = 1;
                  
                }
            }

            return returnValue;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            SendKeys.SendWait("%{TAB}");
            SendKeys.Send("%{LEFT}");


        }

   

        private void button7_Click(object sender, EventArgs e)
        {
            playing1 = false;
            playing2 = false;
            playing3 = false;

            equal4 = 0;
            equal1 = 0;
            equal2 = 0;
            equal3 = 0;

            if (url4 != null && playing4 == false)
            {
                axWindowsMediaPlayer1.URL = url4;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                playing4 = true;

            }
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)

            {

                openFileDialog1.Filter = "Media File(*.mpg,*.dat,*.avi,*.wmv,*.wav,*.mp3)|*.wav;*.mp3;*.mpg;*.dat;*.avi;*.wmv";
                //Müzik çaların çalabileceği dosyaları FileDialog sayesinde filtreledik.
                openFileDialog1.InitialDirectory = Application.StartupPath;
                openFileDialog1.Title = "Dosya Seç";
                openFileDialog1.ShowDialog();
                url4 = openFileDialog1.FileName;

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("%{TAB}");
            SendKeys.Send("%{RIGHT}");
        }

        private void Mute()
        {

           if(isMute==true)
            {
                
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                    (IntPtr)APPCOMMAND_VOLUME_MUTE);

                equal7 = 0;
                equal8 = 0;
                equal9 = 0;
                isMute = false;
            }
          
        }

        private void VolDown()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_DOWN);


            equal7 = 0;
            equal8 = 0;
            equal9 = 0;
            isMute = true;
        }

        private void VolUp()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);

            equal7 = 0;
            equal8 = 0;
            equal9 = 0;
            isMute = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            VolDown();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            VolUp();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Mute();
           

        }
    }

}

