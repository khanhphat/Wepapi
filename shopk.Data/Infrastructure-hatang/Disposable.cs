using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Data.Infrastructure_hatang
{
    //ke thu tu IDisposable
    //Những lớp nào kế thưa từ nó sẽ tự động hủy (cài đặt các phương thức)
    public class Disposable : IDisposable
    {
        private bool isDisposed;

        //Khi hủy đối tượng dispose. nó sẽ ko dispose
        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);//gọi GC. để thu hồi bộ nhớ
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();   
            }
            isDisposed = true;
        }
        //Ovveride this to dispose custom objects
        protected virtual void DisposeCore() { }
    }
}
