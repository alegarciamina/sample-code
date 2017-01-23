namespace UT.Application.Storage
{
    public interface ISessionStorage
    {
        void Add(string name, object value);
        void Remove(string name);
        object this[string name] { get; set; }
        void Clear();
        void Abandon();
    }
}
