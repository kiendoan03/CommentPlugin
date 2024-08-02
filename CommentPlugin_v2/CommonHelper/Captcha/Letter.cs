using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Drawing;


namespace CommonHelper.Captcha
{
    public class Letter
    {
        string[] ValidFonts = { "arial", "arial black", "comic sans ms", "courier new", "estrangelo edessa", " franklin gothic medium", "georgia", "lucida console", " lucida sans unicode", "mangal", "microsoft sans serif", "palatino linotypesylfaen", "tahoma", "times new roman", "trebuchet ms", " verdana" };
        public Letter(char c)
        {
            Random rnd = new Random();
            font = new Font(ValidFonts[rnd.Next(ValidFonts.Count() - 1)], rnd.Next(20) + 20, GraphicsUnit.Pixel);
            letter = c;
        }
        public Font font
        {
            get;
            private set;
        }
        public Size LetterSize
        {
            get
            {
                var Bmp = new Bitmap(1, 1);
                var Grph = Graphics.FromImage(Bmp);
                return Grph.MeasureString(letter.ToString(), font).ToSize();
            }
        }
        public char letter
        {
            get;
            private set;
        }
        public int space
        {
            get;
            set;
        }
    }
}