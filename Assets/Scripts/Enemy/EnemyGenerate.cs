using System;
using System.Collections.Generic;
using Config;
using JKFrame;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyGenerate : MonoBehaviour
    {
        // 这里构想为每个场景都有一个EnemyGenerate,挂在不同的LevelConfig
        [SerializeField] private LevelConfig m_currentLevelConfig;

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

        private void Start()
        {
            foreach (var group in m_currentLevelConfig.EnemyWaveGroups)
            {
                foreach (var wave in group.Waves)
                {
                    m_EnemyWavesQueue.Enqueue(wave);
                    m_TotalCount++;
                }
            }
        }

        private void Update()
        {
            // 波次为null，并且还有怪,就切换到下一波
            if (m_currentWave == null)
            {
                if (m_EnemyWavesQueue.Count > 0)
                {
                    // 波次数+1
                    WaveCount++;
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

                    //TODO:生成怪物
                    IEnemy go = GameApp.Instance.FactoryManager.CreateEnemy(m_currentWave.EnemyType);

                    // 判断波次是否结束
                    if (m_CurrentWaveSeconds >= m_currentWave.seconds)
                    {
                        m_currentWave = null;
                    }
                }
            }
        }
    }
}