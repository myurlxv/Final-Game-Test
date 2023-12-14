// StageController.cs 파일

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ninez.Stage;
using Ninez.Board; // 수정: Board 네임스페이스 추가

namespace Ninez.Stage
{
    public class Block
    {
        private BlockType m_BlockType;

        public Block(BlockType blockType)
        {
            m_BlockType = blockType;
        }
    }

    public class StageController : MonoBehaviour
    {
        [SerializeField] Transform m_Container;
        [SerializeField] GameObject m_CellPrefab;
        [SerializeField] GameObject m_BlockPrefab;

        private Ninez.Board.Board m_Board; // 수정: Stage를 직접 사용하는 대신에 Board를 사용

        void Start()
        {
            BuildStage();
        }

        void BuildStage()
        {
            // 1. Board를 생성한다.
            m_Board = new Ninez.Board.Board(9, 9);

            // 2. 생성한 Board 정보를 이용하여 씬을 구성한다.
            m_Board.ComposeStage(m_CellPrefab, m_BlockPrefab, m_Container);
        }
    }
}
