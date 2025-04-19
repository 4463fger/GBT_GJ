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
        public void Init()
        {

        }
        public void CreateTower(TowerConfig towerConfig,Block block)
        {
            Vector2 pos=block.transform.position;
            GameObject tower=Instantiate(towerConfig.towerPrefab,pos,Quaternion.identity);
            block.Type = BlockType.Placedable;
            int x = block.RowIndex;
            int y = block.ColIndex;
            TowerBase towerBase = tower.GetComponent<TowerBase>();
            towerBase.SetPos(x,y);
            towerBase.InitTower(towerConfig);
            
        }
    }
}