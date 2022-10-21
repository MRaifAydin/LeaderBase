using Autofac;
using Autofac.Extras.CommonServiceLocator;
using AutoMapper;
using CommonServiceLocator;
using LeaderBase.Business.Abstract;
using LeaderBase.Business.Concrete;
using LeaderBase.Conversion.MapperProfiles;
using LeaderBase.Repository.MongoDB.Abstract;
using LeaderBase.Repository.MongoDB.Concrete;
using LeaderBase.Repository.PostgreSQL.Abstract;
using LeaderBase.Repository.PostgreSQL.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LeaderManager>().As<ILeaderService>();
            builder.RegisterType<PersonManager>().As<IPersonService>();

            builder.RegisterType<LeaderRepository>().As<ILeaderRepository>();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<OperationClaimRepository>().As<IOperationClaimRepository>();
            builder.RegisterType<UserOperationClaimRepository>().As<IUserOperationClaimRepository>();

        }

    }
}
