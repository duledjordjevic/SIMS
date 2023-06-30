using Autofac;
using Biblioteka.Repository.Core;
using Biblioteka.Service.Interface;
using Biblioteka.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Configuration
{
    public static class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LoginService>().As<ILoginService>();
            //builder.RegisterType<PatientService>().As<IPatientService>();
            //builder.RegisterType<CRUDRepository<Patient>>().As<ICRUDRepository<Patient>>();
            //builder.RegisterType<SerializerJSON<Patient>>().As<ISerializer<Patient>>();
            //builder.RegisterType<ResourceConfigurationJSON<Patient>>().As<IResourceConfiguration<Patient>>();

            return builder.Build();
        }
    }
}
