using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Api.ApiContstants
{
    public class ApiConstants
    {
        public const string ApiName = "GadgetService";
        internal const string ServiceFriendlyName = "Gadget Service";

        public const string DbConnectionString =
            "Server=(LocalDb)\\MSSQLLocalDB;Database=Feedback;Trusted_Connection=True;MultipleActiveResultSets=true;";
        
        public const string StorageAccountKey = "storage-account-secret";

    }
}
