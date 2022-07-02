using System.ComponentModel.DataAnnotations;
using DevInSales.Core.Entities;

namespace DevInSales.EFCoreApi.Api.DTOs.Request
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public UserResponse(int id, string email, string name, DateTime birthDate)
        {
            Id = id;
            Email = email;
            Name = name;
            BirthDate = birthDate;
        }

        public static UserResponse ConverterParaEntidade(User user)
        {
            return new UserResponse(user.Id, user.Email, user.Name, user.BirthDate);
        }
    }
}