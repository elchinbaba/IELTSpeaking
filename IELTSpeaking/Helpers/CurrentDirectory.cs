using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IELTSpeaking
{
    static class CurrentDirectory
    {
        public static readonly string Directory = System.IO.Directory.GetCurrentDirectory() + "\\..\\..";
    }
}