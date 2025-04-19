using System.Collections.Generic;
using Config;
using Game;
using Item.Map;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers
{
    namespace Map
    {
        /// <summary>
        /// 管理格子的信息
        /// </summary>
        public class MapManager
        {
            public MapConfig MapConfig;
            private BlockMessage _blockMessage;
            private Tilemap m_TileMap; // 地图背景
            private Tilemap m_PathMap; // 地图路径

            private Block[,] m_Blocks;

            public int RowCount; // 地图行
            public int ColCount; // 地图列

            /// <summary>
            /// 进入关卡时对Map进行初始化
            /// </summary>
            public void Init(int level)
            {
                _blockMessage = GameApp.Instance.DataManager.ConfigData.LoadMapBlockMessage(level);

                m_TileMap = GameObject.Find("Grid/ground").GetComponent<Tilemap>();
                m_PathMap = GameObject.Find("Grid/road").GetComponent<Tilemap>();

                //地图大小 => 生成网格
                RowCount = 13;
                ColCount = 20;
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


                // [4] : 将临时数组位置信息转换为二维数组的Block进行存储
                Object prefabObj = JKFrame.ResSystem.LoadAsset<Object>("Prefabs/Model/TestBlock");
                for (int i = 0; i < tempPos.Count; i++)
                {
                    int row = i / ColCount;
                    int col = i % ColCount;

                    Block b = (Object.Instantiate(prefabObj) as GameObject).AddComponent<Block>();

                    b.ColIndex = row;
                    b.RowIndex = col;
                    // 将瓦片地图坐标转换为世界坐标
                    b.transform.position = m_TileMap.CellToWorld(tempPos[i]) + new Vector3(0.5f, 0.5f, 0);

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

                SetRoadBlock();
            }

            /// <summary>
            /// 设置网格类型
            /// </summary>
            public void SetBlockType(Vector2 vector2, BlockType type)
            {
                // 3. 将Vector2坐标转换为整数行列索引
                int col = (int)vector2.x; // x轴对应行
                int row = (int)vector2.y; // y轴对应列

                // 4. 验证坐标是否在合法范围内
                if (row >= 0 && row < RowCount && col >= 0 && col < ColCount)
                {
                    // 5. 设置对应格子为Road类型
                    m_Blocks[row, col].Type = type;
                }
                else
                {
#if UNITY_EDITOR
                    Debug.LogWarning($"无效坐标: ({row},{col})");
#endif
                }
            }

            /// <summary>
            /// 获取路径点
            /// </summary>
            /// <param name="road">哪条路</param>
            private List<Vector2> LoadRoad(int road = 1)
            {
                return _blockMessage.Road[road];
            }

            public void Clear()
            {
                m_Blocks = null;
            }

            // 暂定为每个地图都有两条路
            private void SetRoadBlock()
            {
                // 1. 从配置中加载路径坐标列表
                List<Vector2> roadPath = LoadRoad();

                foreach (var roadCoord in roadPath)
                {
                    // 3. 将Vector2坐标转换为整数行列索引
                    int col = (int)roadCoord.x; // x轴对应行
                    int row = (int)roadCoord.y; // y轴对应列

                    // 4. 验证坐标是否在合法范围内
                    if (row >= 0 && row < RowCount && col >= 0 && col < ColCount)
                    {
                        // 5. 设置对应格子为Road类型
                        m_Blocks[row, col].Type = BlockType.Road;
                        return;
                    }
#if UNITY_EDITOR
                    Debug.LogWarning($"无效坐标: ({col},{row})");
#endif
                }
            }
            
            /// <summary>
            /// 根据格子坐标获取世界坐标
            /// </summary>
            /// <param name="row">行</param>
            /// <param name="col">列</param>
            /// <returns></returns>
            public Vector3 GetWorldPosition(int row, int col)
            {
                return new Vector3(row - 9.5f, col - 6.5f, 0f);
            }


            public void CreateTower(TowerConfig towerConfig,Vector2 pos)
            {
                
            }
        }
    }
}