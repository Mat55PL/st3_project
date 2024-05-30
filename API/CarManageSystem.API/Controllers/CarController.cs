using CarManageSystem.Application.Cars;
using CarManageSystem.Application.Cars.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CarManageSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController(ICarsService carsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCars()
    {
        var cars = await carsService.GetAllCars();
        return Ok(cars);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var car = await carsService.GetById(id);
        if (car is null)
            return NotFound();
        
        return Ok(car);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCarDto createCarDto)
    {
        int id = await carsService.Create(createCarDto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var car = await carsService.GetById(id);
        if (car is null)
            return NotFound();
        
        await carsService.Delete(id);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CarDto updateCarDto)
    {
        var car = await carsService.GetById(id);
        if (car is null)
            return NotFound();
        
        await carsService.Update(id, updateCarDto);
        return Ok();
    }
}