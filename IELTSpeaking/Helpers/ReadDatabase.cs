using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IELTSpeaking.Helpers
{
    class ReadDatabase
    {
        private static readonly List<Part1> _dataPart1 = new List<Part1>();
        private static readonly List<Part2> _dataPart2 = new List<Part2>();
        private static readonly List<Part3> _dataPart3 = new List<Part3>();

        private static string _topicPart2;

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
        //private void CheckData2To3()
        //{
        //    foreach (Part2 part2 in _dataPart2)
        //    {
        //        if (!Check(part2))
        //        {
        //            MessageBox.Show(part2.idTopic);
        //        }
        //    }
        //}

        //private bool Check(Part2 part2)
        //{
        //    foreach (Part3 part3 in _dataPart3)
        //    {
        //        if (part2.idTopic == part3.idTopic)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        private void ReadDataPart2(string part2Path)
        {
            if (File.Exists(part2Path))
            {
                string[] lines = File.ReadAllLines(part2Path);

                foreach (string line in lines)
                {
                    if (line.StartsWith("Ielts Speaking 2 Practice "))
                    {
                        Regex regex = new Regex(@"(?<=\().+?(?=\))");
                        Match topic = regex.Match(line);
                        //string idTopic = line.Substring("Ielts Speaking 2 Practice ".Length);
                        _dataPart2.Add(new Part2(topic.Value));
                    }
                    else
                    {
                        _dataPart2[_dataPart2.Count - 1].AddQuestion(line);
                    }
                }
            }
        }
        private void ReadDataPart3(string part3Path)
        {
            if (File.Exists(part3Path))
            {
                string[] lines = File.ReadAllLines(part3Path);

                foreach (string line in lines)
                {
                    if (line.StartsWith("Ielts Speaking 3 Practice "))
                    {
                        Regex regex = new Regex(@"(?<=\().+?(?=\))");
                        Match topic = regex.Match(line);
                        //string idTopic = line.Substring("Ielts Speaking 3 Practice ".Length);
                        _dataPart3.Add(new Part3(topic.Value));
                    }
                    else
                    {
                        _dataPart3[_dataPart3.Count - 1].AddQuestion(line);
                    }
                }
            }
        }

        public List<string> ReadPart1()
        {
            Random rnd = new Random();
            int card = rnd.Next(_dataPart1.Count);
            List<string> questions = _dataPart1[card].questions;
            _dataPart1.RemoveAt(card);
            return questions;
        }

        public string ReadPart2()
        {
            Random rnd = new Random();
            int card = rnd.Next(_dataPart2.Count);
            string questions = _dataPart2[card].questions;
            _topicPart2 = _dataPart2[card].idTopic;
            _dataPart2.RemoveAt(card);
            return questions;
        }
        public string ReadPart2Topic()
        {
            return _topicPart2;
        }

        public List<string> ReadPart3(string part2Topic)
        {
            foreach (Part3 part3 in _dataPart3)
            {
                if (part3.idTopic == part2Topic)
                {
                    return part3.questions;
                }
            }
            return new List<string>();
        }
    }
}