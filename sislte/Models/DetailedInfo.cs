namespace sislte.Models;

public class DetailedInfo
{
    public string Field { get; set; }
    public string Value { get; set; }

    public DetailedInfo(string field, string value)
    {
        Field = field;
        Value = value;
    }
}