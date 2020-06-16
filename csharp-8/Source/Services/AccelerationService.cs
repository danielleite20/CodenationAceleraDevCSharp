using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private readonly CodenationContext _context;

        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return _context.Accelerations
                .Where(acceleration => acceleration.Candidates.Any(candidate => candidate.CompanyId == companyId))
                .ToList();
        }

        public Acceleration FindById(int id)
        {
            return _context.Accelerations.Find(id);
        }

        public Acceleration Save(Acceleration acceleration)
        {
            if (acceleration.Id == 0)
            {
                _context.Add(acceleration);
            }
            else
            {
                _context.Update(acceleration);
            }

            _context.SaveChanges();
            return acceleration;
        }
    }
}

