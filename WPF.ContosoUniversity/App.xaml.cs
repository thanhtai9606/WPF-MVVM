using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Pattern.EF.DataContext;
using Repository.Pattern.EF.Factory;
using Repository.Pattern.EF.Repositories;
using Repository.Pattern.EF.UnitOfWork;
using System;
using System.IO;
using System.Windows;
using WPF.Contract;
using WPF.Model;
using WPF.Services;
using WPF.ViewModel;

namespace WPF.ContosoUniversity
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            // Create a service collection and configure our dependencies
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Build the our IServiceProvider and set our static reference to it
            ServiceProvider = serviceCollection.BuildServiceProvider();
            //Firstly delete StartupUri="" in App.XAML
            //Secondly Register for DI pattern
            //Set for ViewModel base MVVM Model
            //Can set Multiple Context 

            var mainWindow = new StudentWindow { DataContext = ServiceProvider.GetService<StudentViewModel>() };
            mainWindow.Show();
        }
        private void ConfigureServices(IServiceCollection services)
        {

            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));
            services.AddDbContext<UniversityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ContosoUniversity")));
            services.AddScoped<IDataContextAsync, UniversityContext>();
            services.AddScoped<IUnitOfWorkAsync, UnitOfWork>();
            services.AddScoped<IRepositoryAsync<Student>, Repository<Student>>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddTransient<StudentViewModel>();
        }

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //    var builder = new ConfigurationBuilder()
        //       .SetBasePath(Directory.GetCurrentDirectory())
        //       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        //    Configuration = builder.Build();

        //    // Create a service collection and configure our dependencies
        //    var serviceCollection = new ServiceCollection();
        //  //  ConfigureServices(serviceCollection);

        //    // Build the our IServiceProvider and set our reference to it
        //    ServiceProvider = serviceCollection.BuildServiceProvider();
        //    var container = new UnityContainer();

        //    container.RegisterType<IDataContextAsync, UniversityContext>();
        //    container.RegisterType<IUnitOfWorkAsync, UnitOfWork>();
        //    container.RegisterType<IRepositoryAsync<Student>, Repository<Student>>();
        //    container.RegisterType<IService<Student>, Service<Student>>();
        //    container.RegisterType<IStudentService, StudentService>();
        // //   container.Registrations(UniversityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ContosoUniversity")));
        //    var mainWindow = container.Resolve<StudentViewModel>();
        //    var win = new StudentWindow { DataContext = mainWindow };
        //    win.Show();
        //}
    }
}
