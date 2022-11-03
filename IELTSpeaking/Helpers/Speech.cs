using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Windows.Forms;
using Amazon.Polly;
using Amazon.Polly.Model;
using System.IO;
using Amazon;
using NAudio.Wave;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using SpeechLib;
using eSpeak;

namespace IELTSpeaking
{
    class Speech
    {
        private static readonly string _key = Credentials.awsAccessKey;
        private static readonly string _secret = Credentials.awsAccessSecret;
        private static readonly string speechKey = Environment.GetEnvironmentVariable("SPEECH_KEY");
        private static readonly string speechRegion = Environment.GetEnvironmentVariable("SPEECH_REGION");
        public async void GenerateVoiceWavFromText(string textMessage, string path, string fileName)
        {
            if (string.IsNullOrEmpty(textMessage))
            {
                throw new Exception("textMessage can't be empty");
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new Exception("path can't be empty");
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("fileName can't be empty");
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string outputFileName = Path.Combine(path, fileName);

            var client = new AmazonPollyClient(_key, _secret, RegionEndpoint.USEast1);

            var synthesizeSpeechRequest = new SynthesizeSpeechRequest()
            {
                OutputFormat = Amazon.Polly.OutputFormat.Pcm,
                VoiceId = VoiceId.Brian,
                Text = textMessage,
            };

            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
            {
                var synthesizeSpeechResponse = await client.SynthesizeSpeechAsync(synthesizeSpeechRequest);
                byte[] buffer = new byte[2 * 1024];
                int readBytes;

                var inputStream = synthesizeSpeechResponse.AudioStream;
                while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                {
                    outputStream.Write(buffer, 0, readBytes);
                }

                outputStream.Flush();
                outputStream.Close();
            }

            using (var readPcmStream = File.OpenRead(outputFileName))
            {
                using (var rawWaveStream = new RawSourceWaveStream(readPcmStream, new WaveFormat(16000, 1)))
                {
                    var outpath = outputFileName + ".wav";
                    WaveFileWriter.CreateWaveFile(outpath, rawWaveStream);

                    rawWaveStream.Close();
                }

                readPcmStream.Close();
            }
        }
        public async void AmazonSpeak()
        {
            AmazonPollyClient pc = new AmazonPollyClient(_key, _secret, RegionEndpoint.USEast1);

            SynthesizeSpeechRequest sreq = new SynthesizeSpeechRequest
            {
                Engine = "neural",
                OutputFormat = Amazon.Polly.OutputFormat.Mp3,
                Text = "Good afternoon. My name is Kristina Pollock. Could I have your name, please?",
                VoiceId = VoiceId.Ayanda
            };

            SynthesizeSpeechResponse sres = await pc.SynthesizeSpeechAsync(sreq);
            using (var fileStream = File.Create(CurrentDirectory.Directory + "\\yourfile.mp3"))
            {
                sres.AudioStream.CopyTo(fileStream);
                fileStream.Flush();
                fileStream.Close();
            }
        }

        static void OutputSpeechSynthesisResult(SpeechSynthesisResult speechSynthesisResult, string text)
        {
            switch (speechSynthesisResult.Reason)
            {
                case ResultReason.SynthesizingAudioCompleted:
                    Console.WriteLine($"Speech synthesized for text: [{text}]");
                    break;
                case ResultReason.Canceled:
                    var cancellation = SpeechSynthesisCancellationDetails.FromResult(speechSynthesisResult);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                        Console.WriteLine($"CANCELED: Did you set the speech resource key and region values?");
                    }
                    break;
                default:
                    break;
            }
        }

        public async void AzureSpeak()
        {
            var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);

            speechConfig.SpeechSynthesisVoiceName = "en-US-JennyNeural";

            using (var speechSynthesizer = new Microsoft.CognitiveServices.Speech.SpeechSynthesizer(speechConfig))
            {
                // Get text from the console and synthesize to the default speaker.
                string text = "Good afternoon. My name is Kristina Pollock. Could I have your name, please?";

                var speechSynthesisResult = await speechSynthesizer.SpeakTextAsync(text);
                OutputSpeechSynthesisResult(speechSynthesisResult, text);
            }
        }

        public void Speak()
        {
            var synthesizer = new System.Speech.Synthesis.SpeechSynthesizer();
            PromptBuilder builder = new PromptBuilder();
            builder.AppendText("That is a big pizza!");
            foreach (InstalledVoice voice in synthesizer.GetInstalledVoices())
            {
                System.Speech.Synthesis.VoiceInfo info = voice.VoiceInfo;
                MessageBox.Show(" Voice Name: " + info.Name);
            }
            synthesizer.SelectVoice("Microsoft Zira Desktop");

            synthesizer.SpeakAsync("Good afternoon. My name is Kristina Pollock. Could I have your name, please?");
        }
        public void SpeechLib_5_4_Speak()
        {
            SpVoice spVoice = new SpVoice();
            spVoice.Speak("Good afternoon. My name is Kristina Pollock. Could I have your name, please?");
        }
        public void eSpeak_Speak()
        {
            Speaker speaker = Speaker.FromInstalled();
            speaker.SpeakText("Good afternoon. My name is Kristina Pollock. Could I have your name, please?");
        }
    }
}
