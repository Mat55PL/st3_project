using CarManageSystem.Application.CarsFuelHistory;
using CarManageSystem.Application.CarsFuelHistory.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CarManageSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarFuelHistoryController(ICarsFuelHistoryService carsFuelHistoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCarsFuelHistory()
    {
        var carsFuelHistory = await carsFuelHistoryService.GetAllFuelHistoryAsync();
        return Ok(carsFuelHistory);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var carFuelHistory = await carsFuelHistoryService.GetFuelHistoryByIdAsync(id);
        if (carFuelHistory is null)
            return NotFound();
        
        return Ok(carFuelHistory);
    }
    
    [HttpGet("car/{carId}")]
    public async Task<IActionResult> GetByCarId([FromRoute] int carId)
    {
        var carFuelHistory = await carsFuelHistoryService.GetFuelHistoryByCarIdAsync(carId);
        if (carFuelHistory is null)
            return NotFound();
        
        return Ok(carFuelHistory);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFuelHistoryDto createCarFuelHistoryDto)
    {
        var carFuelHistory = await carsFuelHistoryService.AddFuelHistoryAsync(createCarFuelHistoryDto);
        return CreatedAtAction(nameof(GetById), new { id = carFuelHistory.Id }, carFuelHistory);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var carFuelHistory = await carsFuelHistoryService.GetFuelHistoryByIdAsync(id);
        if (carFuelHistory is null)
            return NotFound();
        
        await carsFuelHistoryService.DeleteFuelHistoryAsync(id);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] FuelHistoryDto updateCarFuelHistoryDto)
    {
        var carFuelHistory = await carsFuelHistoryService.GetFuelHistoryByIdAsync(id);
        if (carFuelHistory is null)
            return NotFound();
        
        await carsFuelHistoryService.UpdateFuelHistoryAsync(id, updateCarFuelHistoryDto);
        return Ok();
    }
}