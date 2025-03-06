using UnityEngine;

namespace Map
{
    /// <summary>
    /// 单元格子
    /// </summary>
    public enum BlockType
    {
        Null,    // 空 => 可交互
        Obstacle,// 障碍物 => 不可交互(需要先打掉)
        Road,    // 路 => 不可交互
    }
    public class Block : MonoBehaviour
    {
        public int RowIndex; // 行坐标
        public int ColIndex; // 列坐标
        public BlockType Type; // 网格类型
        
        private SpriteRenderer selectSp; // 格子被选中的图片

        private void Awake()
        {
            selectSp = transform.Find("select").GetComponent<SpriteRenderer>();
        }

        private void OnMouseEnter()
        {
            selectSp.enabled = true;
        }

        private void OnMouseExit()
        {
            selectSp.enabled = false;
        }
    }
}