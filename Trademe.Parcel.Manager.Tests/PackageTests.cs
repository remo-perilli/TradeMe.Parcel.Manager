using NUnit.Framework;
using Trademe.Parcel.Utilities;

namespace Trademe.Parcel.Manager.Tests
{
    /// <summary>
    /// For the purposes of all tests dimensions are asumed to be lenght x breadth x height in centimeters and weight in kgs
    /// </summary>
    [TestFixture]
    public class TrademeParcelTester
    {
        [Test]
        public void PackageOver25KgReturnsNoPackagingSolution()
        {
            var dimensions = new Dimensions(20, 20, 13, 27.3);
            var parcel = new Parcel(dimensions);
            Assert.IsNull(parcel.PackagingSolution);
        }


        [Test]
        public void PackageWithDimensions20x20x10IsSmall()
        {
            var dimensions = new Dimensions(20, 20, 10,10);
            Parcel parcel = new Parcel(dimensions);
            Assert.IsTrue(parcel.PackagingSolution.Size==PackagingSolution.PackageSize.Small);
        }

        [Test]
        public void PackageWithDimensions28x20x10IsMedium()
        {
            var dimensions = new Dimensions(28, 20, 10, 5);
            var parcel = new Parcel(dimensions);
            Assert.IsTrue(parcel.PackagingSolution.Size == PackagingSolution.PackageSize.Medium);
        }

        [Test]
        public void PackageWithDimensions20x29x10IsMedium()
        {
            var dimensions = new Dimensions(20, 29, 10, 3);
            var parcel = new Parcel(dimensions);
            Assert.IsTrue(parcel.PackagingSolution.Size == PackagingSolution.PackageSize.Medium);
        }

        [Test]
        public void PackageWithDimensions20x28x14IsMedium()
        {
            var dimensions = new Dimensions(20, 28, 14, 6);
            var parcel = new Parcel(dimensions);
            Assert.IsTrue(parcel.PackagingSolution.Size == PackagingSolution.PackageSize.Medium);
        }

        [Test]
        public void PackageWithDimensions28_1x20x10IsLarge()
        {
            var dimensions = new Dimensions(28.1, 20, 10, 3);
            var parcel = new Parcel(dimensions);
            Assert.IsTrue(parcel.PackagingSolution.Size == PackagingSolution.PackageSize.Large);
        }

        [Test]
        public void PackageWithDimensions28x39_1x10IsLarge()
        {
            var dimensions = new Dimensions(28, 39.1, 10, 4);
            var parcel = new Parcel(dimensions);
            Assert.IsTrue(parcel.PackagingSolution.Size == PackagingSolution.PackageSize.Large);
        }

        [Test]
        public void PackageWithDimensions28x39x18_1IsLarge()
        {
            Dimensions dimensions = new Dimensions(28, 39, 18.1, 3);
            Parcel parcel = new Parcel(dimensions);
            Assert.IsTrue(parcel.PackagingSolution.Size == PackagingSolution.PackageSize.Large);
        }

        [Test]
        public void PackageWithNoLengthThrowsException()
        {
            var dimensions = new Dimensions(0, 39, 18.1, 1);
            var ex = Assert.Throws<DimensionException>(() => new Parcel(dimensions));
            Assert.That(ex.Message == "You have not supplied a valid package length");
        }

        [Test]
        public void PackageWithNoBreadthThrowsException()
        {
            var dimensions = new Dimensions(20, 0, 18.1, 1);
            var ex = Assert.Throws<DimensionException>(() => new Parcel(dimensions));
            Assert.That(ex.Message == "You have not supplied a valid package breadth");
        }

        [Test]
        public void PackageWithNoHeightThrowsException()
        {
            var dimensions = new Dimensions(20, 20, 0, 1);
            var ex = Assert.Throws<DimensionException>(() => new Parcel(dimensions));
            Assert.That(ex.Message == "You have not supplied a valid package height");
        }

        [Test]
        public void PackageWithNoWeightThrowsException()
        {
            var dimensions = new Dimensions(20, 20, 50, 0);
            var ex = Assert.Throws<DimensionException>(() => new Parcel(dimensions));
            Assert.That(ex.Message == "You have not supplied a valid package weight");
        }

        [Test]
        public void SmallPackageHasCostOfFiveDollars()
        {
            var dimensions = new Dimensions(20, 20, 10, 10);
            var parcel = new Parcel(dimensions);
            Assert.IsTrue(parcel.PackagingSolution.Cost == 5);
        }

        [Test]
        public void MediumPackageHasCostOfSevenDollarsFifty()
        {
            var dimensions = new Dimensions(20, 29, 10, 3);
            var parcel = new Parcel(dimensions);
            Assert.IsTrue(parcel.PackagingSolution.Cost == 7.50);
        }

        [Test]
        public void LargePackageHasCostOfEightDollarsFifty()
        {
            var dimensions = new Dimensions(28, 39.1, 10, 4);
            var parcel = new Parcel(dimensions);
            Assert.IsTrue(parcel.PackagingSolution.Cost == 8.50);
        }
    }
}
