namespace CA_Microservices_DotNet.Domain.Entities;

public class Log
{
    public int Id { get; set; }

    public string Level { get; set; }

    public string Message { get; set; }

    public string MessageTemplate { get; set; }

    public DateTimeOffset TimeStamp { get; set; }

    public string Exception { get; set; }

    public string Properties { get; set; }
}
