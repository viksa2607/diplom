using System.Text.Json;
using DTO;
using Models;

namespace DAL;

public class TestRepository
{
    private static object testsLocker = new();
    private const string testsFileName = "tests.json"; 
    private const string testResultsFileName = "results.json"; 
    public List<DTest> List()
    {
        lock (testsLocker)
        {
            return JsonSerializer.Deserialize<List<DTest>>(File.ReadAllText(testsFileName)) ?? throw new Exception("Не удается считать файл tests");
        }
    }
    
    public List<TestResult> Results()
    {
        lock (testsLocker)
        {
            if (File.Exists(testResultsFileName))
            {
                return JsonSerializer.Deserialize<List<TestResult>>(File.ReadAllText(testResultsFileName)) ?? new List<TestResult>();
            }
            
            using var fs = File.CreateText(testResultsFileName);
            fs.Write("[]");
            fs.Close();
            return new List<TestResult>();
            
        }
    }

    public void AddResult(TestResult result)
    {
        var results = Results();
        results.Add(result);
        lock (testsLocker)
        {
            File.WriteAllText(testResultsFileName, JsonSerializer.Serialize(results));
        }
    }
}