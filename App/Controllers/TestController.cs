using System.Text.Json;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace App.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TestController : ControllerBase
{
    

    private List<DTest> _db = new List<DTest>()
    {
        new DTest()
        {
            Id = 1,
            Name = "Test 1",
            Questions = new List<DTestQuestion>()
            {
                new DTestQuestion()
                {
                    Id = 1,
                    Question = "asd?",
                    Variants = new List<string>()
                    {
                        "asd",
                        "qwe",
                        "qqq",
                        "ccc",
                        "aaa",
                        "ddd",
                    },
                    CorrectAnswer = "asd"
                },
                new DTestQuestion()
                {
                    Id = 2,
                    Question = "ccc?",
                    Variants = new List<string>()
                    {
                        "as",
                        "asd",
                        "ccc"
                    },
                    CorrectAnswer = "ccc"
                }
            }
        }
    };
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetTestList()
    {
        return Ok(JsonSerializer.Serialize(_db.Select(i => new
        {
            Id = i.Id,
            Name = i.Name
        })));
    }
    
    [HttpGet]
    public DTest? GetTest([FromQuery]int testId)
    {
        return _db.FirstOrDefault(i => i.Id == testId);
    }

    [HttpPost]
    public TestResult? Validate([FromBody] TestCompleted testCompleted)
    {
        var dTest = _db.FirstOrDefault(i => i.Id == testCompleted.TestId);
        if (dTest is null)
            return null;
        var answers = dTest.Questions.Select(i => i.IsCorrectAnswer(testCompleted.Answers.FirstOrDefault(a => i.Id == a.Id)?.Answer ?? string.Empty)) ;
        return new TestResult()
        {
            TotalQuestions = dTest.Questions.Count,
            CorrectAnswerCount = answers.Count(i => i),
        };
    }
}