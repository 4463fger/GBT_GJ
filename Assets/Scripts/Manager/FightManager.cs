using Config;
using JKFrame;
using Map;
using System.Collections.Generic;
using Game;
using Game.Enemy;
using UnityEngine;

public class FightManager : SingletonMono<FightManager>
{
<<<<<<< HEAD
    /// <summary>
    /// 关卡配置
    /// </summary>
    public LevelConfig levelConfig;

    /// <summary>
    /// 零点位置
    /// </summary>
=======
>>>>>>> f956f87c1b9fee9c725eb975b6c2cfc9196d19c3
    public Vector2 InitPos = new Vector2(-8.5f, -3.5f);

    /// <summary>
    /// 网格预制体
    /// </summary>
    [SerializeField] private GameObject Grid;

    /// <summary>
    /// Key:网格坐标 Value：网格所在坐标
    /// </summary>
    public Dictionary<Vector3,Vector3> GridDic=new Dictionary<Vector3,Vector3>();

<<<<<<< HEAD
    /// <summary>
    /// 关卡配置中的塔
    /// </summary>
=======
    // 鎬墿
    public Transform EnemySpawnRoot;
    private EnemyGenerate EnemyGenerate;
    
    // Config
    private WaveConfig _waveConfig;
>>>>>>> f956f87c1b9fee9c725eb975b6c2cfc9196d19c3
    public List<TowerConfig> towerConfigList
    {
        get;
        private set;
    }

    /// <summary>
    /// 关卡内的硬币
    /// </summary>
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

    #region 鍒濆鍖�
    
    public void InitFightManager(int level)
    {
        // 鍔犺浇level鍏崇殑閰嶇疆
        _waveConfig = GameApp.Instance.DataManager.ConfigData.LoadConfig(level);
        EnemySpawnRoot.position = GameApp.Instance.DataManager.ConfigData.LoadMapConfig(level).鐢熸垚浣嶇疆;
        
        // 鍒濆鍖栧湴鍥�
        InitMap(level);
        // 鍒濆鍖栫綉鏍�
        // 鍒濆鍖栭槻寰″
        towerConfigList = _waveConfig.towerConfigs;
        InitEnemyGenerate();
    }
    
    // public void InitBlock(int width,int height)
    // {
    //     float x = InitPos.x;
    //     float y = InitPos.y;
    //     for(int i = 0;i<width;i++) 
    //     {
    //         for(int j = 0;j<height;j++)
    //         {
    //             GameObject grid = Instantiate(Grid, new Vector3(x, y, 0), Quaternion.identity);
    //             Block block = grid.GetComponent<Block>();
    //             block.RowIndex = i;
    //             block.ColIndex = j;
    //             GridDic.Add(grid.transform.position,new Vector3(i, j, 0));
    //             x++;
    //         }
    //         y++;
    //         x = InitPos.x;
    //     }
    // }

    public void InitMap(int level)
    {
<<<<<<< HEAD
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
                GridDic.Add(new Vector3(i, j, 0),grid.transform.position);
                x++;
            }
            y++;
            x = InitPos.x;
        }
    }

    /// <summary>
    /// 指定坐标转网格
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public Vector2 getCoordinates(Vector2 pos)
    {
        int x=(int)Mathf.Round(pos.x-InitPos.x);
        int y=(int)Mathf.Round(pos.y-InitPos.y);
        return new Vector2(x,y);
    }

    public Vector2 getGridCoordinates(Vector2 pos)
    {
        Vector3 currentPos = (Vector3)pos;
        if (GridDic.TryGetValue(currentPos, out Vector3 grid))
            return (Vector2)grid;
        return Vector2.zero;
    }
=======
        GameApp.Instance.MapManager.Init(level);
    }
    
    private void InitEnemyGenerate()
    {
        EnemyGenerate.Init(_waveConfig);
        EnemyGenerate.SetGeneratePos(EnemySpawnRoot);
        EnemyGenerate.StartFight(true);
    }
    
    #endregion
    
>>>>>>> f956f87c1b9fee9c725eb975b6c2cfc9196d19c3
    public bool isCanBuyTower(int towerCoin)
    {
        return towerCoin > coin ? false : true;
    }
}
