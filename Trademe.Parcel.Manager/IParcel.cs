using Trademe.Parcel.Utilities;

namespace Trademe.Parcel.Manager
{
    public interface IParcel
    {
        /// <summary>
        /// Property containing parcel dimensions, including weight
        /// </summary>
        Dimensions Dimensions
        { get; set; }

        /// <summary>
        /// Property containing package shipping solution
        /// </summary>
        PackagingSolution PackagingSolution
        { get; set; }

        /// <summary>
        /// Method to calculate packaging solution
        /// </summary>
        /// <returns></returns>
        PackagingSolution CalculatePackagingSolution();

        /// <summary>
        /// Method to calculate volumetric weight of package
        /// </summary>
        /// <returns></returns>
        double CalculateVolumetricWeight();
        
    }
}
