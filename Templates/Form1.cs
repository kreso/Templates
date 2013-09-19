using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Templates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string certData;
            using (var myFile = new System.IO.StreamReader(@"C:\Kreso\Me\Code\Templates\Templates\Data\cert.json"))
            {
                certData = myFile.ReadToEnd();
                myFile.Close();
            }

            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(certData);
            var jsonResult = Nustache.Core.Render.FileToString(
                @"C:\Kreso\Me\Code\Templates\Templates\Templates\json.mustache",
                data);
        }
    }
}
