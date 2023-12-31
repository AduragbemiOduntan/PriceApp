﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Implementation;
using PriceApp_Application.Services.Interfaces;

namespace PriceApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperStructureEstimateController : ControllerBase
    {
        private readonly ISuperStructureEstimateService _superStructureEstimateService;
        public SuperStructureEstimateController(ISuperStructureEstimateService superStructureEstimateService)
        {
            _superStructureEstimateService = superStructureEstimateService;
        }

        /// <summary>
        /// Create building wall block work material cost estimate. Takes the building girth, wall height and an appellation as parameter
        /// </summary>
        /* [Authorize]*/
        [HttpPost("wallBlockWork")]
        public async Task<IActionResult> CreateBuildingFloorWallWorkAsnc(double girth, double buildingFloorHeight, string appellation)
        {
            var result = await _superStructureEstimateService.CreateBuildingWallBlockWorkAsync(girth, buildingFloorHeight, appellation);
            return Ok(result);
        }

        /// <summary>
        /// Create building lintel material cost estimate. Takes the building girth and an appellation as parameter
        /// </summary>
        /* [Authorize]*/
        [HttpPost("lintel")]
        public async Task<IActionResult> CreateLintel(double girth, string appellation)
        {
            var result = await _superStructureEstimateService.CreateLintelAsync(girth, appellation);
            return Ok(result);

        }

        /// <summary>
        /// Create building wall column material cost estimate. Takes the building girth, wall height and an appellation as parameter
        /// </summary>
        /*  [Authorize]*/
        [HttpPost("wallColumn")]
        public async Task<IActionResult> CreateWallColumn(double girth, double wallHeight, string appellation)
        {
            var result = await _superStructureEstimateService.CreateWallColumnAsync(girth, wallHeight, appellation);
            return Ok(result);
        }
    }
}
