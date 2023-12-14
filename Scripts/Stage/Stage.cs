// Stage.cs 파일

using UnityEngine;
using Ninez.Board;

namespace Ninez.Stage
{
    public class Stage
    {
        private Ninez.Board.Board m_Board;

        public Block[,] blocks { get; set; }
        public CustomCell[,] cells { get; set; }

        public int maxRow { get; private set; } // 수정: maxRow 정의
        public int maxCol { get; private set; } // 수정: maxCol 정의

        // 다른 코드 생략...

        // Stage 생성자
        public Stage(int row, int col)
        {
            maxRow = row;
            maxCol = col;

            // 'blocks' 및 'cells' 배열 초기화
            blocks = new Block[row, col];
            cells = new CustomCell[row, col];

            m_Board = new Ninez.Board.Board(row, col);
        }

        // 다른 코드 생략...

    }
}
