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

namespace Voice_bOT
{
    public partial class Form1 : Form
    {

        SpeechSynthesizer s = new SpeechSynthesizer();
        Choices list = new Choices();
        public Form1()
        {

            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(new string[] { "hello", "how are you" });

            Grammar gr = new Grammar(new GrammarBuilder(list));

            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return;}

            s.SelectVoiceByHints(VoiceGender.Female);

            s.Speak("hello, my name is voice bot");

            InitializeComponent();
                
        }


        public void say(String h)
        {
            s.Speak(h);
        }

        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;

            //what you say
            if(r=="hello")
            {
                //what it says
                say("hi");
            }

            if(r == "how are you")
            {
                say("great, and you");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
