﻿using System;
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

namespace IELTSpeaking
{
    class Speech
    {
        public string awsAccessKey = "";
        public string awsAccessSecret = "";

        public async void GenerateVoiceWavFromText(string textMessage, string path, string fileName)
        {
            string decodedKey = Encode.Decipher(awsAccessKey, 3);
            string decodedSecret = Encode.Decipher(awsAccessSecret, 3);

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

            var client = new AmazonPollyClient(decodedKey, decodedSecret, RegionEndpoint.USEast1);

            var synthesizeSpeechRequest = new SynthesizeSpeechRequest()
            {
                OutputFormat = OutputFormat.Pcm,
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
        public async void Speak()
        {
            string decodedKey = Encode.Decipher(awsAccessKey, 3);
            string decodedSecret = Encode.Decipher(awsAccessSecret, 3);

            AmazonPollyClient pc = new AmazonPollyClient(decodedKey, decodedSecret, RegionEndpoint.USEast1);

            SynthesizeSpeechRequest sreq = new SynthesizeSpeechRequest
            {
                Engine = "neural",
                OutputFormat = OutputFormat.Mp3,
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
    }
}
