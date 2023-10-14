namespace New_Era.Services
{
    public static class ServicesDependencyInjection
    {
        public static IServiceCollection AddServicesDependencyInjection(this IServiceCollection services)
        {
            //Dependency Injection
            services.AddScoped<IStudentServices, StudentServices>();
            services.AddScoped<IDepartmentServices, DepartmentServices>();

            return services;
        }
    }
}
