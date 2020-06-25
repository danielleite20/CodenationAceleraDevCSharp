using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IChallengeService _service;
        public ChallengeController(IChallengeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if ((accelerationId == null && userId == null))
            {
                return NoContent();
            }

            ICollection<Models.Challenge> challenges;

            challenges = _service.FindByAccelerationIdAndUserId(accelerationId.GetValueOrDefault(), userId.GetValueOrDefault());            
            var challengesDto = _mapper.Map<List<ChallengeDTO>>(challenges);
            return Ok(challengesDto);
        }
        
        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            var challenge = _mapper.Map<Models.Challenge>(value);
            _service.Save(challenge);

            var challengeDto = _mapper.Map<ChallengeDTO>(challenge);
            return Ok(challengeDto);
        }
    }
}
