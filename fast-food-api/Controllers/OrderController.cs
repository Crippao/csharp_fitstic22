using fast_food;
using FastFood.Services;
using Microsoft.AspNetCore.Mvc;


namespace fast_food_api.Controllers;

[Route("api/[controller]"), ApiController]
public class OrderController : ControllerBase
{
    private readonly HelperSQL _helperSql;
    private readonly IOrderService _orderService;

    [HttpPost, Route("add")]
    public IActionResult InsertOrder() {
        if (_helperSql.InserisciOrdine(DateTime.Now, out var idIns)) {
            return Ok(new { Id = idIns });
        }

        return Problem("Cannot create the resource");
    }

    [HttpDelete, Route("delete/{id:int}")]
    public IActionResult DeleteOrder(int id) {
        if (_helperSql.CancellaOrdine(id)) {
            return Ok();
        }

        return Problem("Cannot complete request");
    }

    [HttpPut, Route("edit/{id:int}")]
    public IActionResult EditOrder(int id) {
        if (_helperSql.ModificaOrdine(DateTime.Now, id)) {
            return Ok();
        }

        return Problem("Cannot complete the request");
    }


    [HttpGet, Route("")]
    public IActionResult Get() {
        var a = _orderService.GetAll();
        return Ok(a);
    }

    
    
    [HttpGet, Route("{id:int}")]
    public IActionResult Get(int id) {
        var data = _helperSql.ListOrdini();

        foreach (var ordine in data) {
            if (ordine.ID == id) {
                return Ok(ordine);
            }
        }

        return BadRequest("Id doesn't exists");
    }




    public OrderController() {
        _orderService = new OrderService("Data Source = fast_food.db; Version = 3; New = True; Compress = True");
        _helperSql = new HelperSQL();
        _helperSql.CreateConnection();
    }
}