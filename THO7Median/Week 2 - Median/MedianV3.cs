using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;


namespace THO7AlgorithmTimerApplication
{
    //  Authors:  
    //  Lars Veenendaal                     1633223
    //  lars.veenendaal@student.hu.nl       TIV-2A
    //
    //  Mitchell Werensteijn                1624291
    //  mitchell.werensteijn@student.hu.nl  TIV-2A
    class MedianV3 : VisionAlgorithm
    {
        protected int maskSize = 3;

        // Boy scout rule: Leave it better than you found it.
        // So we refactored this one.
        // Took all the could be functions (repeating instructions).

        public MedianV3(String name, int maskS) : base(name) { maskSize = maskS; }

        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            // Median is modular so it takes the image and a parameter for the 'neighborhood' or map.
            Bitmap returnImage = MedianFilter(sourceImage, maskSize);
            return returnImage;
        }
        public static Bitmap MedianFilter(Bitmap OriginalImage, int Size)
        {
            try
            {
                // Create a new Bitmap to alter since we need to keep the original.
                System.Drawing.Bitmap NewBitmap = new System.Drawing.Bitmap(OriginalImage.Width, OriginalImage.Height);
                BitmapData NewData = LockImage(NewBitmap);
                BitmapData OldData = LockImage(OriginalImage);
                // Get the pixelsize 32 needs alpha were 24bpp doesn't
                int NewPixelSize = GetPixelSize(NewData);
                int OldPixelSize = GetPixelSize(OldData);
                // W
                Console.Write(" NEW" + NewPixelSize + " OLD " + OldPixelSize);
                // Prepare the mask.
                int MaskMin = -(Size / 2);
                int MaskMax = (Size / 2);
                // Loop through the width and height.
                // ++x because we dont want to start on zero because we cant read where the bitmap ends.
                // End the loop just before the end again because we cant read further than the bitmap.
                for (int Width = 0; Width < NewBitmap.Width; ++Width)
                {
                    for (int Height = 0; Height < NewBitmap.Height; ++Height)
                    {
                        // Make ( / redefine) lists for Red, Green, Blue
                        // We dont care about alpha
                        List<int> RValues = new List<int>();
                        List<int> GValues = new List<int>();
                        List<int> BValues = new List<int>();

                        // Go through every pixel in the mask and get the specific color information and store that information in the lists.
                        for (int MaskWidth = MaskMin; MaskWidth < MaskMax; ++MaskWidth)
                        {   
                            int actualPositionX = Width + MaskWidth;
                            if (actualPositionX >= 0 && actualPositionX < NewBitmap.Width)
                            {
                                for (int MaskHeight = MaskMin; MaskHeight < MaskMax; ++MaskHeight)
                                {
                                    int actualPositionY = Height + MaskHeight;
                                    if (actualPositionY >= 0 && actualPositionY < NewBitmap.Height)
                                    {
                                        // Create a temporary color of the oldData and take out the needed values.
                                        Color TempColor = GetPixel(OldData, actualPositionX, actualPositionY, OldPixelSize);
                                        RValues.Add(TempColor.R);
                                        GValues.Add(TempColor.G);
                                        BValues.Add(TempColor.B);
                                    }
                                }
                            }
                        }
                        // Seems to be the fastest method of sorting.
                        // Quickselect cant touch the speed of the sort.
                        // Tried multiple sorting methods there might be faster ones though.
                        RValues.Sort();
                        GValues.Sort();
                        BValues.Sort();

                        // Create a new color and make it of the all the middle values on the list.
                        Color MedianPixel = Color.FromArgb((byte)RValues[RValues.Count / 2], (byte)GValues[GValues.Count / 2], (byte)BValues[BValues.Count / 2]);
                        
                        // Set the specific pixel with the new color. 
                        SetPixel(NewData, Width, Height, MedianPixel, NewPixelSize);
                    }
                }
                // Unlock the bitmaps.
                UnlockImage(NewBitmap, NewData);
                UnlockImage(OriginalImage, OldData);
                    
                return NewBitmap;
            }
            catch { throw; }

        }

        protected static BitmapData LockImage(Bitmap Image)
        {
            // Basic bitmap locking.
            // Create a new rectangle as big as the image and lock that area of the bitmap.
            // lockmode ReadWrite cause we need to be able to do both.
            return Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, Image.PixelFormat);
        }
        protected static int GetPixelSize(BitmapData Data)
        {
            // Figure out if the image has an alpha layer
            // This valueable little bit of info is needed in (de)construction of the bitmaps.
            if (Data.PixelFormat == PixelFormat.Format24bppRgb)
            {
                return 3;
            } 
            else if (Data.PixelFormat == PixelFormat.Format32bppArgb || Data.PixelFormat == PixelFormat.Format32bppPArgb || Data.PixelFormat == PixelFormat.Format32bppRgb)
            {
                // These are according to MSDN the most commond 32bpp pixelformats 
                // There are many more but we haven't gotten the time to try them all :(
                return 4;
            }
            // Sorry if its not among the predefinied its currently not supported.
            return 0;
        }

        protected static unsafe Color GetPixel(BitmapData Data, int x, int y, int PixelSizeInBytes)
        {
            try
            {
                
                byte* DataPointer = (byte*)Data.Scan0;
                // Calculate the amount of bytes 
                DataPointer = DataPointer + (y * Data.Stride) + (x * PixelSizeInBytes);
                if (PixelSizeInBytes == 3)
                {   
                    // 24bpp get no alpha layer
                    return Color.FromArgb(DataPointer[2], DataPointer[1], DataPointer[0]);
                }
                // 32bpp does get the alpha layer.
                return Color.FromArgb(DataPointer[3], DataPointer[2], DataPointer[1], DataPointer[0]);
            }
            catch { throw; }
        }

        protected static unsafe void SetPixel(BitmapData Data, int x, int y, Color PixelColor, int PixelSizeInBytes)
        {
            try
            {
                byte* DataPointer = (byte*)Data.Scan0;
                // Calculate the amount of bytes.
                DataPointer = DataPointer + (y * Data.Stride) + (x * PixelSizeInBytes);
                
                // 24bpp mode.
                if (PixelSizeInBytes == 3)
                {
                   
                    DataPointer[2] = PixelColor.R;
                    DataPointer[1] = PixelColor.G;
                    DataPointer[0] = PixelColor.B;
                    return;
                }
                // The cool bpps.
                DataPointer[3] = PixelColor.A;
                DataPointer[2] = PixelColor.R;
                DataPointer[1] = PixelColor.G;
                DataPointer[0] = PixelColor.B;
                return;
            }
            catch { throw; }
        }


        protected static void UnlockImage(Bitmap Image, BitmapData ImageData)
        {
            // Job is all done unlock the images.
            Image.UnlockBits(ImageData);
        }

    }
}
