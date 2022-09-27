using System;

namespace Library.API.V2.Dtos.AdminCreateDto {
    public class AdminCreateDto {
        public string NomeAdmin { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
