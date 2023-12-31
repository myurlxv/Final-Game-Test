// Board.cs 파일

using UnityEngine;

namespace Ninez.Board
{
    public class Board
    {
        int m_nRow;
        int m_nCol;

        CustomCell[,] m_Cells; // 수정: Cell을 CustomCell로 변경
        public CustomCell[,] cells { get { return m_Cells; } }

        Block[,] m_Blocks;
        public Block[,] blocks { get { return m_Blocks; } }

        Transform m_Container;
        GameObject m_CellPrefab;
        GameObject m_BlockPrefab;

        public Board(int nRow, int nCol)
        {
            m_nRow = nRow;
            m_nCol = nCol;

            m_Cells = new CustomCell[nRow, nCol]; // 수정: Cell을 CustomCell로 변경
            m_Blocks = new Block[nRow, nCol];
        }

        public int maxRow { get { return m_nRow; } }
        public int maxCol { get { return m_nCol; } }

        internal void ComposeStage(GameObject cellPrefab, GameObject blockPrefab, Transform container)
        {
            //1. 스테이지 구성에 필요한 Cell,Block, Container(Board) 정보를 저장한다.
            m_CellPrefab = cellPrefab;
            m_BlockPrefab = blockPrefab;
            m_Container = container;

            //2. Cell, Block Prefab을 이용해서 Board에 Cell/Block GameObject를 추가한다.
            float initX = CalcInitX(0.5f);
            float initY = CalcInitY(0.5f);

            for (int nRow = 0; nRow < m_nRow; nRow++)
                for (int nCol = 0; nCol < m_nCol; nCol++)
                {
                    CustomCell cell = m_Cells[nRow, nCol]?.InstantiateCellObject(cellPrefab, container); // 수정: InstantiateCellObj를 InstantiateCellObject로 변경
                    cell?.Move(initX + nCol, initY + nRow);
                }
        }

        public float CalcInitX(float offset = 0)
        {
            return -m_nCol / 2.0f + offset;
        }

        public float CalcInitY(float offset = 0)
        {
            return -m_nRow / 2.0f + offset;
        }
    }
}
