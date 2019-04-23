using System.Collections.Generic;
using Mimoto.Domain.Common;
using Mimoto.Infrastructure.Data;
using MongoDB.Driver;

namespace Mimoto.Application.Apps.Common
{
    public class AppService
    {
        private readonly IMimotoContext _context;

        public AppService(IMimotoContext context) {
            _context = context;
        }

        public List<App> Get()
        {
            return _context.Apps.Find(app => true).ToList();
        }

        public App Get(string id)
        {
            return _context.Apps.Find<App>(app => app.Id == id).FirstOrDefault();
        }

        public App Create(App app)
        {
            _context.Apps.InsertOne(app);
            return app;
        }

        public void Update(string id, App appIn)
        {
            _context.Apps.ReplaceOne(app => app.Id == id, appIn);
        }

        public void Remove(App appIn)
        {
            _context.Apps.DeleteOne(app => app.Id == appIn.Id);
        }

        public void Remove(string id)
        {
            _context.Apps.DeleteOne(app => app.Id == id);
        }
    }
}