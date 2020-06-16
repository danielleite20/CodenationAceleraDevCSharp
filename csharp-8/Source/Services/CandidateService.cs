using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly CodenationContext _context;

        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return _context.Candidates.Where(candidate => candidate.AccelerationId == accelerationId).ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return _context.Candidates.Where(candidate => candidate.CompanyId == companyId).ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return _context.Candidates.Find(userId, accelerationId, companyId);
        }

        public Candidate Save(Candidate candidate)
        {
            var candidateFromContext = _context.Candidates.Find(candidate.UserId, candidate.AccelerationId, candidate.CompanyId);
            if (candidateFromContext == null)
            {
                _context.Add(candidate);
            }
            else
            {
                _context.Entry(candidateFromContext).State = EntityState.Detached;
                _context.Update(candidate);
            }

            _context.SaveChanges();
            return candidate;
        }
    }
}