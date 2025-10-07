using System.Collections.Generic;

namespace OrangeChatBusiness
{
    public interface ICrudOrangeChat<T>
    {
        List<T> ListarTodos();
        T? ObterPorId(string id);
        T Criar(T entity);
        bool Atualizar(T entity);
        bool Remover(string id);
    }
}