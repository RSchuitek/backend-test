using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PBBackend.Api.Data;
using PBBackend.Api.Repositories;

namespace PBBackend.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<EstadoRepository, EstadoRepository>();
            services.AddTransient<CidadeRepository, CidadeRepository>();
            services.AddTransient<EnderecoRepository, EnderecoRepository>();
            services.AddTransient<PessoaRepository, PessoaRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}
