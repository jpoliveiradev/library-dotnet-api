using Library.API.Models;

namespace Library.API.Services.Interfaces {
    public interface IAluguelService {

        Alugueis AluguelCreate(Alugueis model);
        Alugueis AluguelUpdate(Alugueis model);

    }
}
