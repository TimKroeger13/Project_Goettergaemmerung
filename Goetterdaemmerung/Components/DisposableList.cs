using System.Collections;

namespace Project_Goettergaemmerung.Components;

public interface IDisposableList<T> where T : IDisposable
{
    void Add(Func<T> action);

    void Dispose();

    IEnumerator<T> GetEnumerator();
}

public class DisposableList<T> : IDisposable, IEnumerable<T>, IDisposableList<T> where T : IDisposable
{
    private readonly List<T> _list = new();

    public void Add(Func<T> action)
    {
        _list.Add(action.Invoke());
    }

    public void Dispose()
    {
        foreach (var item in _list) item?.Dispose();
        GC.SuppressFinalize(this);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list.GetEnumerator();
    }
}
