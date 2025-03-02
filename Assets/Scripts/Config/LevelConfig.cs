using System;
using System.Collections.Generic;
using JKFrame;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/LevelConfig")]
    public class LevelConfig : ConfigBase
    {
        [SerializeField]
        public List<EnemyWaveGroup> EnemyWaveGroups = new List<EnemyWaveGroup>();
    }

#region  怪物生成配置(波次系统)
    [Serializable]
    public class EnemyWaveGroup
    {
        public string Name;
        [TextArea] public string Description = string.Empty;
        [SerializeField]
        public List<EnemyWave> Waves = new();
    }
    
    [Serializable]
    public class EnemyWave
    {
        [Tooltip("波次开始前等待时间（秒）")]
        [Range(0, 60)]
        public float PreWaveDelay = 5f;
        
        public string Name;
        public float GenerateDuration = 1;
        public GameObject EnemyPrefab;
        public int seconds = 10; // 默认一波持续10s
    }
#endregion
    
    //TODO:防御塔的配置
    //TODO:地图配置
}