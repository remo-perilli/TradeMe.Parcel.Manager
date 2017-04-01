using Trademe.Parcel.Utilities;

namespace Trademe.Parcel.Manager
{
    public class Parcel : IParcel
    {
        public Parcel(Dimensions dimensions)
        {
            Dimensions = dimensions;
        }

        #region Properties

        private Dimensions _dimensions;
        private PackagingSolution _packagingSolution;

        public PackagingSolution PackagingSolution
        {
            get
            {
                return _packagingSolution; }

            set
            { _packagingSolution = value; }
        }

        public Dimensions Dimensions
        {
            get
            {
                return _dimensions;
            }

            set
            {
                if (value.Length == 0)
                    throw new DimensionException("You have not supplied a valid package length");
                if (value.Breadth == 0)
                    throw new DimensionException("You have not supplied a valid package breadth");
                if (value.Height == 0)
                    throw new DimensionException("You have not supplied a valid package height");
                if (value.Weight == 0)
                    throw new DimensionException("You have not supplied a valid package weight");
                _dimensions = value;
                _packagingSolution = CalculatePackagingSolution();
            }
        }

        #endregion
       

        public PackagingSolution CalculatePackagingSolution()
        {
            var solution = new PackagingSolution();
            if (_dimensions.Weight <= 25)
            {
                if (_dimensions.Length <= 21 && _dimensions.Breadth <= 28 && _dimensions.Height <= 13)
                {
                    solution = new PackagingSolution();
                    solution.Size = PackagingSolution.PackageSize.Small;
                    solution.Cost = 5;
                    return solution;
                }

                if (_dimensions.Length <= 28 && _dimensions.Breadth <= 39 && _dimensions.Height <= 18)
                {
                    solution = new PackagingSolution();
                    solution.Size = PackagingSolution.PackageSize.Medium;
                    solution.Cost = 7.50;
                    return solution;
                }

                if (_dimensions.Length <= 38 && _dimensions.Breadth <= 55 && _dimensions.Height <= 20)
                {
                    solution = new PackagingSolution();
                    solution.Size = PackagingSolution.PackageSize.Large;
                    solution.Cost = 8.50;
                    return solution;
                }

                //TODO: Implement future service offering for Extra Large parcels which has cost of $10
                //if (_dimensions.Length <= 45 && _dimensions.Breadth <= 70 && _dimensions.Height <= 25)
                //{
                //    solution = new PackagingSolution();
                //    solution.Size = PackagingSolution.PackageSize.ExtraLarge;
                //    solution.Cost = 10;
                //    return solution;
                //}
            }
            //TODO: Implement future service offering for overweight(> 25kg) parcels.Use volumetric weight to calculate shipping cost assuming a cost of $10 / kg
            //else
            //{
            //    solution = new PackagingSolution();
            //    solution.Size = PackagingSolution.PackageSize.OverWeigth;
            //    solution.Cost = CalculateVolumetricWeight()*10;
            //    return solution;
            //}
            return null;
        }

        public double CalculateVolumetricWeight()
        {
            //TODO: Possible future functionality may include charging by volumetric weight for overweight parcels
            //using formula L x B x H in centimeters divided by volumetric factor of 5000
            const double _volumetricFactor = 5000;
            return (Dimensions.Length * Dimensions.Breadth * Dimensions.Height) / _volumetricFactor;
        }
    }
}
