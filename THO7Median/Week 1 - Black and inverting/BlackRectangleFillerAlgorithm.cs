using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace THO7AlgorithmTimerApplication
{
    class BlackRectangleFillerAlgorithm : VisionAlgorithm
    {
        //  Authors:  
        //  Lars Veenendaal                     1633223
        //  lars.veenendaal@student.hu.nl       TIV-2A
        //
        //  Mitchell Werensteijn                1624291
        //  mitchell.werensteijn@student.hu.nl  TIV-2A
        public BlackRectangleFillerAlgorithm(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            // Get the bitmap data to a temp bitmap.
            Bitmap returnImage = new Bitmap(sourceImage);

            // set g to a graphical object of the returnImage.
            Graphics g = Graphics.FromImage(returnImage);
            // Then draw a rectangle over it. using the resolution of the returnImage.
            g.FillRectangle(Brushes.Black, 0, 0, returnImage.Width, returnImage.Height);

            return returnImage;
        }
    }
}
