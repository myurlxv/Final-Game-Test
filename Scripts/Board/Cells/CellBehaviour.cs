// CellBehaviour.cs 파일
using UnityEngine;

namespace Ninez.Board
{
    public class CellBehaviour : MonoBehaviour
    {
        CustomCell m_CustomCell;
        SpriteRenderer m_SpriteRenderer;

        void Start()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            // UpdateView 메서드를 Start에서 호출하지 않도록 수정
        }

        public void SetCustomCell(CustomCell customCell)
        {
            m_CustomCell = customCell;
            UpdateView(false); // m_CustomCell이 설정된 후에 UpdateView를 호출
        }

        public void UpdateView(bool bValueChanged)
        {
            if (m_CustomCell != null && m_CustomCell.type == CellType.EMPTY)
            {
                m_SpriteRenderer.sprite = null;
            }
            // Add additional conditions or actions based on the CustomCell's properties
        }
    }
}
