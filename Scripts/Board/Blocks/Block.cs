namespace Ninez.Board
{
    public class Block
    {
        BlockType m_BlockType;

        public Block(BlockType blockType)
        {
            m_BlockType = blockType;
        }

        public BlockType type
        {
            get { return m_BlockType; }
            set { m_BlockType = value; }
        }
    }

    public class Cell
    {
        CellType m_CellType;  // 추가된 부분

        // 수정된 생성자
        public Cell(CellType cellType)
        {
            m_CellType = cellType;
        }

        public CellType type
        {
            get { return m_CellType; }
            set { m_CellType = value; }
        }

        // 기존 코드는 그대로 유지됨

        public Cell SpawnCellForStage(int nRow, int nCol)
        {
            return new Cell(nRow == nCol ? CellType.EMPTY : CellType.BASIC);
        }
    }
}

namespace Ninez.Board.Cells
{
    public class Block
    {
        public string type { get; set; }

        // 다른 멤버들...
    }
}

