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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            var candidate = _service.FindById(userId, accelerationId, companyId);
            var candidateDto = _mapper.Map<CandidateDTO>(candidate);
            return Ok(candidateDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? companyId = null, int? accelerationId = null)
        {
            if ((companyId == null && accelerationId == null) || (companyId != null && accelerationId != null))
            {
                return NoContent();
            }

            ICollection<Candidate> candidates;

            if (companyId != null)
            {
                candidates = _service.FindByCompanyId(companyId.GetValueOrDefault());
            }
            else
            {
                candidates = _service.FindByAccelerationId(accelerationId.GetValueOrDefault());
            }

            var candidatesDto = _mapper.Map<List<CandidateDTO>>(candidates);
            return Ok(candidatesDto);
        }

        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            var candidate = _mapper.Map<Candidate>(value);
            _service.Save(candidate);

            var candidateDto = _mapper.Map<CandidateDTO>(candidate);
            return Ok(candidateDto);
        }
    }
}
