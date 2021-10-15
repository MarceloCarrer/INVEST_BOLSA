using Invest.BLL.Models;
using Invest.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.API.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class MesesController : ControllerBase
    {
        private readonly IMesRepository _mesRepository;

        public MesesController(IMesRepository mesRepository)
        {
            _mesRepository = mesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mes>>> GetMeses()
        {
            return await _mesRepository.GetAllMeses().ToListAsync();
        }
    }
}
