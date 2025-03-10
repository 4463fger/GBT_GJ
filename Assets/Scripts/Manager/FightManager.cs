using Config;
using JKFrame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : SingletonMono<FightManager>
{
    private MapConfig mapConfig;
    private LevelConfig levelConfig;
    private TowerConfig[] towerConfigList;
    private int coin;

    protected override void Awake()
    {
        base.Awake();

    }

    public bool isCanBuyTower(int towerCoin)
    {
        return towerCoin > coin ? false : true;
    }
}
