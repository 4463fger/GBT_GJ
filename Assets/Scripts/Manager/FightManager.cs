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
    public Dictionary<Vector3, Vector3> GridDic = new Dictionary<Vector3, Vector3>();

    // ????
    public Transform EnemySpawnRoot;
    private EnemyGenerate EnemyGenerate;

    // Config
    private WaveConfig _waveConfig;
    // 地图网格信息
    private BlockMessage _blockMessage;
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

    #region ?????

    public void InitFightManager(int level)
    {
        
        _waveConfig = GameApp.Instance.DataManager.ConfigData.LoadWaveConfig(level);
        _blockMessage = GameApp.Instance.DataManager.ConfigData.LoadMapConfig(level);

        EnemySpawnRoot.position = GameApp.Instance.DataManager.ConfigData.LoadMapConfig(level).生成位置;

        // ????????
        InitMap(level);
        // ?????????
        // ???????????
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

    public Vector2 getCoordinates(Vector2 pos)
    {
        int x = (int)Mathf.Round(pos.x - InitPos.x);
        int y = (int)Mathf.Round(pos.y - InitPos.y);
        return new Vector2(x, y);
    }

    public Vector2 getGridCoordinates(Vector2 pos)
    {
        Vector3 currentPos = (Vector3)pos;
        if (GridDic.TryGetValue(currentPos, out Vector3 grid))
            return (Vector2)grid;
        return default;
    }

    public void InitMap(int level)
    {
        GameApp.Instance.MapManager.Init(level);
    }

    private void InitEnemyGenerate()
    {
        EnemyGenerate.Init(_waveConfig,_blockMessage);
        EnemyGenerate.SetGeneratePos(EnemySpawnRoot);
        EnemyGenerate.StartFight(true);
    }

    #endregion

    public bool isCanBuyTower(int towerCoin)
    {
        return towerCoin > coin ? false : true;
    }
}