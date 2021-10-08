using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OgrenciManager>().As<IOgrenciService>().SingleInstance();
            builder.RegisterType<EfOgrenciDal>().As<IOgrenciDal>().SingleInstance();


            builder.RegisterType<OgretmenManager>().As<IOgretmenService>().SingleInstance();
            builder.RegisterType<EfOgretmenDal>().As<IOgretmenDal>().SingleInstance();

            builder.RegisterType<BolumManager>().As<IBolumService>().SingleInstance();
            builder.RegisterType<EfBolumDal>().As<IBolumDal>().SingleInstance();
            
            builder.RegisterType<DigerPersonelManager>().As<IDigerPersonelService>().SingleInstance();
            builder.RegisterType<EfDigerPersonelDal>().As<IDigerPersonelDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
