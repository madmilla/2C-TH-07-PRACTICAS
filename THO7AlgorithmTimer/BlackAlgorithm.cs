﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace THO7AlgorithmTimerApplication
{
    class BlackAlgorithm : VisionAlgorithm
    {
        public BlackAlgorithm(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            Bitmap returnImage = new Bitmap(sourceImage);
            Graphics g = Graphics.FromImage(returnImage);
            g.FillRectangle(Brushes.Black, 0, 0, returnImage.Width, returnImage.Height);
            //returnImage = new Bitmap(returnImage.Width, returnImage.Height, g);
            return returnImage;
        }
    }
}
