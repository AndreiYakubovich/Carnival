namespace BLL.Interfaces
{
    public interface IBaseService<in T>
    {
        void Create(T prop);
        void Delete(int Id);
        void Edit(T prop);
    }
}