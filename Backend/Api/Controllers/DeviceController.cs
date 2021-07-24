﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Core.Entities.Halko;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class DeviceController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IDeviceService _deviceService;

        public DeviceController(
            IMapper mapper,
            IDeviceService deviceService,
            UserManager<AppUser> userManager ) : base ( userManager )
        {
            _mapper = mapper;
            _deviceService = deviceService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateDevice( DeviceCreateDto deviceCreateDto )
        {
            if( !IsLogin() ) return Unauthorized();

            var device = _mapper.Map<Device> ( deviceCreateDto );
            var result = await _deviceService.CreateDevice ( device );

            return result <= 0 ? BadRequest() : Ok();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceDisplayItemDto>>> GetDevices( [FromQuery] string point )
        {
            if( !IsLogin() ) return Unauthorized();

            var deviceList =  await _deviceService.GetDevicesToSell ( point );
            var deviceListToReturn = _mapper.Map<IEnumerable<DeviceDisplayItemDto>> ( deviceList );

            return Ok ( deviceListToReturn );
        }
        
        
        [HttpGet("sold")]
        public async Task<ActionResult<IEnumerable<DeviceDisplayItemDto>>> GetSoldDevices( [FromQuery] string point )
        {
            if( !IsLogin() ) return Unauthorized();

            var deviceList =  await _deviceService.GetSoldDevices ( point );
            var deviceListToReturn = _mapper.Map<IEnumerable<DeviceDisplayItemDto>> ( deviceList );

            return Ok ( deviceListToReturn );
        }


        [HttpGet("details")]
        public async Task<ActionResult<DeviceDisplayItemDto>> GetDeviceById( [FromQuery] int id )
        {
            if( !IsLogin() ) return Unauthorized();

            var device = await _deviceService.GetDeviceToSellById ( id );
            var deviceToReturn = _mapper.Map<DeviceDisplayItemDto> ( device );

            return Ok ( deviceToReturn );
        }


        [HttpPut ( "sell" )]
        public async Task<ActionResult> SellDevice( [FromQuery] int id, double price )
        {
            if( !IsLogin() ) return Unauthorized();

            var result = await _deviceService.SellDevice ( id, price );

            return result <= 0 ? BadRequest() : Ok();
        }


        [HttpPut ( "move" )]
        public async Task<ActionResult> MoveDevice( [FromQuery] int id, string point )
        {
            if( !IsLogin() ) return Unauthorized();

            var result = await _deviceService.MoveDevice ( id, point );

            return result <= 0 ? BadRequest() : Ok();
        }


        [HttpGet ( "states" )]
        public async Task<ActionResult<IReadOnlyList<DeviceState>>> GetDeviceState()
        {
            return Ok ( await _deviceService.ReadDeviceState() );
        }
    }
}