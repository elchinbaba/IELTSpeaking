using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IELTSpeaking
{
    public partial class IELTSpeaking : Form
    {
        public IELTSpeaking()
        {
            InitializeComponent();
        }

        private void ReadDB()
        {
            ReadDatabase readDatabase = new ReadDatabase();
            questions.Text = readDatabase.ReadPart1();
        }

        private void IELTSpeaking_Load(object sender, EventArgs e)
        {
            ReadDB();
        }
    }
}
