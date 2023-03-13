﻿using fast_food;
using Microsoft.AspNetCore.Mvc;


namespace fast_food_api.Controllers;

[Route("api/[controller]"), ApiController]
public class OrderController : ControllerBase
{
    private readonly HelperSQL _helperSql;

    [HttpPost, Route("/add")]
    public IActionResult InsertOrder() {
        if (_helperSql.InserisciOrdine(DateTime.Now, out var idIns)) {
            return Ok(new { Id = idIns });
        }

        return Problem("Cannot create the resource");
    }

    [HttpDelete, Route("/delete/{id:int}")]
    public IActionResult DeleteOrder(int id) {
        if (_helperSql.CancellaOrdine(id)) {
            return Ok();
        }

        return Problem("Cannot complete request");
    }

    [HttpPut, Route("/edit/{id:int}")]
    public IActionResult EditOrder(int id) {
        if (_helperSql.ModificaOrdine(DateTime.Now, id)) {
            return Ok();
        }

        return Problem("Cannot complete the request");
    }

    //[HttpPost, Route("/initialize")]
    //public IActionResult Initialize() {
    //    if (_helperSql.CreateTable()) {
    //        return Ok();
    //    }


    //    return Problem("There was an error managing your request");
    //}

    [HttpGet, Route("/")]
    public IActionResult Get() {
        var data = _helperSql.GetAllOrders();

        return Ok(data);
    }


    public OrderController() {
        _helperSql = new HelperSQL();
        _helperSql.CreateConnection();
    }
}