using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IELTSpeaking.Helpers.Speech;
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using IELTSpeaking.Helpers;

namespace IELTSpeaking
{
    public partial class IELTSpeaking : Form
    {
        public int time;
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
            Game.Go();
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