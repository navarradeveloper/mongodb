using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Blog.DA
{
    public interface IRepository<T> : IDisposable where T : class
    {

        /// <summary>
        /// Obtiene todos los objetos de la base de datos
        /// </summary>
        IEnumerable<T> All();

        
        /// <summary>
        /// Obtiene objetos de la base de datos en base a un filtro
        /// </summary>
        /// <param name="predicate">El filtro especificado</param>
        IEnumerable<T> Filter(Expression<Func<T, bool>> filter);

        
        /// <summary>
        /// Obtiene objetos de la base de datos filtrando y paginando
        /// </summary>
        /// <typeparam name="Key"></typeparam>
        /// <param name="filter">Filtro especificado</param>
        /// <param name="total">Devuelve el total de elementos encontrados que cumplan con el filtro</param>
        /// <param name="index">El índice de la página</param>
        /// <param name="size">El tamaño de página</param>
        IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);

        /// <summary>
        /// Devuelve si el objeto existe en la base de datos
        /// </summary>
        /// <param name="predicate">Filtro especificado</param>
        bool Contains(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Obtiene objetos por claves
        /// </summary>
        /// <param name="keys">Las claves para la búsqueda</param>
        T Find(BsonValue key);

        /// <summary>
        /// Encuentra un objeto por la expresión indicada
        /// </summary>
        /// <param name="predicate"></param>
        T Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Crea un nuevo objeto en la base de datos
        /// </summary>
        /// <param name="t">Nuevo objeto a crear</param>
        bool Create(T t);

        /// <summary>
        /// Borra un objeto de la base de datos
        /// </summary>
        /// <param name="t">Objeto a borrar</param>
        bool Delete(BsonValue key);

        /// <summary>
        /// Actualiza los cambios del objetos en la base de datos
        /// </summary>
        /// <param name="t">Objeto a actualizar</param>
        bool Update(T t);

        /// <summary>
        /// Obtiene el número total de objetos
        /// </summary>
        int Count { get; }
         
    }
}
