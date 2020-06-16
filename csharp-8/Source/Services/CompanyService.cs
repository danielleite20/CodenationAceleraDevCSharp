using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CodenationContext _context;

        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return _context.Candidates
                .Where(candidate => candidate.AccelerationId == accelerationId)
                .Select(candidate => candidate.Company)
                .ToList();
        }

        public Company FindById(int id)
        {
            return _context.Companies.Find(id);
        }

        public IList<Company> FindByUserId(int userId)
        {
            return _context.Companies
                .Where(company => company.Candidates.Any(candidate => candidate.UserId == userId))
                .OrderByDescending(company => company.Id)
                .ToList();
        }

        public Company Save(Company company)
        {
            if (company.Id == 0)
            {
                _context.Add(company);
            }
            else
            {
                _context.Update(company);
            }

            _context.SaveChanges();
            return company;
        }
    }
}