namespace sislte.Models;

public class CProgram
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Lang { get; set; }

    public static List<CProgram> GetExamplePrograms()
    {
        return
        [
            new CProgram { Code = "10104", Name = "Information Technologies (Bachelor)", Lang = "AZ" },
            new CProgram { Code = "10602", Name = "Information technologies (Bachelor)", Lang = "AZ" },
            new CProgram { Code = "10106", Name = "Information Technologies (Bachelor)", Lang = "EN" },
            new CProgram { Code = "10142", Name = "Information Technologies (DDP) (Bachelor)", Lang = "EN" },
            new CProgram { Code = "12028", Name = "Systematic analysis, management and information processing (Doctorate)", Lang = "AZ" },
            new CProgram { Code = "12032", Name = "Systematic analysis, management and information processing (Doctorate)", Lang = "AZ" },
            new CProgram { Code = "12008", Name = "Systematic analysis, management and information processing (Dissertate)", Lang = "AZ" },
            new CProgram { Code = "11035", Name = "IT Management (Master)", Lang = "EN" }
        ];
    }
}