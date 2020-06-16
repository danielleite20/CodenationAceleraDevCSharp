using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly CodenationContext _context;

        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return _context.Challenges
                .Where(challenge =>
                    challenge.Accelerations.Any(acceleration => acceleration.Id == accelerationId) &&
                    challenge.Accelerations.SelectMany(acceleration => acceleration.Candidates)
                        .Any(candidate => candidate.UserId == userId))
                .ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id == 0)
            {
                _context.Add(challenge);
            }
            else
            {
                _context.Update(challenge);
            }

            _context.SaveChanges();
            return challenge;
        }
    }
}