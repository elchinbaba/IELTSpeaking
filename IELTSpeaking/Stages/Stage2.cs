using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IELTSpeaking.Helpers;
using IELTSpeaking.Helpers.Speech;

namespace IELTSpeaking.Stages
{
    class Stage2 : IStage
    {
        public int time;
        string questions;
        public Stage2(string questions)
        {
            this.questions = questions;
        }
        public void tmrPart2_Tick()
        {
            time -= 1;
            Controller.WriteControl(Game.iELTSpeaking.lblPart2Time, '0' + (time / 60).ToString() + ':');
            if (time % 60 < 10)
            {
                Controller.WriteControl(Game.iELTSpeaking.lblPart2Time, Game.iELTSpeaking.lblPart2Time.Text + '0');
            }
            Controller.WriteControl(Game.iELTSpeaking.lblPart2Time, Game.iELTSpeaking.lblPart2Time.Text + (time % 60).ToString());
        }
        public async Task Go()
        {
            string part1End = "Thank you. That brings us to the end of Part One.";
            await Game.Speak(part1End);

            string part2Start1 = "Now I am going to give you a topic and I would like to talk about it for one to two minutes.";
            await Game.Speak(part2Start1);
            string part2Start2 = "Before you begin you have one minute to think about what you want to say. You can make some notes if you wish.";
            await Game.Speak(part2Start2);

            Controller.HideControl(Game.iELTSpeaking.examinerImg);
            Controller.WriteControl(Game.iELTSpeaking.Part2TxtBox, questions);
            Controller.ShowControl(Game.iELTSpeaking.Part2TxtBox);
            Controller.HideControl(Game.iELTSpeaking.startBtn);

            time = 60;
            Controller.StartTimer(Game.iELTSpeaking.tmrPart2);
            Controller.ShowControl(Game.iELTSpeaking.lblPart2Time);
            await Task.Run(() => Task.Delay(time * 1000));
            Controller.StopTimer(Game.iELTSpeaking.tmrPart2);

            await Game.Speak("So now you have two minutes to talk about this topic.");

            time = 120;
            Controller.StartTimer(Game.iELTSpeaking.tmrPart2);
            Controller.ShowControl(Game.iELTSpeaking.MicWave);
            await Task.Run(() => Task.Delay(time * 1000));

            Controller.ShowControl(Game.iELTSpeaking.examinerImg);
            Controller.HideControl(Game.iELTSpeaking.MicWave);
            Controller.HideControl(Game.iELTSpeaking.lblPart2Time);
            Controller.ShowControl(Game.iELTSpeaking.startBtn);
            Controller.StopTimer(Game.iELTSpeaking.tmrPart2);

            //string part2End = "Thank you."; // Can I have the task card and the paper and pencil please.
            //await Game.Speak(part2End);

            string topic = new ReadDatabase().ReadPart2Topic();
            string part3Start = $"So, we have been talking about {topic} and I would like to discuss with you one or two more general questions related to this.";
            await Game.Speak(part3Start);

            Game.NextStage();
            await Game.Go();
        }
        public IStage NextStage()
        {
            return new Stage3(Game.questionsPart3);
        }
    }
}
