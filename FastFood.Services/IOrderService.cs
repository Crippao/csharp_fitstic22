// CSharpFitstic22 - FastFood.Services - IOrderService.cs
// ON: 2023/03/13/12:34 PM
// 
// 
// From: Sebastiano Gaudeano


using fast_food;


namespace FastFood.Services;

public interface IOrderService
{
    List<Ordine> GetAll();
}