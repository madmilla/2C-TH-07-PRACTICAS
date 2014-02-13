using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace THO7AlgorithmTimerApplication
{
    class BlackAlgorithmV5 : VisionAlgorithm
    {
        public BlackAlgorithmV5(String name) : base(name) { }
       public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
       //     Bitmap returnImage = new Bitmap(160, 160).FillImage(2, new Color[] 
      //                            { 
     //                                 Color.Red, 
     //                                 Color.Blue, 
     //                                 Color.Green,
     //                                 Color.Yellow 
     //                             });
      //      new Bitmap(sourceImage);
            
            //returnImage = new Bitmap(returnImage.Width, returnImage.Height, g);
            return sourceImage;
        }
    }
}
