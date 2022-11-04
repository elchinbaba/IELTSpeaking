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
        private async void Speak(Speech speech, string text)
        {
            DisableBtn();
            await speech.SpeakAsync(text);
            EnableBtn();
        }
        private void ReadDB()
        {
            ReadDatabase readDatabase = new ReadDatabase();
            List<string> questions = readDatabase.ReadPart1();
        }
        private void LoadImage()
        {
            examinerImg.Image = new ExaminerImage().LoadImage();
        }

        private void IELTSpeaking_Load(object sender, EventArgs e)
        {
            ReadDB();
            LoadImage();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Speech speech = new Speech();
            string text = "Good afternoon. My name is Kristina Pollock. Could I have your name, please?";
            Speak(speech, text);
        }
    }
}