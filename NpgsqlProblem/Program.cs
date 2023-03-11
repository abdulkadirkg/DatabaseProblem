using Bogus;
using NpgsqlProblem;

public class Program
{
    private static async Task Main(string[] args)
    {
        var dummyData = new Faker<DummyDataClass>("tr")
            .RuleFor(s => s.Field1, opt => opt.Lorem.Paragraphs(60))
            .RuleFor(s => s.Field2, opt => opt.Lorem.Paragraphs(60))
            .RuleFor(s => s.Field3, opt => opt.Lorem.Paragraphs(60))
            .RuleFor(s => s.FieldBool, opt => opt.PickRandom(true, false))
            .RuleFor(s => s.FieldInt, opt => opt.Random.Number())
            .Generate(10000);
        Console.WriteLine("Dummy Data Generated");
        var context = new Context();
        await context.DummyDataClasses.AddRangeAsync(dummyData);
        Console.WriteLine("Dummy Data Added");
        await context.SaveChangesAsync();
        Console.WriteLine("Dummy Data Saved");
        Console.WriteLine(context.DummyDataClasses.Count().ToString());


    }
}