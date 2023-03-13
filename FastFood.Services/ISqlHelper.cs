// CSharpFitstic22 - FastFood.Services - ISqlHelper.cs
// ON: 2023/03/13/12:32 PM
// 
// 
// From: Sebastiano Gaudeano


using System.Data;


namespace FastFood.Services;

public interface ISqlHelper
{
    DataTable GetAll(string query);
}