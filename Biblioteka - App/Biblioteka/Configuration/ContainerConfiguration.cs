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

            builder.RegisterType<PaymentService>().As<IPaymentService>();
            builder.RegisterType<PaymentRepository>().As<IPaymentRepository>();
            builder.RegisterType<CRUDRepository<Payment>>().As<ICRUDRepository<Payment>>();
            builder.RegisterType<SerializerJSON<Payment>>().As<ISerializer<Payment>>();
            builder.RegisterType<ResourceConfigurationJSON<Payment>>().As<IResourceConfiguration<Payment>>();


            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
            builder.RegisterType<CRUDRepository<Author>>().As<ICRUDRepository<Author>>();
            builder.RegisterType<SerializerJSON<Author>>().As<ISerializer<Author>>();
            builder.RegisterType<ResourceConfigurationJSON<Author>>().As<IResourceConfiguration<Author>>();

            builder.RegisterType<PublisherRepository>().As<IPublisherRepository>();
            builder.RegisterType<CRUDRepository<Publisher>>().As<ICRUDRepository<Publisher>>();
            builder.RegisterType<SerializerJSON<Publisher>>().As<ISerializer<Publisher>>();
            builder.RegisterType<ResourceConfigurationJSON<Publisher>>().As<IResourceConfiguration<Publisher>>();

            builder.RegisterType<BookTitleRepository>().As<IBookTitleRepository>();
            builder.RegisterType<CRUDRepository<BookTitle>>().As<ICRUDRepository<BookTitle>>();
            builder.RegisterType<SerializerJSON<BookTitle>>().As<ISerializer<BookTitle>>();
            builder.RegisterType<ResourceConfigurationJSON<BookTitle>>().As<IResourceConfiguration<BookTitle>>();

            builder.RegisterType<BookService>().As<IBookService>();

            builder.RegisterType<BorrowingService>().As<IBorrowingService>();
            builder.RegisterType<BorrowingRepository>().As<IBorrowingRepository>();
            builder.RegisterType<CRUDRepository<Borrowing>>().As<ICRUDRepository<Borrowing>>();
            builder.RegisterType<SerializerJSON<Borrowing>>().As<ISerializer<Borrowing>>();
            builder.RegisterType<ResourceConfigurationJSON<Borrowing>>().As<IResourceConfiguration<Borrowing>>();

            builder.RegisterType<ReturnBookService>().As<IReturnBookService>();

            return builder.Build();
        }
    }
}
