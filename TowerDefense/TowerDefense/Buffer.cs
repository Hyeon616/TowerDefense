using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBuffer
{
    internal class MapBuffer
    {


        public char[,] Buffer => backBuffer;

        // 지정한 크기의 범위가 넘쳤는지 판단하는 메서드.
        private bool IsRangeOut(int inX, int inY)
        {
            if ((inX >= width || inY >= height) || (inX < 0 || inY < 0))
                return true;

            return false;
        }

        // 문자를 백버퍼에 쓰는 메서드.
        public void Draw(char inChar, int inX, int inY)
        {
            if (!IsRangeOut(inX, inY))
                backBuffer[inY, inX] = inChar;
        }

        // 문자열을 문자배열로 만들어 해당 위치에 인덱스마다 쓰는 메서드.
        public void Draw(string inStr, int inX, int inY)
        {
            char[] temp = inStr.ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                if (!IsRangeOut(inX, inY))
                    backBuffer[inY, inX + i] = temp[i];
            }
        }

        // 백버퍼를 프론트버퍼에 복사하는 메서드.
        // Array.Copy메서드를 통해 같은 타입의 배열이기 때문에
        // boxing이 일어날 걱정없이 복사가 된다.
        private void BufferExtraction()
        {
            Array.Copy(backBuffer, frontBuffer, width * height);
        }

        // 백버퍼를 비우는 메서드.
        public void ClearBuffer()
        {
            Array.Clear(backBuffer, 0, width * height);
        }

        // 프론트버퍼를 출력하는 메서드.
        private void Print()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(frontBuffer[y, x]);
                }
                Console.WriteLine();
            }
        }

        // 화면에 보여주기위한 메서드.
        public void Show()
        {
            BufferExtraction();
            Console.SetCursorPosition(0, 0);
            Print();
        }


    }
}
