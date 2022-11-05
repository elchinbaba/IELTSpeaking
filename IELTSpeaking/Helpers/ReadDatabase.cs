using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IELTSpeaking.Helpers
{
    class ReadDatabase
    {
        private static readonly List<Part1> _dataPart1 = new List<Part1>();
        private static readonly List<Part2> _dataPart2 = new List<Part2>();
        private static readonly List<Part3> _dataPart3 = new List<Part3>();

        public ReadDatabase()
        {
            string directory = CurrentDirectory.Directory + "\\Questions";

            ReadDataPart1(directory + "\\part1.txt");
            ReadDataPart2(directory + "\\part2.txt");
            ReadDataPart3(directory + "\\part3.txt");
        }
        private void ReadDataPart1(string part1Path)
        {
            if (File.Exists(part1Path))
            {
                string[] lines = File.ReadAllLines(part1Path);

                foreach (string line in lines)
                {
                    if (line.StartsWith("Ielts Speaking 1 Practice "))
                    {
                        string idTopic = line.Substring("Ielts Speaking 1 Practice ".Length);
                        _dataPart1.Add(new Part1(idTopic));
                    }
                    else
                    {
                        _dataPart1[_dataPart1.Count - 1].AddQuestion(line);
                    }
                }
            }
        }
        private void ReadDataPart2(string part2Path) { }
        private void ReadDataPart3(string part3Path) { }

        public List<string> ReadPart1()
        {
            Random rnd = new Random();
            int card = rnd.Next(_dataPart1.Count);
            List<string> questions = _dataPart1[card].questions;
            _dataPart1.RemoveAt(card);
            return questions;
        }
    }
}