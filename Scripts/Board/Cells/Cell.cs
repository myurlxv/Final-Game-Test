// CustomCell.cs 파일
using UnityEngine;

namespace Ninez.Board
{
    public class CustomCell
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
                m_CellBehaviour.SetCustomCell(this);
            }
        }

        // 생성자 이름 변경
        public CustomCell(CellType cellType)
        {
            m_CellType = cellType;
        }

        // 다른 코드 생략...

        // 메서드 이름 변경
        public CustomCell InstantiateCellObject(GameObject cellPrefab, Transform containerObj)
        {
            //1. Cell 오브젝트를 생성한다.
            GameObject newObj = Object.Instantiate(cellPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            //2. 컨테이너(Board)의 차일드로 Cell을 포함시킨다.
            newObj.transform.parent = containerObj;

            //3. Cell 오브젝트에 적용된 CellBehaviour 컴포넌트를 보관한다.
            this.cellBehaviour = newObj.transform.GetComponent<CellBehaviour>();

            return this;
        }

        // 다른 코드 생략...

        // 메서드 이름 변경
        public void Move(float x, float y)
        {
            if (cellBehaviour != null)
            {
                cellBehaviour.transform.position = new Vector3(x, y);
            }
            else
            {
                Debug.LogWarning("CellBehaviour is not set. Move operation ignored.");
            }
        }
    }
}
