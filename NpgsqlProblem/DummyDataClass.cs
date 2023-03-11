using NpgsqlTypes;
namespace NpgsqlProblem;
public class DummyDataClass
{
    public Guid Id { get; set; }
    public string Field1 { get; set; }
    public string Field2 { get; set; }
    public string Field3 { get; set; }
    public int FieldInt { get; set; }
    public bool FieldBool { get; set; }
    public NpgsqlTsVector SearchVector { get; set; }
}
