﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Point = Core.Entities.Halko.Point;

namespace Api.Controllers
{
    [Authorize]
    public class PointController : BaseApiController
    {
        private readonly IPointService _pointService;

        public PointController( 
            IPointService pointService,
            UserManager<AppUser> userManager ) : base( userManager )
        {
            _pointService = pointService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Point>>> GetPoints()
        {
            return Ok ( await _pointService.ListPointsAsync() );
        }
    }
}