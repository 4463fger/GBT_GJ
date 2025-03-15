using Config;
using JKFrame;
using Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FightManager : SingletonMono<FightManager>
{
    public LevelConfig levelConfig;
    public Vector2 InitPos = new Vector2(-8.5f, -3.5f);
    [SerializeField] private GameObject Grid;
    public Dictionary<Vector3,Vector3> GridDic=new Dictionary<Vector3,Vector3>();
    public List<TowerConfig> towerConfigList
    {
        get;
        private set;
    }
    public int coin 
    {
        get;
        private set;
    }

    protected override void Awake()
    {
        base.Awake();
        coin = 300;
    }

    public void InitFightManager(string level)
    {
        string configName = level +"EnemyConfig";
        levelConfig = Instantiate<LevelConfig>(Resources.Load(configName) as LevelConfig);
        towerConfigList = levelConfig.towerConfigs;
    }
    public void InitBlock(int width,int height)
    {
        float x = InitPos.x;
        float y = InitPos.y;
        for(int i = 0;i<width;i++) 
        {
            for(int j = 0;j<height;j++)
            {
                GameObject grid = Instantiate(Grid, new Vector3(x, y, 0), Quaternion.identity);
                Block block = grid.GetComponent<Block>();
                block.RowIndex = i;
                block.ColIndex = j;
                GridDic.Add(grid.transform.position,new Vector3(i, j, 0));
                x++;
            }
            y++;
            x = InitPos.x;
        }
    }
    public bool isCanBuyTower(int towerCoin)
    {
        return towerCoin > coin ? false : true;
    }
}
