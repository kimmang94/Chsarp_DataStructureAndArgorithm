using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
 
    // 어떠한 값이던 상관없지만 값형식이여야한다.
    // 참조형식인 경우 class 사용가능
    class MyList<T> where T : struct
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
