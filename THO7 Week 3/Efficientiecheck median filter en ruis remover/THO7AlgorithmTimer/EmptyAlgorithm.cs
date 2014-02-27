using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace THO7AlgorithmTimerApplication
{
    class EmptyAlgorithm : VisionAlgorithm
    {
        public EmptyAlgorithm(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            return sourceImage;
        }

    }
}
