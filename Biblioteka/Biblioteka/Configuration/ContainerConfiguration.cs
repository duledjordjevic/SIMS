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


            builder.RegisterType<UserAccountService>().As<IUserAccountService>();
            builder.RegisterType<UserAccountRepository>().As<IUserAccountRepository>();
            builder.RegisterType<CRUDRepository<UserAccount>>().As<ICRUDRepository<UserAccount>>();
            builder.RegisterType<SerializerJSON<UserAccount>>().As<ISerializer<UserAccount>>();
            builder.RegisterType<ResourceConfigurationJSON<UserAccount>>().As<IResourceConfiguration<UserAccount>>();

            builder.RegisterType<MemberService>().As<IMemberService>();
            builder.RegisterType<MemberRepository>().As<IMemberRepository>();
            builder.RegisterType<CRUDRepository<Member>>().As<ICRUDRepository<Member>>();
            builder.RegisterType<SerializerJSON<Member>>().As<ISerializer<Member>>();
            builder.RegisterType<ResourceConfigurationJSON<Member>>().As<IResourceConfiguration<Member>>();


            return builder.Build();
        }
    }
}
