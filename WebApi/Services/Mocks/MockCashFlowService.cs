using System.Collections.Generic;
using System.Text.Json;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Mocks;

public class MockCashFlowService : ICashFlowService
{
    private const string _dataFilePath = @"Data\data.json";
    private readonly List<CashFlowResponseDto> _data;


    public MockCashFlowService()
    {
        _data = LoadDataFromFile();
    }

    private List<CashFlowResponseDto> LoadDataFromFile()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _dataFilePath);
        if (!File.Exists(filePath)) throw new FileNotFoundException("data for mock list");
        var jsonData = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<List<CashFlowResponseDto>>(jsonData, options) ?? new List<CashFlowResponseDto>();
    }

    public async Task<List<CashFlowResponseDto>> GetCashFlow(DateTime from, DateTime to)
    {
        List<CashFlowResponseDto> result = _data.Where(x => x.Date >= from && x.Date <= to).OrderBy(x => x.Date).ToList();
        return await Task.FromResult(result);
    }

}