using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

    #region 연결 리스트 구현 연습
    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null; // 첫번째
        public MyLinkedListNode<T> Tail = null; // 마지막
        public int Count = 0;

        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            // 만약에 아직 방이 아예 없었다면, 새로 추가한 첫번째 방이 곧 Head 이다
            if (Head == null)
            {
                Head = newRoom;
            }

            // 기존의 [마지막방] 과 [새로 추가되는 방]을 연결해준다.
            if (Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            // [새로 추가되는 방]을 [마지막 방]으로 인정한다 
            Tail = newRoom;
            Count++;
            return newRoom;
        }

        public void Remove(MyLinkedListNode<T> room)
        {
            // [기존의 첫번째 방 다음 방] 을 [첫번째 방으로] 인정한다.
            if (Head == room)
            {
                Head = Head.Next;
            }

            // [기존의 마지막 방의 이전 방] 을 [마지막 방으로] 인정한다
            if (Tail == room)
            {
                Tail = Tail.Prev;
            }

            if (room.Prev != null)
            {
                room.Prev.Next = room.Next;
            }

            if (room.Next != null)
            {
                room.Next.Prev = room.Prev;
            }

            Count--;
        }
    }
    #endregion

    class Board
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] _tile; // 배열
        public int _size;

        public enum TileType
        {
            Empty,
            Wall,
        }

        /// <summary>
        /// int 형 size 를 받아 그 값만큼 맵을 생성
        /// </summary>
        /// <param name="size"></param>
        public void Initialize(int size)
        {
            if (size % 2 == 0)
            {
                return;
            }
            _tile = new TileType[size, size];
            _size = size;

            GenetateByBinaryTree();
        }
        /// <summary>
        /// Render 를 위한 기능
        /// </summary>
        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    Console.ForegroundColor =  GetTileColor(_tile[y, x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = prevColor;
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }

        /// <summary>
        /// Binary Tree Algorithm
        /// </summary>
        void GenetateByBinaryTree()
        {
            // 일단 길을 다 막아버리는 작업
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        _tile[y, x] = TileType.Wall;
                    }
                    else
                    {
                        _tile[y, x] = TileType.Empty;
                    }
                }
            }
            // 랜덤으로 우측 혹은 아래로 길을 뚫는 작업

            Random rand = new Random();

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        continue;
                    }

                    if (y == _size - 2 && x == _size - 2)
                    {
                        continue;
                    }

                    if (y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == _size - 2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        _tile[y + 1, x] = TileType.Empty;
                    }

                }
            }
        }
    }
}
// 책 : Mazes for Programmers 
