namespace sislte.Models;

public class Grade
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required int Act1 { get; set; }
    public required int Act2 { get; set; }
    public required int Att { get; set; }
    public required int Iw { get; set; }
    public required int Final { get; set; }
    public required int Sum { get; set; }
    public required string Mark { get; set; }

    public static List<Grade> GetExampleGrades()
    {
        return 
        [
            new()
            {
                Code = "COMP369",
                Name = "Computer networks",
                Act1 = 14,
                Act2 = 13,
                Att = 9,
                Iw = 10,
                Final = 48,
                Sum = 94,
                Mark = "A"
            },
            new()
            {
                Code = "INFS326",
                Name = "Information security",
                Act1 = 12,
                Act2 = 14,
                Att = 10,
                Iw = 9,
                Final = 45,
                Sum = 90,
                Mark = "A"
            },
            new()
            {
                Code = "IT338",
                Name = "Internet Technologies",
                Act1 = 11,
                Act2 = 13,
                Att = 8,
                Iw = 9,
                Final = 40,
                Sum = 81,
                Mark = "B"
            },
            new()
            {
                Code = "IT388",
                Name = "Modern programming languages- 2",
                Act1 = 10,
                Act2 = 12,
                Att = 7,
                Iw = 9,
                Final = 38,
                Sum = 76,
                Mark = "C"
            },
            new()
            {
                Code = "MINF461",
                Name = "Probability theory and mathematical statistics",
                Act1 = 9,
                Act2 = 11,
                Att = 8,
                Iw = 8,
                Final = 34,
                Sum = 70,
                Mark = "C"
            }
        ];
    }
}
