using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DealsMo.Client.Helpers;
using DealsMo.Client.Repository;

namespace DealsMo.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            ConfigureServices(builder.Services);
            // register the Telerik services
            builder.Services.AddTelerikBlazor();

            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddTransient<IRepository, RepositoryInMemory>();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IDealRepository, DealRepository>();
            services.AddScoped<IDealCategoryRepository, DealCategoryRepository>();
            //services.AddScoped<IPersonRepository, PersonRepository>();
            //services.AddScoped<IMoviesRepository, MoviesRepository>();
            //services.AddScoped<IAccountsRepository, AccountsRepository>();
            //services.AddScoped<IRatingRepository, RatingRepository>();
            //services.AddScoped<IDisplayMessage, DisplayMessage>();
            //services.AddScoped<IUsersRepository, UserRepository>();

            //services.AddFileReaderService(options => options.InitializeOnFirstCall = true);
            //services.AddAuthorizationCore();

            //services.AddScoped<JWTAuthenticationStateProvider>();
            //services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>(
            //    provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
            //);
            //services.AddScoped<ILoginService, JWTAuthenticationStateProvider>(
            //   provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
            //    );
        }
    }
}
