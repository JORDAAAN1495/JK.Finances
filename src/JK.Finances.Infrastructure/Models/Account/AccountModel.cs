namespace JK.Finances.Infrastructure.Models.Account;

public class AccountModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedDateTime { get; set; } = DateTime.UtcNow;
}