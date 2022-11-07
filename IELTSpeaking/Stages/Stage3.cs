using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IELTSpeaking.Helpers;
using IELTSpeaking.Helpers.Speech;

namespace IELTSpeaking.Stages
{
    class Stage3 : IStage
    {
        List<string> questions;
        int currentQuestionID;
        public Stage3(List<string> questions)
        {
            this.questions = questions;
            currentQuestionID = 0;
        }
        public async Task Go()
        {
            await Stage.Go(questions[currentQuestionID]);
        }
        public IStage NextStage()
        {
            if (questions.Count > 0 && currentQuestionID != questions.Count - 1)
            {
                currentQuestionID++;
                return this;
            }
            return new StageFinish();
        }
    }
}
