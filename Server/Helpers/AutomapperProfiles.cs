using AutoMapper;
using DealsMo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealsMo.Server.Helpers
{
    public class AutomapperProfiles: Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Deal, Deal>()
                .ForMember(x => x.ImageURL, option => option.Ignore());
        }
    }
}
