namespace JK.Finances.Infrastructure.Models.Account.Requests;

public class CreateAccountRequest
{
    public string Name { get; set; } = string.Empty;

	public CreateAccountRequest(string name) : this()
	{
		Name = Guard.Against.NullOrWhiteSpace(name);
	}

	private CreateAccountRequest() {  }
}