using System.Collections.Generic;
using AutoMapper;
using Mimoto.Application.ViewModels.Common;
using Mimoto.Domain.Common;
using Mimoto.Infrastructure.Data;
using MongoDB.Driver;

namespace Mimoto.Application.Services.Common
{
    public class CompanyService
    {
        private readonly IMimotoContext _context;
        private readonly IMapper _mapper;

        public CompanyService(IMimotoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Company> Get()
        {
            return _context.Companies.Find(company => true).ToList();
        }

        public Company Get(string id)
        {
            return _context.Companies.Find<Company>(company => company.Id == id).FirstOrDefault();
        }

        public Company Create(CompanyProfileViewModel model)
        {
            var company = _mapper.Map<Company>(model);
            _context.Companies.InsertOne(company);
            return company;
        }

        public void Update(string id, Company companyIn)
        {
            _context.Companies.ReplaceOne(company => company.Id == id, companyIn);
        }

        public void Remove(Company companyIn)
        {
            _context.Companies.DeleteOne(company => company.Id == companyIn.Id);
        }

        public void Remove(string id)
        {
            _context.Companies.DeleteOne(company => company.Id == id);
        }
    }
}