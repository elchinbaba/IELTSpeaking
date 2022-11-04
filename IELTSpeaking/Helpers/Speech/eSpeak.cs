using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSpeak;

namespace IELTSpeaking.Helpers.Speech
{
    class eSpeak
    {
        public void eSpeak_Speak()
        {
            Speaker speaker = Speaker.FromInstalled();
            speaker.SpeakText("Good afternoon. My name is Kristina Pollock. Could I have your name, please?");
        }
    }
}
