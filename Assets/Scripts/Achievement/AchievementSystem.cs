using System.Collections.Generic;
using System.IO;
using Game;
using UnityEngine;

namespace Achievement
{
    /// <summary>
    /// 成就系统
    /// </summary>
    public class AchievementSystem
    {
        private AchievementConfig _config;
        private Dictionary<string, AchievementData> _achievementDict = new();
        private List<AchievementRuntimeData> _runtimeData = new();
        
        private string SavePath => Path.Combine(Application.persistentDataPath, "achievement_save.json");
        
        public void Init()
        {
            _achievementDict = new();
            LoadAchievement();
            // 加载成就进度
            LoadProgress();
        }

        private void LoadAchievement()
        {
            // 加载成就配置
            _config = GameApp.Instance.DataManager.ConfigData.LoadAchievementConfig();
            // config映射到AchievementData中
            foreach (var data in _config.achievements)
            {
                _achievementDict.Add(data.id,data);
            }
        }
        
        private void LoadProgress()
        {
            if (File.Exists(SavePath))
            {
                string json = File.ReadAllText(SavePath);
            }
        }
    }
}