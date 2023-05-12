using System.Text.Json;
using DAL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace App.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TestController : ControllerBase
{
    private readonly TestRepository _testRepository;

    private List<DTest> _dTests;
    private readonly ILogger<TestController> _logger;
    public TestController(ILogger<TestController> logger, TestRepository testRepository)
    {
        _logger = logger;
        _testRepository = testRepository;
        _dTests = _testRepository.List();
    }

    [HttpGet]
    public IActionResult GetTestList()
    {
        return Ok(JsonSerializer.Serialize(_dTests.Select(i => new
        {
            Id = i.Id,
            Name = i.Name
        })));
    }
    
    [HttpGet]
    public DTest? GetTest([FromQuery]int testId)
    {
        return _dTests.FirstOrDefault(i => i.Id == testId);
    }

    [HttpPost]
    public TestResult? Validate([FromBody] TestCompleted testCompleted)
    {
        var dTest = _dTests.FirstOrDefault(i => i.Id == testCompleted.TestId);
        if (dTest is null)
            return null;
        var answers = dTest.Questions.Select(i => i.IsCorrectAnswer(testCompleted.Answers.FirstOrDefault(a => i.Id == a.Id)?.Answer ?? string.Empty)) ;
        var result = new TestResult()
        {
            TotalQuestions = dTest.Questions.Count,
            CorrectAnswerCount = answers.Count(i => i),
            UserName = testCompleted.UserName,
            TestName = dTest.Name
        };
        _testRepository.AddResult(result);
        return result;
    }

    [HttpGet]
    public List<TestResult> GetLastResults()
    {
        return _testRepository.Results();
    }
}