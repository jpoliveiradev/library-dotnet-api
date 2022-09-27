using System;

namespace Library.API.V2.Dtos.AdminDto {
    public class AdminDto {
        public int Id { get; set; }
        public string NomeAdmin { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
