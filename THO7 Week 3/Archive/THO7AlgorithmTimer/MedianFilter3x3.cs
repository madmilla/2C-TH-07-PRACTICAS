using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace THO7AlgorithmTimerApplication
{
    class MedianFilter3x3 : VisionAlgorithm
    {
        public MedianFilter3x3(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {

            // Size of matrix (this case 3), we tried to do this in the constructor as parameter but not enough time to fix it.
            int Matrixsize = 3;

            // The width, in pixels, of the sourceImage
            int Width = sourceImage.Width;

            // The height, in pixels, of the sourceImage
            int Height = sourceImage.Height;

            // Initializes a new instance of the bitmap class from the specified existing image 
            Bitmap grayImage = new Bitmap(sourceImage);

            // Locks the grayImage bitmap on system memory
            BitmapData bmpData = grayImage.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            // Calculate the size in quantity bytes for walk through bitmap
            int bytes = Math.Abs(bmpData.Stride) * Height;

            // Byte array with size of int bytes
            byte[] rgbValues = new byte[bytes];

            unsafe
            {
                // This piece of unsafe code uses a byte pointer called ptr and with that pointer we walk through the image and change the values to grayscale
                byte* ptr = (byte*)bmpData.Scan0;
                 for (int i = 0; i < Height; i++)
                 {
                    for (int j = 0; j < Width; j++)
                    {
                    // Calculating the gray value
                    byte y = (byte)((0.299 * ptr[2]) + (0.587 * ptr[1]) + (0.114 * ptr[0]));

                    // Set y which is the color of gray
                    ptr[0] = ptr[1] = ptr[2] = y;

                    // Incrementing the pointer ptr
                    ptr += 4;
                    }

                // Going to next line.
                ptr += bmpData.Stride - Width * 4;
            
                }
            }

            // Now able to copy from a managed array to unmanaged memory pointer
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, rgbValues, 0, bytes);
            
            // Unlocks the bitmap from system memory, so the data will be changed
            grayImage.UnlockBits(bmpData);

            // Byte array with size of int bytes
            byte[] resultValues = new byte[bytes];

            // 
            int medianFilterOffset = (Matrixsize - 1) / 2;
            int calculateOffset = 0;
            int byteOffset = 0;
            
            //
            List<int> medianFilterPixels = new List<int>();
            
            // 
            byte[] medianPixel;

            // Loop until the offset is higher than the height of the image
            for (int medianFilterOffsetY = medianFilterOffset; medianFilterOffsetY < Height - medianFilterOffset; medianFilterOffsetY++)
            {
                // Loop until the offset is higher than the width of the image
                for (int medianFilterOffsetX = medianFilterOffset; medianFilterOffsetX < Width - medianFilterOffset; medianFilterOffsetX++)
                {
                    byteOffset = medianFilterOffsetY * bmpData.Stride + medianFilterOffsetX * 4;
                    
                    // Clears the list so it can be used for the next 9 ints
                    medianFilterPixels.Clear();
                    for (int medianFilterY = -medianFilterOffset; medianFilterY <= medianFilterOffset; medianFilterY++)
                    {
                        for (int medianFilterX = -medianFilterOffset; medianFilterX <= medianFilterOffset; medianFilterX++)
                        {
                            // Calculates the median filter pixels and fills the list medianFilterPixels with median filter values (9 in this case) 
                            calculateOffset = byteOffset + (medianFilterX * 4) + (medianFilterY * bmpData.Stride);
                            medianFilterPixels.Add(BitConverter.ToInt32(rgbValues, calculateOffset));
                        }
                    }

                    // Sorting List which contains 9 numbers from low to high
                    medianFilterPixels.Sort();

                    // Converts medianFilterPixels[medianFilterOffset] to byte and put in medianPixel
                    medianPixel = BitConverter.GetBytes(medianFilterPixels[medianFilterOffset]);

                    // Setting the new color to that middlest pixel of the matrix
                    resultValues[byteOffset] = medianPixel[0];
                    resultValues[byteOffset + 1] = medianPixel[1];
                    resultValues[byteOffset + 2] = medianPixel[2];
                    resultValues[byteOffset + 3] = medianPixel[3];
                }
            }

            // Initializes a new instance of the bitmap class from the specified existing image 
            Bitmap resultBitmap = new Bitmap(Width, Height);

            // Locks the resultBitmap bitmap on system memory
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);

            // Now able to copy from a managed array to unmanaged memory pointer
            System.Runtime.InteropServices.Marshal.Copy(resultValues, 0, resultData.Scan0, bytes);

            // Unlocks this bitmap form system memory, so the data will be changed
            resultBitmap.UnlockBits(resultData);
            
            // Give adjusted image back
            return resultBitmap;

        }

    }
}
