using System.Collections.Generic;
using Mimoto.Domain.Common;
using Mimoto.Infrastructure.Data;
using MongoDB.Driver;

namespace Mimoto.Application.Services.Common
{
    public class ServiceService
    {
        private readonly IMimotoContext _context;

        public ServiceService(IMimotoContext context) {
            _context = context;
        }

        public List<Service> Get()
        {
            return _context.Services.Find(service => true).ToList();
        }

        public Service Get(string id)
        {
            return _context.Services.Find<Service>(service => service.Id == id).FirstOrDefault();
        }

        public Service Create(Service service)
        {
            _context.Services.InsertOne(service);
            return service;
        }

        public void Update(string id, Service serviceIn)
        {
            _context.Services.ReplaceOne(service => service.Id == id, serviceIn);
        }

        public void Remove(Service serviceIn)
        {
            _context.Services.DeleteOne(service => service.Id == serviceIn.Id);
        }

        public void Remove(string id)
        {
            _context.Services.DeleteOne(service => service.Id == id);
        }
    }
}