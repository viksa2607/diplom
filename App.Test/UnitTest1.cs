using Models;

namespace App.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var test = new DTest()
        {
            Name = "Test 1",
            Questions = new List<DTestQuestion>()
            {
                new DTestQuestion()
                {
                    Variants = new List<string>()
                    {
                        "asd",
                        "qwe",
                        "qqq"
                    },
                    CorrectAnswer = "asd"
                },
                new DTestQuestion()
                {
                    Variants = new List<string>()
                    {
                        "as",
                        "asd",
                        "ccc"
                    },
                    CorrectAnswer = "ccc"
                }
            }
        };

        var testQuestionAnswer = new
        {
            Id = 1,
            Answer = "asd"
        };
        var isCorrectAnswer = 
            test.Questions.FirstOrDefault(i => i.Id == testQuestionAnswer.Id)?.IsCorrectAnswer(testQuestionAnswer.Answer) ?? false;
    }
}