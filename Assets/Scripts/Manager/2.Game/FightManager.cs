using Config;
using JKFrame;
using System.Collections.Generic;
using Enemy;
using Game;
using Managers.Map;
using UnityEngine;

namespace ManagerScene
{
    public class FightManager : SingletonMono<FightManager>
    {
        public Vector2 Destination;//该关卡的终点是哪 如果打算写双点位可以改成数组
        public int playerHp;
        // 地图
        public MapManager MapManager { get; private set; }
        [SerializeField] private GameObject Grid;

        // 怪物
        public Transform EnemySpawnRoot;        // 怪物生成根节点
        private EnemyGenerate EnemyGenerate;    // 怪物生成器

        // Config
        private WaveConfig _waveConfig;
        public List<TowerConfig> towerConfigList { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            MapManager = new();
            EnemyGenerate = new();
        }

        #region 初始化
        
        // 自身的初始化
        public void InitFightManager(int level)
        {
            // 加载level关的配置
            _waveConfig = GameApp.Instance.DataManager.ConfigData.LoadWaveConfig(level);
            EnemySpawnRoot.position = GameApp.Instance.DataManager.ConfigData.LoadMapBlockMessage(level).生成位置;

            // 初始化地图
            InitMap(level);
            // 初始化网格
            // 初始化防御塔
            towerConfigList = _waveConfig.towerConfigs;
            InitEnemyGenerate();
        }

        // 初始化地图
        private void InitMap(int level)
        {
            MapManager.Init(level);
        }

        // 初始化敌人生成
        private void InitEnemyGenerate()
        {
            EnemyGenerate.Init(_waveConfig,GameApp.Instance.DataManager.ConfigData.LoadMapBlockMessage(1));
            EnemyGenerate.SetGeneratePos(EnemySpawnRoot);
            EnemyGenerate.StartFight(true);
        }

        #endregion

        #region 反初始化

        public void UnInitFightManager()
        {
            _waveConfig = null;
            EnemySpawnRoot.position = Vector3.zero;
            MapManager.Clear();
            EnemyGenerate.UnInit();
            
            // TODO:清空防御塔道具
            PoolSystem.ClearAll();
        }

        #endregion
    }
}