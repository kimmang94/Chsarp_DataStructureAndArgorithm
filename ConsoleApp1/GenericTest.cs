using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
 
    class MyList<T>
    {
        // object 는 박싱 언박싱으로 비용이 증가한다.
        object[] arr = new object[10];
        T[] arr1 = new T[10];

        public T GetItem(int i)
        {
            return arr1[i];
        }
    }

    class GenericTest
    {
        // T 는 Type Template 의 약자로 모든 데이터 형식이 사용가능하다
        MyList<int> myIntList = new MyList<int>();
        
    }
}
