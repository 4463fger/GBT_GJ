﻿using System;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "TowerConfig", menuName = "Config/TowerConfig")]
    [Serializable]
    public class TowerConfig : ScriptableObject
    {
        public int Coin; //所需消耗的金币   
        public string towerName; //塔的名字
        public string towerDescrption; //塔的描述
        public Sprite towerSprite; //塔的图标
        public GameObject towerPreviewPrefab; //塔的预视图预制体
        public GameObject towerPrefab; //塔的预制体
        public float attackRadius; //攻击半径
        public float attackInterval; //攻击间隔
        public float attackDamage; //攻击伤害
    }
}