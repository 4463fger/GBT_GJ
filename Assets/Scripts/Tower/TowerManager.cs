using JKFrame;
using System.Collections.Generic;
using Config;
using Item.Map;
using UnityEngine;

namespace Tower
{
    public class TowerManager : SingletonMono<TowerManager>
    {
        public List<TowerConfig> allTowerConfig = new List<TowerConfig>();

        public void CreateTower(int posX, int posY)
        {
            Vector3 Pos = new Vector3(posX, posY, 0);

        }

        public void TrySetTower()
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0; // 确保 Z 轴为 0（2D 环境）
            Collider2D hitCollider = Physics2D.OverlapPoint(mouseWorldPos);
            Block block = hitCollider.gameObject.GetComponent<Block>();
            if (block.Type == BlockType.Placedable && block.isCanUsed == true)
            {

            }
            else if (block.Type != BlockType.Placedable)
            {

            }
        }
    }
}