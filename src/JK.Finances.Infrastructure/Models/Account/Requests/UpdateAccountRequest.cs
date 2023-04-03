namespace JK.Finances.Infrastructure.Models.Account.Requests;

public class UpdateAccountRequest
{
    public string Name { get; set; } = string.Empty;

	public UpdateAccountRequest(string name) : this()
	{
		Name = Guard.Against.NullOrWhiteSpace(name);
	}

	private UpdateAccountRequest() {  }
}