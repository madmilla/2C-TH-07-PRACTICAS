using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace THO7AlgorithmTimerApplication
{
    class InvertAlgorithmV1 : VisionAlgorithm
    {
        //  Authors:  
        //  Lars Veenendaal                     1633223
        //  lars.veenendaal@student.hu.nl       TIV-2A
        //
        //  Mitchell Werensteijn                1624291
        //  mitchell.werensteijn@student.hu.nl  TIV-2A
        public InvertAlgorithmV1(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            // Bronnen:  
            // http://msdn.microsoft.com/en-us/library/5ey6h79d(v=vs.110).aspx

            Bitmap returnImage = new Bitmap(sourceImage);

            // Save the size from the bitmap in a rectangle at position 0,0.
            Rectangle bitmapRect = new Rectangle(new Point(0,0), returnImage.Size);
            
            // Lock the bits from the bitmap in system memory.
            BitmapData bitmapData = returnImage.LockBits(bitmapRect, System.Drawing.Imaging.ImageLockMode.WriteOnly, returnImage.PixelFormat);

            // Declare an array to hold the bytes of the bitmap. 
            int bytes  = Math.Abs(bitmapData.Stride) * bitmapData.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, rgbValues, 0, bytes);

            // Loop through the rgbValues and invert the color by taking 255 of the orginal value.
            for (int counter = 0; counter < rgbValues.Length; counter += 4) 
            {
                rgbValues[counter] = (byte)(255 - rgbValues[counter]);          // Set Blue
                rgbValues[counter + 1] = (byte)(255 - rgbValues[counter + 1]);  // Set Green
                rgbValues[counter + 2] = (byte)(255 - rgbValues[counter + 2]);  // Set Red
                // There is no need to set alpha since we are not changing the alphalayers.
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, bitmapData.Scan0, bytes);
            
            // Unlock the bits from the bitmap from system memory.
            returnImage.UnlockBits(bitmapData);

            return returnImage;
        }
    }
}
