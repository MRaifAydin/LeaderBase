using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaderBase.Conversion.MapperProfiles;

namespace LeaderBase.Conversion
{
    public class ConversionDI
    {
        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<LeaderProfile>();
                cfg.AddProfile<PersonProfile>();
            });
        }
    }
}
