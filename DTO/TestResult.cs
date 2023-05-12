namespace DTO;

public class TestResult
{
    public string UserName { get; set; } = "unknown user";
    public DateTime Created { get; set; } = DateTime.Now;
    public string TestName { get; set; } = "unknown test";
    public int TotalQuestions { get; set; }
    public int CorrectAnswerCount { get; set; }
    public bool Succeed => Percent >= .5;
    public double Percent => (double)CorrectAnswerCount / (double)TotalQuestions;
}