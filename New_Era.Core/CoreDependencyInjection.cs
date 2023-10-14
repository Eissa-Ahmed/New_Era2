namespace New_Era.Core
{
    public static class CoreDependencyInjection
    {
        public static IServiceCollection AddCoreDependencyInjection(this IServiceCollection services)
        {
            //Mediator
            services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //Auto Mapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Fluent Validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
