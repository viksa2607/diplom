namespace DTO;

public class TestResult
{
    public int TotalQuestions { get; set; }
    public int CorrectAnswerCount { get; set; }
    public bool Succeed => Percent >= .5;
    public double Percent => (double)CorrectAnswerCount / (double)TotalQuestions;
}