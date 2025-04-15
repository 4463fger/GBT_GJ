using UnityEngine;
using UnityEngine.Serialization;

namespace Item.Map
{
    /// <summary>
    /// 单元格子
    /// </summary>
    public enum BlockType
    {
        Placedable,    // 空 => 可交互
        Obstacle,// 障碍物 => 不可交互(需要先打掉)
        Road,    // 路 => 不可交互
        Threshold,//起点 => 不可交互
        Destination //终点=> 不可交互
    }
    public class Block : MonoBehaviour
    {
        public int RowIndex; // 行坐标
        public int ColIndex; // 列坐标
        public BlockType Type; // 网格类型
        private SpriteRenderer selectSp; // 格子被选中的图片
        public bool isCanUsed;//是否可以放置

        private void Awake()
        {
            selectSp = transform.Find("select").GetComponent<SpriteRenderer>();
        }

        private void OnMouseEnter()
        {
            if(Type == BlockType.Placedable) 
            {
                selectSp.enabled = true;
            }
            
        }

        private void OnMouseDown()
        {
            if(Type==BlockType.Placedable)
            {
                //TODO:打开背包界面UI
                //输出参数
            }
        }

        private void OnMouseExit()
        {
            selectSp.enabled = false;
        }
    }
}