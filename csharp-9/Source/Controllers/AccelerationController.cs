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
    public class AccelerationController : ControllerBase
    {    
        private readonly IAccelerationService _service;
        private readonly IMapper _mapper;

        public AccelerationController(IAccelerationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            var accel = _service.FindById(id);
            var accelDto = _mapper.Map<AccelerationDTO>(accel);
            return Ok(accelDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<AccelerationDTO>> GetAll(int? companyId = null)
        {
            if (companyId == null)
            {
                return NoContent();
            }

            ICollection<Acceleration> accelerations;

            accelerations = _service.FindByCompanyId(companyId.GetValueOrDefault());
            var accelDto = _mapper.Map<List<AccelerationDTO>>(accelerations);
            return Ok(accelDto);
        }

        [HttpPost]
        public ActionResult<AccelerationDTO> Post([FromBody] AccelerationDTO value)
        {
            var accel = _mapper.Map<Acceleration>(value);
            _service.Save(accel);

            var accelDto = _mapper.Map<AccelerationDTO>(accel);
            return Ok(accelDto);
        }
    }
}