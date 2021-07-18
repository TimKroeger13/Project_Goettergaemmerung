using System.Drawing;
using Project_Goettergaemmerung.Properties;
using Project_Goettergaemmerung.Components;
using System.Collections.Generic;
using System;

namespace Project_Goettergaemmerung.Components
{
    public interface IDisposeBitmaps<T> where T : IDisposable
    {
        void Dispose();

        void DisposibelArchiveList(ref T archiveBitmap);
    }

    public class DisposeBitmaps<T> : IDisposeBitmaps<T> where T : IDisposable
    {
        private readonly List<T> _list = new();

        public void DisposibelArchiveList(ref T archiveBitmap)
        {
            _list.Add(archiveBitmap);
        }

        public void Dispose()
        {
            foreach (var item in _list) item?.Dispose();
        }
    }
}
