using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IELTSpeaking.Helpers;
using IELTSpeaking.Stages;
using IELTSpeaking.Helpers.Speech;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace IELTSpeaking
{
    static class Game
    {
        public static IELTSpeaking iELTSpeaking;
        public static IStage stage;
        public static List<string> questionsPart1 = new List<string>{ "hi" }, questionsPart3 = new List<string>{ "bye" };
        public static string questionsPart2;
        public static MMDevice device;

        private static void CheckMicrophone()
        {
            MMDeviceCollection devices = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            foreach (MMDevice dev in devices)
            {
                if (dev.FriendlyName.StartsWith("Microphone"))
                {
                    device = dev;
                    return;
                }
            }
            throw new Exception("No Microphone");
        }

        public static void TimerSpeak_Tick()
        {
            int value = (int)Math.Round(device.AudioMeterInformation.MasterPeakValue * 100);
            int random = new Random().Next(15, 25);
            if (value > 0 && value < 50) value += random;
            iELTSpeaking.MicWave.Value = value;
        }
        public static void tmrPart2_Tick()
        {
            (stage as Stage2).tmrPart2_Tick();
        }
        private static void LoadImage()
        {
            iELTSpeaking.examinerImg.Image = new ExaminerImage().LoadImage();
        }

        public static async Task Speak(string text)
        {
            Controller.Disable(iELTSpeaking.startBtn);
            await new Speech().SpeakAsync(text);
        }
        public static async Task Play(int time)
        {
            Controller.ShowControl(iELTSpeaking.MicWave);

            try
            {
                CheckMicrophone();

                Controller.StartTimer(iELTSpeaking.TimerSpeak);

                new WaveIn().StartRecording();

                await Task.Delay(time * 1000);

                Controller.ShowControl(iELTSpeaking.ContinueBtn);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private static void InitStage()
        {
            stage = new Stage1(questionsPart1);
        }
        private static void ReadDatabase()
        {
            ReadDatabase readDatabase = new ReadDatabase();
            questionsPart1 = readDatabase.ReadPart1();
            questionsPart2 = readDatabase.ReadPart2();
            questionsPart3 = readDatabase.ReadPart3(readDatabase.ReadPart2Topic());
        }
        public static void Start()
        {
            ReadDatabase();
            InitStage();

            Controller.HideControl(iELTSpeaking.MicWave);
            Controller.HideControl(iELTSpeaking.ContinueBtn);
            Controller.HideControl(iELTSpeaking.Part2TxtBox);
            Controller.HideControl(iELTSpeaking.lblPart2Time);

            LoadImage();
        }

        public static async void GoStart()
        {
            await Speak("Good afternoon. My name is Kristina Pollock. Could I have your name?");

            Controller.WriteControl(iELTSpeaking.ContinueBtn, "Continue");
            Controller.HideControl(iELTSpeaking.startBtn);

            await Play(time: 3);
        }
        public static async Task Go()
        {
            await stage.Go();
        }

        public static void NextStage()
        {
            stage = stage.NextStage();
            if (stage.GetType().Name == "StageFinish")
            {
                Controller.WriteControl(iELTSpeaking.ContinueBtn, "Finish");
            }
        }
        public async static void Continue()
        {
            Controller.HideControl(iELTSpeaking.ContinueBtn);
            Controller.HideControl(iELTSpeaking.MicWave);

            if (stage.GetType().Name != "StageFinish")
            {
                Controller.ShowControl(iELTSpeaking.startBtn);
                await Go();
                NextStage();
            }
            else
            {
                Finish();
            }
        }
        public async static void Finish()
        {
            await Speak("Well. Thank you very much. That is the end of the Speaking Test");

            Controller.Enable(iELTSpeaking.startBtn);
            Controller.WriteControl(iELTSpeaking.startBtn, "Restart");
            Controller.ShowControl(iELTSpeaking.startBtn);

            ReadDatabase();
            InitStage();
        }
    }
}
