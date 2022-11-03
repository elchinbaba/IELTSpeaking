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

namespace IELTSpeaking
{
    public partial class IELTSpeaking : Form
    {
        public IELTSpeaking()
        {
            InitializeComponent();
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
            //new Speech().AmazonSpeak();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            //new Speech().SpeechLib_5_4_Speak();
            //new Speech().Speak();
            new Speech().eSpeak_Speak();
            //new Speech().GenerateVoiceWavFromText("Good afternoon. My name is Kristina Pollock. Could I have your name, please?",
            //@"c:\", "yourfile");
            //new Read().ReadMP3();
        }
    }
}