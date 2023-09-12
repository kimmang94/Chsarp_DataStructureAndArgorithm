using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    #region 동적 배열 구현 연습
    class MyList<T>
    {
        const int DEFAUT_SIZE = 1;
        T[] _data = new T[DEFAUT_SIZE];

        public int Count = 0; // 실제 사용중인 데이터 개수
        public int Capacity { get { return _data.Length; } } // 예약된 데이터 갯수

        public void Add(T item)
        {
            // 1. 공간이 충분히 남아있는지 확인한다.
            if (Count >= Capacity)
            {
                // 공간을 다시 늘려서 확보 growth factor 정책에 의해 *2를 해준다
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = _data[i];
                }
                _data = newArray;
            }

            // 2. 공간에다가 데이터를 넣어준다.
            _data[Count] = item;
            Count++;
        }

        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }
        
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _data[Count - 1] = default(T); // T의 초기형식으로 초기화
            Count--;
        }

    }
#endregion
    class Board
    {
        public int[] _data = new int[25]; // 배열
        public List<int> _data2 = new List<int>(); // 동적 배열 C++ 에서는 백터
        public LinkedList<int> _data3 = new LinkedList<int>(); // (이중) 연결 리스트 C++ 에서는 리스트


        public void Initialize()
        {

        }
    }
}
