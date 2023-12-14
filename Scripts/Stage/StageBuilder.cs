// StageBuilder.cs 파일

using UnityEngine;

namespace Ninez.Stage
{
    // Enums.cs 파일에 정의된 네임스페이스와 같은 네임스페이스 사용
    public class Cell
    {
        protected CellType m_CellType;
        public CellType type
        {
            get { return m_CellType; }
            set { m_CellType = value; }
        }

        protected CellBehaviour m_CellBehaviour;
        public CellBehaviour cellBehaviour
        {
            get { return m_CellBehaviour; }
            set
            {
                m_CellBehaviour = value;
                m_CellBehaviour.SetCell(this);
            }
        }

        public Cell(CellType cellType)
        {
            m_CellType = cellType;
        }

        public Cell InstantiateCellObj(GameObject cellPrefab, Transform containerObj)
        {
            //1. Cell 오브젝트를 생성한다.
            GameObject newObj = Object.Instantiate(cellPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            //2. 컨테이너(Board)의 차일드로 Cell을 포함시킨다.
            newObj.transform.parent = containerObj;

            //3. Cell 오브젝트에 적용된 CellBehaviour 컴포넌트를 보관한다.
            this.cellBehaviour = newObj.transform.GetComponent<CellBehaviour>();

            return this;
        }

        public void Move(float x, float y)
        {
            cellBehaviour.transform.position = new Vector3(x, y);
        }
    }

    public class CellBehaviour : MonoBehaviour
    {
        Cell m_Cell;
        SpriteRenderer m_SpriteRenderer;

        void Start()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();

            UpdateView(false);
        }

        public void SetCell(Cell cell)
        {
            m_Cell = cell;
        }

        public void UpdateView(bool bValueChanged)
        {
            if (m_Cell.type == CellType.EMPTY)
            {
                m_SpriteRenderer.sprite = null;
            }
        }
    }

    public static class StageBuilder
    {
        public class Stage
        {
            // Stage 클래스 내용은 필요에 따라 추가
        }

        public static Stage BuildStage(int nStage, int row, int col)
        {
            // 여기에 Stage를 구성하는 코드를 추가하세요.
            // 예를 들어, Stage 클래스의 인스턴스를 생성하고 반환할 수 있습니다.
            return new Stage(); // 예시로 빈 Stage 클래스의 인스턴스를 반환하도록 수정
        }
    }
}
