﻿using System;
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
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _service;
        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            var company = _service.FindById(id);
            var companyDto = _mapper.Map<CompanyDTO>(company);
            return Ok(companyDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if ((accelerationId == null && userId == null) || (accelerationId != null && userId != null))
            {
                return NoContent();
            }

            ICollection<Company> companies;

            if (accelerationId != null)
            {
                companies = _service.FindByAccelerationId(accelerationId.GetValueOrDefault());
            }
            else
            {
                companies = _service.FindByUserId(userId.GetValueOrDefault());
            }


            var companiesDto = _mapper.Map<List<CompanyDTO>>(companies);
            return Ok(companiesDto);
        }

        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            var company = _mapper.Map<Company>(value);
            _service.Save(company);

            var companyDTO = _mapper.Map<CompanyDTO>(company);
            return Ok(companyDTO);
        }
    }
}