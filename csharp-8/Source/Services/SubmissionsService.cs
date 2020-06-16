using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly CodenationContext _context;

        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return _context.Submissions
                .Where(submission =>
                    submission.ChallengeId == challengeId &&
                    submission.User.Candidates.Any(candidate => candidate.AccelerationId == accelerationId))
                .ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _context.Submissions
                .Where(submission => submission.ChallengeId == challengeId)
                .Max(submission => submission.Score);
        }

        public Submission Save(Submission submission)
        {
            var submissionFromContext = _context.Submissions.Find(submission.UserId, submission.ChallengeId);
            if (submissionFromContext == null)
            {
                _context.Add(submission);
            }
            else
            {
                _context.Entry(submissionFromContext).State = EntityState.Detached;
                _context.Update(submission);
            }

            _context.SaveChanges();
            return submission;
        }
    }
}