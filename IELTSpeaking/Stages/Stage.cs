using IELTSpeaking.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IELTSpeaking.Stages
{
    class Stage
    {
        public static async Task Go(string question)
        {
            try
            {
                await Game.Speak(question);

                Controller.HideControl(Game.iELTSpeaking.startBtn);

                await Game.Play(time: 10);
            }
            catch
            {
                MessageBox.Show("No question");
            }
        }
    }
}
