using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace IELTSpeaking.Helpers.Speech.Amazon
{
    class Read
    {
        public void ReadMP3()
        {
            try
            {
                Mp3FileReader reader = new Mp3FileReader("yourfile.mp3");
                WaveOutEvent waveOut = new WaveOutEvent();
                waveOut.Init(reader);
                waveOut.Play();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception caught: " + e.Message);
            }
        }
    }
}
