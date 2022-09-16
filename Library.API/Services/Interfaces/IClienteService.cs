using Library.API.Models;

namespace Library.API.Services.Interfaces {
    public interface IClienteService {

        Clientes ClienteCreate(Clientes model); 
        Clientes ClienteUpdate(Clientes model);
       

    }
}
