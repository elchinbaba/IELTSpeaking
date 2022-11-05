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

namespace IELTSpeaking
{
    public partial class IELTSpeaking : Form
    {
        public IELTSpeaking()
        {
            InitializeComponent();
        }

        private void DisableBtn()
        {
            startBtn.Enabled = false;
        }
        private void EnableBtn()
        {
            startBtn.Enabled = true;
        }
        private void HideBtn()
        {
            startBtn.Visible = false;
        }
        private async Task Speak(Speech speech, string text)
        {
            DisableBtn();
            await speech.SpeakAsync(text);
            HideBtn();
            //EnableBtn();
        }
        private async Task Play()
        {
            MicWave.Visible = true;

            TimerSpeak.Start();
            new WaveIn().StartRecording();

            await Task.Delay(3000);

            ContinueBtn.Visible = true;
        }
        private void LoadImage()
        {
            examinerImg.Image = new ExaminerImage().LoadImage();
        }
        private async void Go()
        {
            await Speak(new Speech(), Game.text);

            await Play();
        }
        private void IELTSpeaking_Load(object sender, EventArgs e)
        {
            MicWave.Visible = false;
            ContinueBtn.Visible = false;

            Game.Start();
            LoadImage();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Go();
        }

        private void TimerSpeak_Tick(object sender, EventArgs e)
        {
            MMDevice device = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active)[1];
            MicWave.Value = (int)Math.Round(device.AudioMeterInformation.MasterPeakValue * 100);
        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            ContinueBtn.Visible = false;
            MicWave.Visible = false;
            startBtn.Visible = true;

            Game.NextStage();
            if (Game.isOn)
            {
                Go();
            }
        }
    }
}