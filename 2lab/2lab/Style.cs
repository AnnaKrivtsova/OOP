using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    public class Style
    {
        private static Style instance;
        public System.Drawing.Color BackgroundColor { get; private set; }
        public System.Drawing.Color FontColor { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Style()
        {

        }
        protected Style(System.Drawing.Color backgroundColor, System.Drawing.Color fontColor, int width, int height)
        {
            this.BackgroundColor = backgroundColor;
            this.FontColor = fontColor;
            this.Height = height;
            this.Width = width;
        }
        public static Style getInstance(System.Drawing.Color backgroundColor, System.Drawing.Color fontColor, int width, int height)
        {
            if (instance == null)
                instance = new Style(backgroundColor, fontColor, width, height);
            return instance;
        }
    }
    public class StyleForm //для каждой формы применить только один стиль
    {
        public Style Style { get; set; }
        public void Launch(System.Drawing.Color styleBackgroundColor, System.Drawing.Color styleFontColor,int styleWidth, int styleHeight)
        {
            Style = Style.getInstance(styleBackgroundColor, styleFontColor, styleWidth, styleHeight);
        }
    }

}
