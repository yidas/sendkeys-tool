using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Threading;

namespace Sendkeys
{
    
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public static Boolean isStart = false;

        /**
         * @var Thread Task 
         */
        public static Thread thr;

        private Keys keyStart = Keys.D1;

        private Keys keyStop = Keys.D2;
        public Form1()
        {
            InitializeComponent();
            // ID:0 HotKey based on Shift: 4
            RegisterHotKey(this.Handle, 0, 4, keyStart.GetHashCode());
            RegisterHotKey(this.Handle, 0, 4, keyStop.GetHashCode());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                // Get Key
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);

                //MessageBox.Show("Hotkey "+ key +" has been pressed!");
                
                if (key == this.keyStart)
                {
                    this.serviceSwitch();
                }
                else if (key == this.keyStop)
                {
                    this.serviceSwitch();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ID:0
            UnregisterHotKey(this.Handle, 0);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.serviceSwitch();
        }

        private void serviceSwitch()
        {
            if (isStart)
            {
                switchButton.Text = "Start";
                thr.Abort();
                isStart = false;
            }
            else
            {
                switchButton.Text = "Stop";
                //serviceTimer.Start();
                thr = new Thread(task);
                thr.Start();
                isStart = true;
            }
        }

        private static void task()
        {
            Thread.Sleep(5000);

            while (true)
            {
                Sendkeys.end(true);
                Sendkeys.end();
                Sendkeys.end();

                Sendkeys.end();


                Sendkeys.end();
                Sendkeys.end(true);
                Sendkeys.end();
                Sendkeys.end(true);

                Sendkeys.end();

                // Swith turn
                Thread.Sleep(8000);

                for (int i = 0; i < 3; i++)
                {
                    Sendkeys.guard();
                }

                // Swith turn
                Thread.Sleep(8000);
            }
        }

        public class Sendkeys
        {
            public static int wait = 1000;
            public static int interval = 300;
            public static int fight = 12000;

            public const int S = (byte)Keys.S;
            public const int L = (byte)Keys.L;
            public const int A = (byte)Keys.A;

            public static void pressKey(Byte keyCode, int wait=100)
            {
                keybd_event(keyCode, 0, 0, 0);
                Thread.Sleep(wait);
                keybd_event(keyCode, 0, 2, 0);
            }
            public static void end(Boolean attackable=false)
            {
                pressKey(L);
                Thread.Sleep(interval);
                if (attackable)
                {
                    pressKey(S);
                    Thread.Sleep(interval);
                }
                pressKey(L);
                Thread.Sleep(interval);

                Thread.Sleep(wait);
            }
            public static void guard()
            {
                pressKey(S, 1000);
                pressKey(L);

                Thread.Sleep(fight);
            }
        }
    }

}
