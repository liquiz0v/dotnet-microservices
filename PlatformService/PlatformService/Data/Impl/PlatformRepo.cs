using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.Data.Contracts;
using PlatformService.Models;

namespace PlatformService.Data.Impl
{
    public class PlatformRepo : IPlatformRepository
    {
        private AppDbContext _context;
        
        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }
        
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(i => i.Id == id);
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform != null)
            {
                _context.Add(platform);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void UpdatePlatform(Platform platform)
        {
            if (platform != null)
            {
                _context.Update(platform);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}