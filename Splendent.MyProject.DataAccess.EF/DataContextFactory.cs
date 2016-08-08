using Splendent.MyProject.DataAccess.EF.DataContextStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splendent.MyProject.DataAccess.EF
{
    public static class DataContextFactory
    {
        /// <summary>
        /// Clears out the current ContactManagerContext.
        /// </summary>
        public static void Clear()
        {
            var dataContextStorageContainer = DataContextStorageFactory<DatabaseContext>.CreateStorageContainer();
            dataContextStorageContainer.Clear();
        }

        /// <summary>
        /// Retrieves an instance of ContactManagerContext from the appropriate storage container or
        /// creates a new instance and stores that in a container.
        /// </summary>
        /// <returns>An instance of ContactManagerContext.</returns>
        public static DatabaseContext GetDataContext()
        {
            var dataContextStorageContainer = DataContextStorageFactory<DatabaseContext>.CreateStorageContainer();
            var SchoolLinkDBContext = dataContextStorageContainer.GetDataContext();
            if (SchoolLinkDBContext == null)
            {
                SchoolLinkDBContext = new DatabaseContext();
                dataContextStorageContainer.Store(SchoolLinkDBContext);
            }
            return SchoolLinkDBContext;
        }
    }
}
