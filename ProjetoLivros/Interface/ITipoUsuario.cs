﻿using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface ITipoUsuario
    {
        List<TipoUsuario> ListaTodos();
        TipoUsuario BuscarPorId(int id);
        void Cadastrar(TipoUsuario tipoUsuario);
        void Atualizar(int id, TipoUsuario tipoUsuario);
        void Deletar(int id);
    }
}
