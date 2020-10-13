using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace Voice_bOT
{
    public partial class Form1 : Form
    {
        private const string V1 = "\n";
        private const string V = V1;
        SpeechSynthesizer s = new SpeechSynthesizer();
        Boolean wake = true;




        Choices list = new Choices();
        public Form1()
        {


            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(new string[] { "hello", "how are you", "what time is it", "what is today", "open youtube", "wake", "sleep", "restart", "update", "open google" });

            Grammar gr = new Grammar(new GrammarBuilder(list));


            try
            {

                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }


            s.SelectVoiceByHints(VoiceGender.Female);

            s.Speak("hello, my name is voice bot");

            InitializeComponent();
        }


  

        public void restart()
        {
            Process.Start(@"C:\Users\VBot\VBot.exe");
            Environment.Exit(0);
        }
        public void say(String h)
        {
            s.Speak(h);
            textBox2.AppendText(h + V);
        }


        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;

            if (r == "wake")
            {
                wake = true;
                label3.Text = "State : Awake";


            }

            if (r == "sleep") { 
                wake = false;
                label3.Text = "State : Sleep mode";
            }

            if (wake == true)
            {

                if(r == "open google")
                {
                    Process.Start(@"C:\Program Files(x86)\Google\Chrome\Application");
                }



                if (r == "restart" || r == "update")
                {
                    restart();
                }

                //what you say
                if (r == "hello")
                {
                    //what it says
                    say("hi");
                }

                if (r == "what time is it")
                {
                    say(DateTime.Now.ToString("h:mm tt"));
                }

                if (r == "what is today")
                {
                    say(DateTime.Now.ToString("d/M/yyyy"));
                }

                if (r == "how are you")
                {

                    say("great, and you?");
                }

                if (r == "open youtube")
                {
                    Process.Start("https://www.youtube.com/");
                }
            }
            textBox1.AppendText( r + V);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
