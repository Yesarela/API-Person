﻿using System.Reflection;
using Autofac;
using Ardalis.SharedKernel;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;
using PruebaTecnicaCRUD.UseCases.Person.List;
using PruebaTecnicaCRUD.Infrastructure.Data;
using PruebaTecnicaCRUD.Infrastructure.Data.Queries;
using PruebaTecnicaCRUD.UseCases.Person.Create;

namespace PruebaTecnicaCRUD.Infrastructure;

/// <summary>
/// An Autofac module responsible for wiring up services defined in Infrastructure.
/// Mainly responsible for setting up EF and MediatR, as well as other one-off services.
/// </summary>
public class AutofacInfrastructureModule : Module
{
    private readonly bool _isDevelopment = false;
    private readonly List<Assembly> _assemblies = [];

    public AutofacInfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
    {
        _isDevelopment = isDevelopment;
        AddToAssembliesIfNotNull(callingAssembly);
    }

    private void AddToAssembliesIfNotNull(Assembly? assembly)
    {
        if (assembly != null)
        {
            _assemblies.Add(assembly);
        }
    }

    private void LoadAssemblies()
    {
        // TODO: Replace these types with any type in the appropriate assembly/project
        //var coreAssembly = Assembly.GetAssembly(typeof(Project));
        var infrastructureAssembly = Assembly.GetAssembly(typeof(AutofacInfrastructureModule));
        var useCasesAssembly = Assembly.GetAssembly(typeof(CreatePersonCommand));

        //AddToAssembliesIfNotNull(coreAssembly);
        AddToAssembliesIfNotNull(infrastructureAssembly);
        AddToAssembliesIfNotNull(useCasesAssembly);
    }

    protected override void Load(ContainerBuilder builder)
    {
        LoadAssemblies();
        if (_isDevelopment)
        {
            RegisterDevelopmentOnlyDependencies(builder);
        }
        else
        {
            RegisterProductionOnlyDependencies(builder);
        }
        RegisterEF(builder);
        RegisterMediatR(builder);
    }

    private void RegisterEF(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfRepository<>))
          .As(typeof(IRepository<>))
          .As(typeof(IReadRepository<>))
          .InstancePerLifetimeScope();
    }

    private void RegisterMediatR(ContainerBuilder builder)
    {
        builder
          .RegisterType<Mediator>()
          .As<IMediator>()
          .InstancePerLifetimeScope();

        builder
          .RegisterGeneric(typeof(LoggingBehavior<,>))
          .As(typeof(IPipelineBehavior<,>))
          .InstancePerLifetimeScope();

        builder
          .RegisterType<MediatRDomainEventDispatcher>()
          .As<IDomainEventDispatcher>()
          .InstancePerLifetimeScope();

        var mediatrOpenTypes = new[]
        {
      typeof(IRequestHandler<,>),
      typeof(IRequestExceptionHandler<,,>),
      typeof(IRequestExceptionAction<,>),
      typeof(INotificationHandler<>),
    };

        foreach (var mediatrOpenType in mediatrOpenTypes)
        {
            builder
              .RegisterAssemblyTypes([.. _assemblies])
              .AsClosedTypesOf(mediatrOpenType)
              .AsImplementedInterfaces();
        }
    }

    private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
    {
        // NOTE: Add any development only services here
        //builder.RegisterType<FakeEmailSender>().As<IEmailSender>()
        //  .InstancePerLifetimeScope();

        // NOTE: Add any production only (real) services here
        //builder.RegisterType<SmtpEmailSender>().As<IEmailSender>()
        //  .InstancePerLifetimeScope();


        builder.RegisterType<ListPersonsQueryService>()
          .As<IListPersonQueryService>()
          .InstancePerLifetimeScope();

        //builder.RegisterType<FakeListIncompleteItemsQueryService>()
        //  .As<IListIncompleteItemsQueryService>()
        //  .InstancePerLifetimeScope();

        //builder.RegisterType<FakeListProjectsShallowQueryService>()
        //  .As<IListProjectsShallowQueryService>()
        //  .InstancePerLifetimeScope();
    }

    private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
    {
        // NOTE: Add any production only (real) services here
        //builder.RegisterType<SmtpEmailSender>().As<IEmailSender>()
        //  .InstancePerLifetimeScope();

        //builder.RegisterType<ListPersonsQueryService>()
        //  .As<IListPersonQueryService>()
        //  .InstancePerLifetimeScope();

        //builder.RegisterType<ListIncompleteItemsQueryService>()
        //  .As<IListIncompleteItemsQueryService>()
        //  .InstancePerLifetimeScope();

        //builder.RegisterType<ListProjectsShallowQueryService>()
        //  .As<IListProjectsShallowQueryService>()
        //  .InstancePerLifetimeScope();
    }
}
