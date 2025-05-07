using System.Collections.Generic;
using Game;

namespace Achievement
{
    /// <summary>
    /// 成就系统
    /// </summary>
    public class AchievementSystem
    {
        private AchievementConfig _config;
        private List<AchievementData> m_achievementDatas;
        private int m_UnLockedAchievementCount; //已经解锁的成就数量 

        public void Init()
        {
            m_achievementDatas = new();
            LoadAchievement();
        }
        private void LoadAchievement()
        {
            // 加载成就配置
            _config = GameApp.Instance.DataManager.ConfigData.LoadAchievementConfig();
            // config映射到AchievementData中
            foreach (var item in _config.achievements)
            {
                m_achievementDatas.Add(item);
            }
        }
    }
}