using AutoMapper;
using System.Net;

namespace ETSystem.AutoFileConvert.Common
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<CookieContainer, CookieContainer>();
        }
    }
}
