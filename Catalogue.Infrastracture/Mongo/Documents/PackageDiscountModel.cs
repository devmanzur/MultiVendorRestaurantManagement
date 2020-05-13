namespace Catalogue.Infrastructure.Mongo.Documents
{
    public class PackageDiscountModel
    {
        public PackageDiscountModel(int packageSize, int freeItemQuantityInPackage)
        {
            PackageSize = packageSize;
            FreeItemQuantityInPackage = freeItemQuantityInPackage;
        }

        public int PackageSize { get; protected set; }
        public int FreeItemQuantityInPackage { get; protected set; }
    }
}