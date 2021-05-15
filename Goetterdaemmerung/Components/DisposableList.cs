using System.Collections.Generic;
using System.Drawing;
using Project_Goettergaemmerung.Components.Model;
using System;
using System.Collections;

namespace Project_Goettergaemmerung.Components
{
    public interface IDisposableList<T> where T : IDisposable
    {
        void Add(Func<T> action);

        void Dispose();

        IEnumerator<T> GetEnumerator();
    }

    public class DisposableList<T> : IDisposable, IEnumerable<T>, IDisposableList<T> where T : IDisposable
    {
        private readonly List<T> _list = new List<T>();

        public void Add(Func<T> action)
        {
            _list.Add(action.Invoke());
        }

        public void AddSingle(T bitmap)
        {
            _list.Add(bitmap);

        }

        public void Dispose()
        {
            foreach (var item in _list) item?.Dispose();
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
}
