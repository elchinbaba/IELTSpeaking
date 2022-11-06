using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IELTSpeaking.Helpers;
using IELTSpeaking.Helpers.Speech;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace IELTSpeaking
{
    static class Game
    {
        public static IELTSpeaking iELTSpeaking;
        public static string text = "Good afternoon. My name is Kristina Pollock. Could I have your name, please?";
        public static bool isOn = true;
        public static int stage = 1;
        private static int _step = 0;
        private static List<string> _questionsPart1 = new List<string>{ "hi" }, _questionsPart3;
        private static string _questionsPart2;

        public static void TimerSpeak_Tick()
        {
            MMDevice device = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active)[1];
            iELTSpeaking.MicWave.Value = (int)Math.Round(device.AudioMeterInformation.MasterPeakValue * 100);
        }
        public static void tmrPart2_Tick()
        {
            iELTSpeaking.time -= 1;
            Controller.WriteControl(iELTSpeaking.lblPart2Time, '0' + (iELTSpeaking.time / 60).ToString() + ':');
            if (iELTSpeaking.time % 60 < 10)
            {
                Controller.WriteControl(iELTSpeaking.lblPart2Time, iELTSpeaking.lblPart2Time.Text + '0');
            }
            Controller.WriteControl(iELTSpeaking.lblPart2Time, iELTSpeaking.lblPart2Time.Text + (iELTSpeaking.time % 60).ToString());
        }
        private static void LoadImage()
        {
            iELTSpeaking.examinerImg.Image = new ExaminerImage().LoadImage();
        }
        public static void Start()
        {
            ReadDatabase readDatabase = new ReadDatabase();
            //_questionsPart1 = readDatabase.ReadPart1();
            _questionsPart2 = readDatabase.ReadPart2();
            _questionsPart3 = readDatabase.ReadPart3(readDatabase.ReadPart2Topic());

            Controller.HideControl(iELTSpeaking.MicWave);
            Controller.HideControl(iELTSpeaking.ContinueBtn);
            Controller.HideControl(iELTSpeaking.Part2TxtBox);
            Controller.HideControl(iELTSpeaking.lblPart2Time);

            LoadImage();
        }
        private static async Task Speak(Speech speech, string text)
        {
            Controller.Disable(iELTSpeaking.startBtn);
            await speech.SpeakAsync(text);
            //EnableBtn();
        }
        private static async Task Play()
        {
            Controller.ShowControl(iELTSpeaking.MicWave);
            Controller.StartTimer(iELTSpeaking.TimerSpeak);

            new WaveIn().StartRecording();

            await Task.Delay(3000);

            Controller.ShowControl(iELTSpeaking.ContinueBtn);
        }
        public static async void Go()
        {
            await Speak(new Speech(), text);

            Controller.HideControl(iELTSpeaking.startBtn);

            await Play();
        }
        public static async void Go2()
        {
            string part1End = "Thank you. That brings us to the end of Part One.";
            await Speak(new Speech(), part1End);

            string part2Start1 = "Now I am going to give you a topic and I would like to talk about it for one to two minutes.";
            await Speak(new Speech(), part2Start1);
            string part2Start2 = "Before you begin you have one minute to think about what you want to say. You can make some notes if you wish.";
            await Speak(new Speech(), part2Start2);

            Controller.HideControl(iELTSpeaking.examinerImg);
            Controller.WriteControl(iELTSpeaking.Part2TxtBox, text);
            Controller.ShowControl(iELTSpeaking.Part2TxtBox);
            Controller.HideControl(iELTSpeaking.startBtn);

            iELTSpeaking.time = 5;
            Controller.StartTimer(iELTSpeaking.tmrPart2);
            Controller.ShowControl(iELTSpeaking.lblPart2Time);
            await Task.Run(() => Task.Delay(iELTSpeaking.time * 1000));
            Controller.StopTimer(iELTSpeaking.tmrPart2);
            iELTSpeaking.time = 11;
            Controller.StartTimer(iELTSpeaking.tmrPart2);
            Controller.ShowControl(iELTSpeaking.MicWave);
            await Task.Run(() => Task.Delay(iELTSpeaking.time * 1000));

            Controller.ShowControl(iELTSpeaking.examinerImg);
            Controller.HideControl(iELTSpeaking.MicWave);
            Controller.HideControl(iELTSpeaking.lblPart2Time);
            Controller.ShowControl(iELTSpeaking.startBtn);
            Controller.StopTimer(iELTSpeaking.tmrPart2);

            NextStage();

            string part2End = "Thank you."; // Can I have the task card and the paper and pencil please.
            await Speak(new Speech(), part2End);

            string topic = new ReadDatabase().ReadPart2Topic();
            string part3Start = $"So, we have been talking about {topic} and I would like to discuss with you one or two more general questions related to this.";
            await Speak(new Speech(), part3Start);

            Go();
        }
        public static void Continue()
        {
            Controller.HideControl(iELTSpeaking.ContinueBtn);
            Controller.HideControl(iELTSpeaking.MicWave);
            Controller.ShowControl(iELTSpeaking.startBtn);

            NextStage();
            if (isOn)
            {
                if (stage == 2)
                {
                    Go2();
                }
                else
                {
                    Go();
                }
            }
        }
        private static void NextStage()
        {
            bool isEnd = stage == 3 && _step == _questionsPart3.Count;
            if (isEnd)
            {
                isOn = false;
                return;
            }

            if (stage == 1 && _step == _questionsPart1.Count || stage == 2)
            {
                stage++;
                _step = 0;
            }

            if (stage == 1)
            {
                text = _questionsPart1[_step];
                _step++;
            }
            else if (stage == 2)
            {
                text = _questionsPart2;
            }
            else if (stage == 3)
            {
                text = _questionsPart3[_step];
                _step++;
            }

        }
    }
}
