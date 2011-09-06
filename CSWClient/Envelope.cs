using System;
using System.Text;

namespace ArcMapAddin1
{
    class Envelope
    {
        private double _minX, _minY, _maxX, _maxY;

        public double MinX
        {
            set
            {
                _minX = value;
            }
            get
            {
                return _minX;
            }
        }

        public double MinY
        {
            set
            {
                _minY = value;
            }
            get
            {
                return _minY;
            }
        }

        public double MaxX
        {
            set
            {
                _maxX = value;
            }
            get
            {
                return _maxX;
            }
        }

        public double MaxY
        {
            set
            {
                _maxY = value;
            }
            get
            {
                return _maxY;
            }
        }

        public Envelope()
        {
            _minX = -118.3;
            _minY = 32.1;
            _maxX = -87.1;
            _maxY = 45.2;
        }

        public Envelope(double minX, double minY, double maxX, double maxY)
        {
            MinX = minX;
            MinY = minY;
            MaxX = maxX;
            MaxY = maxY;
 
        }
    }
}
