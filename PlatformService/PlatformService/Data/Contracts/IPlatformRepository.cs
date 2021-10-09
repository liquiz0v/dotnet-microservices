using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data.Contracts
{
    public interface IPlatformRepository
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform platform);
        void UpdatePlatform(Platform platform);
    }
}