using System.Text.Json.Serialization;
using Models.Interfaces;

namespace Models;

/// <summary>
/// Базовая модель теста
/// </summary>
public class DTest : IHasId
{
    public string Name { get; set; }
    public List<DTestQuestion> Questions { get; set; }
    public int Id { get; set; }
}

/// <summary>
/// Базовая модель запроса
/// </summary>
public class DTestQuestion : IHasId
{
    public string Question { get; set; }
    [JsonIgnore]
    public string CorrectAnswer { get; set; }
    public List<string> Variants { get; set; }
    public bool IsCorrectAnswer(string clientAnswer) => CorrectAnswer == clientAnswer;
    public int Id { get; set; }
}