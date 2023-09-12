using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{

    class  MyList
    {

    }

    class Board
    {
        public int[] _data = new int[25]; // 배열
        public List<int> _data2 = new List<int>(); // 동적 배열 C++ 에서는 백터
        public LinkedList<int> _data3 = new LinkedList<int>(); // (이중) 연결 리스트 C++ 에서는 리스트


        public void Initialize()
        {
            _data2.Add(101);
            _data2.Add(102);
            _data2.Add(103);
            _data2.Add(104);
            _data2.Add(105);

            int temp = _data2[2];

            _data2.RemoveAt(2);
        }
    }
}
