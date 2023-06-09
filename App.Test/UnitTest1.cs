using Models;

namespace App.Test;

public class UnitTest1
{
    [Fact]
    public void TestValidateAnswer()
    {
        var test = new DTest()
        {
            Name = "Test 1",
            Questions = new List<DTestQuestion>()
            {
                new DTestQuestion()
                {
                    Id=1,
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
                    Id=2,
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
        
        Assert.True(isCorrectAnswer);
        var testQuestionAnswerFalse = new
        {
            Id = 1,
            Answer = "qqq"
        };
        var isInCorrectAnswer = 
            test.Questions.FirstOrDefault(i => i.Id == testQuestionAnswerFalse.Id)?.IsCorrectAnswer(testQuestionAnswerFalse.Answer) ?? false;
        Assert.False(isInCorrectAnswer);
    }
}