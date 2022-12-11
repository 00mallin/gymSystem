namespace Database;

interface IDatabase<T>
{
    List<T> GetAll();
    void Insert(T item);
    void Update(T item);
    void Delete(int id);
}