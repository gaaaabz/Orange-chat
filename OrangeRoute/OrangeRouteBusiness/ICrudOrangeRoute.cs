using System.Collections.Generic;

namespace OrangeRouteBusiness
{
    public interface ICrudOrangeRoute<T>
    {
        List<T> ListarTodos();
        T? ObterPorId(int id);
        T Criar(T entity);
        bool Atualizar(T entity);
        bool Remover(int id);
    }
}