using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IELTSpeaking
{
    class Part3
    {
        private string _idTopic;
        private List<string> _questions = new List<string>();

        public Part3() { }
        public Part3(string idTopic)
        {
            _idTopic = idTopic;
        }

        public string idTopic
        {
            get { return _idTopic; }
            set { _idTopic = value; }
        }

        public List<string> questions
        {
            get { return _questions; }
            set { _questions = value; }
        }

        public void AddQuestion(string question)
        {
            _questions.Add(question);
        }
    }
}
