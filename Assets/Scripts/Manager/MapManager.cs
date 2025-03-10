using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Map
{
    /// <summary>
    /// 管理格子的信息
    /// </summary>
    public class MapManager
    {
        private Tilemap m_TileMap; // 地图背景
        private Tilemap m_PathMap; // 地图路径
        
        private Block[,] m_Blocks;

        public int RowCount; // 地图行
        public int ColCount; // 地图列

        public MapManager()
        {
            // Test : Init();
        }
        /// <summary>
        /// 进入关卡时对Map进行初始化
        /// </summary>
        public void Init()
        {
            m_TileMap = GameObject.Find("Grid/ground").GetComponent<Tilemap>();
            m_PathMap = GameObject.Find("Grid/road").GetComponent<Tilemap>();
            
            //地图大小 => 生成网格
            RowCount = 10;
            ColCount = 18;
            m_Blocks = new Block[RowCount, ColCount];
            
            // 存储Tile位置
            List<Vector3Int> tempPos = new List<Vector3Int>();
            
            // [1] : 获取地图背景所有Tile位置
            foreach (var pos in m_TileMap.cellBounds.allPositionsWithin)
            {
                if (m_TileMap.GetTile(pos) != null)
                {
                    tempPos.Add(pos);
                }
            }
            // [2] : 获取地图路径所有Tile位置
            foreach (var pos in m_PathMap.cellBounds.allPositionsWithin)
            {
                if (m_PathMap.GetTile(pos) != null)
                {
                    tempPos.Add(pos);
                }
            }
            
            // [3] : 按照坐标排序
           tempPos.Sort((a, b) =>
           {
               //if (a.y != b.y) return b.y - a.y; // 按行优先降序排列（假设y轴向上为正）
               if (a.y != b.y) return a.y - b.y;
               return a.x - b.x; // 同一行按列升序排列
           });
            
            for(int i=0; i<tempPos.Count; i++)
            {
                Debug.Log(tempPos[i]);
            }    

            // [4] : 将临时数组位置信息转换为二维数组的Block进行存储
            Object prefabObj = JKFrame.ResSystem.LoadAsset<Object>("Prefabs/Model/block");
            for (int i = 0; i < tempPos.Count; i++)
            {
                int row = i / ColCount;
                int col = i % ColCount;
                
                Block b = (Object.Instantiate(prefabObj) as GameObject).AddComponent<Block>();
                
                b.RowIndex = row;
                b.ColIndex = col;
                // 将瓦片地图坐标转换为世界坐标
                b.transform.position = m_TileMap.CellToWorld(tempPos[i]) + new Vector3(0.5f,0.5f,0);
                
                // 根据Tilemap设置Block类型
                if (m_TileMap.GetTile(tempPos[i]) != null)
                {
                    b.Type = BlockType.Placedable; // m_TileMap生成的格子是Null
                }
                else if (m_PathMap.GetTile(tempPos[i]) != null)
                {
                    b.Type = BlockType.Road; // m_PathMap生成的格子是Road
                }
                m_Blocks[row, col] = b; // 将Block存储到二维数组中
            }
        }
        
        public void Clear()
        {
            m_Blocks = null;
        }
    }
}