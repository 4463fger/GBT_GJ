using Config;
using JKFrame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FightManager : SingletonMono<FightManager>
{
    public LevelConfig levelConfig;
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

    public bool isCanBuyTower(int towerCoin)
    {
        return towerCoin > coin ? false : true;
    }
}
