using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeechLib;

namespace IELTSpeaking.Helpers.Speech
{
    class SpeechLib
    {
        public void SpeechLib_5_4_Speak()
        {
            SpVoice spVoice = new SpVoice();
            spVoice.Speak("Good afternoon. My name is Kristina Pollock. Could I have your name, please?");
        }
    }
}
