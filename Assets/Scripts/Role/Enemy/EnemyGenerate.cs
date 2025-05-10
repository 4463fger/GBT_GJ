using System.Collections.Generic;
using Config;
using Game;
using JKFrame;
using UnityEngine;

namespace Enemy
{
    public class EnemyGenerate
    {
        // 波次配置用于生成怪物
        private WaveConfig _mCurrentWaveConfig;
        private BlockMessage _blockMessage;
        
        private float m_CurrentGenerateSeconds = 0;
        private float m_CurrentWaveSeconds = 0;

        private float m_WaitTime;

        // 怪物总数
        private int m_TotalCount = 0;

        // 波次总数
        private int WaveCount = 0;

        // 怪物队列
        private Queue<EnemyWave> m_EnemyWavesQueue = new();
        private EnemyWave m_currentWave; // 当前波次

        private Transform spawnPos;
        private bool isFight = false;

        public void StartFight(bool isFight)
        {
            this.isFight = isFight;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="waveConfig">波次配置</param>
        /// <param name="_blockMessage">地图的配置</param>
        public void Init(WaveConfig waveConfig,BlockMessage _blockMessage)
        {
            this._mCurrentWaveConfig = waveConfig;
            this._blockMessage = _blockMessage;
            
            foreach (var group in _mCurrentWaveConfig.EnemyWaveGroups)
            {
                foreach (var wave in group.Waves)
                {
                    m_EnemyWavesQueue.Enqueue(wave);
                    m_TotalCount++;
                }
            }
            JKFrame.MonoSystem.AddUpdateListener(OnUpdate);
        }

        public void UnInit()
        {
            JKFrame.MonoSystem.RemoveUpdateListener(OnUpdate);
        }

        private void OnUpdate()
        {
            if (isFight == false)
                return;
            
            // 波次为null，并且还有怪,就切换到下一波
            if (m_currentWave == null)
            {
                if (m_EnemyWavesQueue.Count > 0)
                {
                    // 波次数+1
                    WaveCount++;
                    // 更新UI ： 
                    EventSystem.EventTrigger<float,float>(Defines.WaveCountChange,WaveCount,m_TotalCount);
                    m_currentWave = m_EnemyWavesQueue.Dequeue();
                    m_CurrentGenerateSeconds = 0;
                    m_CurrentWaveSeconds = 0;
                    m_WaitTime = 0;
                }
            }

            // 不为空 => 生成
            if (m_currentWave != null)
            {
                // 等待2s
                if (m_WaitTime <= m_currentWave.PreWaveDelay)
                {
                    m_WaitTime += Time.deltaTime;
                    return;
                }

                m_CurrentGenerateSeconds += Time.deltaTime;
                m_CurrentWaveSeconds += Time.deltaTime;

                if (m_CurrentGenerateSeconds >= m_currentWave.GenerateDuration)
                {
                    m_CurrentGenerateSeconds = 0;

                    //TODO:生成怪物的一个小bug未修复
                    switch (m_currentWave.EnemyType)
                    {
                        case EnemyType.Goblin:
                            Goblin goblin = GameApp.Instance.FactoryManager.CreateEnemy<Goblin>(m_currentWave.EnemyType);
                            goblin.transform.position = spawnPos.position;
                            goblin.Init(_blockMessage.Road[m_currentWave.road],spawnPos);
                            break;
                        case EnemyType.RollGlobin:
                            RollGoblin rollGoblin = GameApp.Instance.FactoryManager.CreateEnemy<RollGoblin>(m_currentWave.EnemyType);
                            rollGoblin.transform.position = spawnPos.position;
                            rollGoblin.Init(_blockMessage.Road[m_currentWave.road],spawnPos);
                            break;
                        case EnemyType.WaterGlobin:
                            WaterGlobin waterGlobin = GameApp.Instance.FactoryManager.CreateEnemy<WaterGlobin>(m_currentWave.EnemyType);
                            waterGlobin.transform.position = spawnPos.position;
                            waterGlobin.Init(_blockMessage.Road[m_currentWave.road],spawnPos);
                            break;
                        case EnemyType.BoxGlobin:
                            BoxGlobin boxGlobin = GameApp.Instance.FactoryManager.CreateEnemy<BoxGlobin>(m_currentWave.EnemyType);
                            boxGlobin.transform.position = spawnPos.position;
                            boxGlobin.Init(_blockMessage.Road[m_currentWave.road],spawnPos);
                            break;
                        case EnemyType.Skeleton:
                            Skeleton skeleton = GameApp.Instance.FactoryManager.CreateEnemy<Skeleton>(m_currentWave.EnemyType);
                            skeleton.transform.position = spawnPos.position;
                            skeleton.Init(_blockMessage.Road[m_currentWave.road],spawnPos);
                            break;
                        case EnemyType.Boar:
                            Boar boar = GameApp.Instance.FactoryManager.CreateEnemy<Boar>(m_currentWave.EnemyType);
                            boar.transform.position = spawnPos.position;
                            boar.Init(_blockMessage.Road[m_currentWave.road],spawnPos);
                            break;
                        case EnemyType.Slime:
                            Slime slime = GameApp.Instance.FactoryManager.CreateEnemy<Slime>(m_currentWave.EnemyType);
                            slime.transform.position = spawnPos.position;
                            slime.Init(_blockMessage.Road[m_currentWave.road],spawnPos);
                            break;
                    }
                    
                    // 判断波次是否结束
                    if (m_CurrentWaveSeconds >= m_currentWave.seconds)
                    {
                        m_currentWave = null;
                    }
                }
            }
        }

        /// <summary>
        /// 设置怪物出生点
        /// </summary>
        /// <param name="pos"></param>
        public void SetGeneratePos(Transform transform)
        {
            this.spawnPos = transform;
        }
    }
}