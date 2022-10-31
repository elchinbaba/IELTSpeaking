using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IELTSpeaking
{
    class ReadDatabase
    {
        public static List<Part1> _databasePart1 = new List<Part1>();
        public ReadDatabase()
        {
            string textFile = @"C:\Users\Administrator\source\repos\IELTSpeaking\IELTSpeaking\ielts-speaking-part1-db.txt";

            if (File.Exists(textFile))
            {
                string[] lines = File.ReadAllLines(textFile);

                Part1 part1 = new Part1();
                foreach (string line in lines)
                {
                    if (line.StartsWith("Ielts Speaking 1 Practice "))
                    {
                        string idTopic = line.Substring("Ielts Speaking 1 Practice ".Length);
                        part1 = new Part1(idTopic);
                        _databasePart1.Add(part1);
                    }
                    else
                    {
                        part1.AddQuestion(line);
                    }
                }
            }

            //if (File.Exists(textFile))
            //{
            //    using (StreamReader file = new StreamReader(textFile))
            //    {
            //        int counter = 0;
            //        string ln;

            //        while ((ln = file.ReadLine()) != null)
            //        {
            //            counter++;
            //        }
            //        file.Close();
            //    }
            //}
        }
        public string ReadPart1()
        {
            string allQuestions = "";
            foreach (Part1 part in ReadDatabase._databasePart1)
            {
                allQuestions = string.Concat(allQuestions, part.idTopic + "\r\n");
                foreach (string question in part.questions)
                {
                    allQuestions = string.Concat(allQuestions, question + "\r\n");
                }
            }
            return allQuestions;
        }
    }
}
