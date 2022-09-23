using Library.API.Data;
using Library.API.Models;
using Library.API.Services.Interfaces;
using System;

namespace Library.API.Services {
    public class AluguelService : IAluguelService {
        private readonly IRepository _repo;

        public AluguelService(IRepository repository) {
            _repo = repository;
        }
        
        public Alugueis AluguelCreate(Alugueis model) {

            if (model.DataPrevisao < model.DataAluguel) {
                return null;
            }
            else {

                var livro = _repo.GetLivroById(model.LivroId);
                livro.Quantidade -= 1;
                livro.QuantAlugado += 1;

                _repo.Add<Alugueis>(model);
                _repo.Update<Livros>(livro);
                _repo.SaveChanges();

                return model;
            }
        }

        public Alugueis AluguelUpdate(Alugueis model) {
            if (model.DataDevolucao < model.DataAluguel) {
                return null;
            }


            else {

                var livro = _repo.GetLivroById(model.LivroId);
                livro.Quantidade += 1;
                livro.QuantAlugado -= 1;

                _repo.Update<Alugueis>(model);
                _repo.Update<Livros>(livro);
                _repo.SaveChanges();

                return model;

            }

        }
    }
}
