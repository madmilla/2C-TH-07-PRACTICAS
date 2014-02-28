using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace THO7AlgorithmTimerApplication
{
    public abstract class VisionAlgorithm
    {
        private String _Name;
        private int _Noise;

        public String Name {
            get
            {
                return _Name;
            }
            set
            {
                _Name = Name;
            }
        }

        public int Noise
        {
            get
            {
                return _Noise;
            }
            set{
                _Noise = Noise;
            }
        }
        public VisionAlgorithm(String name)
        {
            this._Name = name;
        }

        public VisionAlgorithm(String name, int noise)
        {
            this._Name = name;
            this._Noise = noise;
        }
        
        public abstract Bitmap DoAlgorithm(Bitmap sourceImage);

        
    }

}
