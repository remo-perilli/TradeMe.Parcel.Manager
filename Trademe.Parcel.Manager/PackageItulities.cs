using System;

namespace Trademe.Parcel.Utilities
{
    /// <summary>
    /// Represents the dimensions of a parcel
    /// </summary>
    public class Dimensions
    {
        public Dimensions()
        { }

        public Dimensions(double length, double breadth, double heigth, double weight)
        {
            _length = length;
            _breadth = breadth;
            _height = heigth;
            _weight = weight;
        }

        private double _length;
        private  double _breadth;
        private double _height;
        private double _weight;

        /// <summary>
        /// Length in centimeters
        /// </summary>
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        /// <summary>
        /// Breadth in centimeters
        /// </summary>
        public double Breadth
        {
            get { return _breadth; }
            set { _breadth = value; }
        }

        /// <summary>
        /// Height in centimeters
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Weight in kilograms
        /// </summary>
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
    }

    public class DimensionException : Exception
    {
        public DimensionException(string message) :base(message)
        {
        }

    }

    /// <summary>
    /// Represents a packaging solution for a parcel
    /// </summary>
    public class PackagingSolution
    {
        private double _cost;
        private PackageSize _type;

        public enum PackageSize
        {
            Small,
            Medium,
            Large,
            ExtraLarge,
            OverWeigth
        }

        public Double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
       
        public PackageSize Size
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
