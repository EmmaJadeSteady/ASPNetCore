using Microsoft.AspNetCore.Mvc;
using TheWorld.Entities;
using TheWorld.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TheWorld.Controllers.Api{
    [Route("api/trips")]
    public class TripsController: Controller{
        private IWorldRepository _repository;
        private WorldContext _context;
        private ILogger<TripsController> _logger;

        public TripsController(IWorldRepository repository, 
        WorldContext context, ILogger<TripsController> logger)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }
        [HttpGet("")]
        public IActionResult Get(){
            try{   
            var results = _repository.GetAllTrips();
            return Ok(Mapper.Map<IEnumerable<TripViewModel>>(results));
            }
            catch(Exception ex){
                _logger.LogError($"Failed to get trips ", ex);
                return BadRequest("Failed request");
            }
        }
          
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]TripViewModel theTrip){
         
         if(ModelState.IsValid){           
           var newTrip = Mapper.Map<Trip>(theTrip);
           _repository.AddTrip(newTrip);
           if(await _repository.SaveChangesAsync()){
                return Created($"api/trips/{theTrip.Name}", Mapper.Map<TripViewModel>(newTrip));
           }else{
                return BadRequest("failed to save changes to the databse : " + theTrip.Name );
           }
         }
         return BadRequest(ModelState );
        }
    }
}