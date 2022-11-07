using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IELTSpeaking.Stages
{
    class StageFinish : IStage
    {
        public async Task Go() { await Task.Run(() => Task.Delay(0)); }
        public IStage NextStage()
        {
            return this;
        }
    }
}
