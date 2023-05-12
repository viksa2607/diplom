using DTO;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
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
                    Variants = new List<string>()
                    {
                        "asd",
                        "qwe",
                        "qqq"
                    },
                    Answer = "asd"
                },
                new DTestQuestion()
                {
                    Id = 2,
                    Variants = new List<string>()
                    {
                        "as",
                        "asd",
                        "ccc"
                    },
                    Answer = "ccc"
                }
            }
        }
    };
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetTest")]
    public DTest? Get([FromQuery]int testId)
    {
        return _db.FirstOrDefault(i => i.Id == testId);
    }

    [HttpPost(Name = "PostValidateTest")]
    public TestResult Validate([FromBody] TestCompleted testCompleted)
    {
        var dTest = _db.FirstOrDefault(i => i.Id == testCompleted.TestId);
        var answers = dTest.Questions.Select(i => i.IsCorrectAnswer(testCompleted.Answers.FirstOrDefault(a => i.Id == a.Id)?.Answer ?? string.Empty)) ;
        return new TestResult()
        {
            TotalQuestions = dTest.Questions.Count,
            CorrectAnswerCount = answers.Count(i => i),
        };
    }
}