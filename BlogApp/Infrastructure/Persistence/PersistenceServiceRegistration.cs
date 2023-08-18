using application.Contracts;
using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.DataContext;
using Persistance.Repositories;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            // add db context
            services.AddDbContext<BlogDataContext>(opt =>
                 opt.UseNpgsql(configuration.GetConnectionString("BlogDb")));

            services.AddScoped(typeof(IGeneric<>), typeof(GenericRepository<>));
            services.AddScoped<IPost, PostRepository>();
            services.AddScoped<IComment, CommentRepository>();
            return services;
        }
    }
}
