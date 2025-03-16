using Config;
using JKFrame;
using Map;
using System.Collections.Generic;
using Game;
using Game.Enemy;
using UnityEngine;

public class FightManager : SingletonMono<FightManager>
{
    public Vector2 InitPos = new Vector2(-8.5f, -3.5f);
    [SerializeField] private GameObject Grid;
    public Dictionary<Vector3,Vector3> GridDic=new Dictionary<Vector3,Vector3>();

    public Transform EnemySpawnRoot;
    private EnemyGenerate EnemyGenerate;
    private LevelConfig levelConfig;
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
        
        EnemyGenerate = new();
    }

    #region 初始化
    
    public void InitFightManager(int level)
    {
        // 加载level关的配置
        levelConfig = GameApp.Instance.DataManager.ConfigData.LoadConfig(level);
        
        // 初始化地图
        // 初始化网格
        // 初始化防御塔
        towerConfigList = levelConfig.towerConfigs;
        InitEnemyGenerate();
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
    
    private void InitEnemyGenerate()
    {
        EnemyGenerate.Init(levelConfig);
        //TODO:处理怪物生成位置逻辑
        EnemyGenerate.SetGeneratePos(gameObject.transform);
        EnemyGenerate.StartFight(true);
    }
    
    #endregion
    
    public bool isCanBuyTower(int towerCoin)
    {
        return towerCoin > coin ? false : true;
    }
}
