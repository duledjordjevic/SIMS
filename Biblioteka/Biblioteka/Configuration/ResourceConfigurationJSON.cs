using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Configuration
{
    public class ResourceConfigurationJSON<T> : IResourceConfiguration<T>
    {
        private string PatientJSON = @"..\..\..\Data\patient.json";

        public string GetResourcePath()
        {
            return typeof(T).Name switch
            {
                //nameof(Patient) => PatientJSON,
                _ => string.Empty,
            };
        }
    }
}
