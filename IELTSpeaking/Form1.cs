using System;
using System.Windows.Forms;

namespace IELTSpeaking
{
    public partial class IELTSpeaking : Form
    {
        public IELTSpeaking()
        {
            InitializeComponent();
        }
        
        private void IELTSpeaking_Load(object sender, EventArgs e)
        {
            Game.iELTSpeaking = this;

            Game.Start();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Game.GoStart();
        }

        private void TimerSpeak_Tick(object sender, EventArgs e)
        {
            Game.TimerSpeak_Tick();
        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            Game.Continue();
        }

        private void tmrPart2_Tick(object sender, EventArgs e)
        {
            Game.tmrPart2_Tick();
        }
    }
}