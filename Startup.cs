using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campus_api.Repositories.Entities;
using campus_api.Services.IMappingService;
using campus_api.Services.Mappers;
using campus_api.Services.MappingService;
using CampusISApi.Model;
using CampusISApi.Repositories;
using CampusISApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CampusISApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddTransient<IRoomService, RoomService>();
            services.TryAddTransient<IRoomRepository, RoomRepository>();
            services.TryAddTransient<IRoomMappingService, RoomMappingService>();

            services.TryAddTransient<IMapper<Room, RoomEntity>, RoomToRoomEntityMapper>();
            services.TryAddTransient<IMapper<RoomEntity, Room>, RoomEntityToRoomMapper>();
            services.TryAddTransient<IMapper<IEnumerable<RoomEntity>, IEnumerable<Room>>, EnumerableMapper<RoomEntity, Room>>();



            //services.TryAddSingleton<IEnumerable<Room>>(new Room[]{
            //    new Room { Name = "Iga" },
            //    new Room { Name = "Kōga" },
            //});

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionString));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
