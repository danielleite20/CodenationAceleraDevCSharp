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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {            
            if ((accelerationName == null && companyId == null) || (accelerationName != null && companyId != null))
            {
                return NoContent();
            }

            ICollection<User> users;

            if (accelerationName != null)
            {
                users = _service.FindByAccelerationName(accelerationName);
            }
            else
            {
                users = _service.FindByCompanyId(companyId.GetValueOrDefault());
            }

            return Ok(_mapper.Map<List<UserDTO>>(users));
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {            
            var user = _service.FindById(id);
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            var user = _mapper.Map<User>(value);
            _service.Save(user);
            
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }   
     
    }
}
