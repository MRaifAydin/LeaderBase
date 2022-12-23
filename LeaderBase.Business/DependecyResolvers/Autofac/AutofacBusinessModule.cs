using Autofac;
using Autofac.Extras.CommonServiceLocator;
using AutoMapper;
using CommonServiceLocator;
using LeaderBase.Business.Abstract;
using LeaderBase.Business.Auth.Abstract;
using LeaderBase.Business.Auth.Concrete;
using LeaderBase.Business.Concrete;
using LeaderBase.Conversion.MapperProfiles;
using LeaderBase.Repository.Abstract;
using LeaderBase.Repository.Auth.Abstract;
using LeaderBase.Repository.Auth.Concrete;
using LeaderBase.Repository.Concrete;
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
            builder.RegisterType<UserManager>().As<IUserService>();


            builder.RegisterType<LeaderRepository>().As<ILeaderRepository>();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

        }

    }
}
