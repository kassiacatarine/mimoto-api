using System.Collections.Generic;
using AutoMapper;
using Mimoto.Application.ViewModels.Common;
using Mimoto.Domain.Common;
using Mimoto.Infrastructure.Data;
using MongoDB.Driver;

namespace Mimoto.Application.Apps.Common
{
    public class AppService
    {
        private readonly IMimotoContext _context;
        private readonly IMapper _mapper;

        public AppService(IMimotoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<App> Get()
        {
            return _context.Apps.Find(app => true).ToList();
        }

        public App Get(string id)
        {
            return _context.Apps.Find<App>(app => app.Id == id).FirstOrDefault();
        }

        public App Create(AppProfileViewModel model)
        {
            var app = _mapper.Map<App>(model);
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