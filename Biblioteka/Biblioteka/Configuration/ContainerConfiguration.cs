using Autofac;
using Biblioteka.Repository.Core;
using Biblioteka.Service.Interface;
using Biblioteka.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Repository;
using Biblioteka.Repository.Interface;
using Biblioteka.Model;

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


            builder.RegisterType<UserAccountService>().As<IUserAccountService>();
            builder.RegisterType<UserAccountRepository>().As<IUserAccountRepository>();
            builder.RegisterType<CRUDRepository<UserAccount>>().As<ICRUDRepository<UserAccount>>();
            builder.RegisterType<SerializerJSON<UserAccount>>().As<ISerializer<UserAccount>>();
            builder.RegisterType<ResourceConfigurationJSON<UserAccount>>().As<IResourceConfiguration<UserAccount>>();
            return builder.Build();
        }
    }
}
