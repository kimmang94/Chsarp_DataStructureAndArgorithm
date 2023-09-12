using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alrogithm
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 30;
            const char CIRCLE = '\u25cf';

            // 시간 측정
            int lastTick = 0;

            while (true)
            {
                #region FPS
                // FPS (프레임 60프레임 OK 30이하 NO)

                // 시스템 시작 이후 경과된 ms 리턴
                int currentTick = System.Environment.TickCount;

                // 만약에 경과한 시간이 1/30초 보다 작다면 1초 = 1000ms
                if (currentTick - lastTick < WAIT_TICK)
                {
                    continue;
                }
                lastTick = currentTick;
                #endregion

                // 입력

                // 로직

                // 렌더링
                
                Console.SetCursorPosition(0, 0);

                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(CIRCLE);
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}
