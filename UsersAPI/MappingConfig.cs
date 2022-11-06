
using WebSite.Models;

namespace UsersAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() //{ get; set; } ()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UserProfileDto, UserProfile>();
                config.CreateMap<UserProfile, UserProfileDto>();
            });

            return mappingConfig;
        }
    }
}
