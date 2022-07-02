namespace DevInSales.Api.Dtos
{
    public record AddUser(string Email, string Password, string Name, DateTime BirthDate) { }
}