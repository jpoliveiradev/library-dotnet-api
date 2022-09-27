

using Library.API.Data;

namespace Library.API.Helpers {
    public class PageParams {


        public const int MaxPageSize = 50;

        public int PageNumber { get; set; } = 1;



        public int pageSize = 1000000000;

        public int PageSize {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        //Clientes
        public string NomeUsuario { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        //Editoras
        public string NomeEditora { get; set; } = string.Empty;

        //Livros

        public string NomeLivro { get; set; } = string.Empty;

        public string Autor { get; set; } = string.Empty;

        //Admins
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

    }
}
