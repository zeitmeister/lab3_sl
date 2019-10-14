using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    class SimpleDI
    {
        /// <summary>
        /// Name of the registered service.
        /// </summary>
        private static string serviceName;

        /// <summary>
        /// Constructor that registers a service from the configuration file.
        /// </summary>
        static SimpleDI()
        {
            RegisterService(BookService.Configuration.IBookService);
        }

        /// <summary>
        /// Register the name of the service
        /// </summary>
        /// <param name="name">name.</param>
        public static void RegisterService(string name)
        {
            serviceName = name;
        }

        /// <summary>
        /// Gets an instance of the registered service.
        /// </summary>
        /// <returns></returns>
        public static IBookService GetService()
        {
            if (serviceName == "InMemoryBookService")
                return new InMemoryBookService();
            if (serviceName == "CsvBookService")
                return new CsvBookService();

            throw new InvalidOperationException("No matching service!");
        }
    }
}
