using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _service;
        private readonly IMapper _mapper;

        public SubmissionController(ISubmissionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{higherScore}")]
        public ActionResult<decimal> GetHigherScore(int? challengeId)
        {
            if (challengeId == null)
            {
                return NoContent();
            }

            var higherScore = _service.FindHigherScoreByChallengeId(challengeId.GetValueOrDefault());
            return Ok(higherScore);
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? challengeId, int? accelerationId)
        {
            if ((challengeId == null && accelerationId == null))
            {
                return NoContent();
            }

            ICollection<Submission> submissions;

            submissions = _service.FindByChallengeIdAndAccelerationId(challengeId.GetValueOrDefault(), accelerationId.GetValueOrDefault());

            var submissionsDto = _mapper.Map<List<SubmissionDTO>>(submissions);
            return Ok(submissionsDto);
        }
        
        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            var submission = _mapper.Map<Submission>(value);
            _service.Save(submission);

            var submissionDto = _mapper.Map<SubmissionDTO>(submission);
            return Ok(submissionDto);
        }
    }
}