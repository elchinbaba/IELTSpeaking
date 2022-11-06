using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IELTSpeaking
{
    class Part2
    {
        private string _idTopic;
        private string _questions;
        public Part2() { }
        public Part2(string idTopic)
        {
            _idTopic = idTopic;
        }

        public string idTopic
        {
            get { return _idTopic; }
            set { _idTopic = value; }
        }

        public string questions
        {
            get { return _questions; }
            set { _questions = value; }
        }
        public void AddQuestion(string question)
        {
            _questions += question + "\r\n";
        }
    }
}
