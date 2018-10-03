namespace Acme.Biz
{

    public class VendorRepository
    {
        /// <summary>
        /// Retrieve one vendor
        /// </summary>
        public Vendor Retrieve(int vendorId)
        {
            //Create an instance of the vendor class
            Vendor vendor = new Vendor();

            //Code that retrieves the defined customer

            // Temporary hard coded values to return
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp.";
                vendor.Email = "info@abccorp.com";
            }

            return vendor;
        }


        public bool Save(Vendor vendor)
        {
            var success = true;

            //Code that saves the vendor

            return success;
        }
    }
}