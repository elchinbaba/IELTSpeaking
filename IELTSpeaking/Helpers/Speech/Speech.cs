using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.IO;

namespace IELTSpeaking.Helpers.Speech
{
    class Speech
    {
        public async Task SpeakAsync(string text)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer()
            {
                
            };
            synthesizer.SelectVoice("Microsoft Zira Desktop");
            await Task.Run(() => synthesizer.Speak(text));
        }
    }
}
