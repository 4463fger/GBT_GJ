using System.Collections.Generic;
using System.IO;
using Common;
using Game;
using JKFrame;
using Newtonsoft.Json;
using UI.GameStart;
using UnityEngine;

namespace Achievement
{
    /// <summary>
    /// 成就系统
    /// </summary>
    public class AchievementSystem : ISavable
    {
        private AchievementConfig _config;
        /// <summary>
        /// 存储天赋的容器
        /// Key :   天赋Id
        /// Value : 是否解锁
        /// </summary>
        private Dictionary<string, bool> m_Achievement2SaveDict;
        
        private string SavePath => Path.Combine(Application.persistentDataPath, "achievement_save.json");
        
        public void Init()
        {
            _config = GameApp.Instance.DataManager.ConfigData.LoadAchievementConfig();

            LoadData();
        }

        public void SaveData()
        {
            string dataJson = JsonConvert.SerializeObject(m_Achievement2SaveDict,Formatting.Indented);
            IOTool.SaveJson(dataJson,SavePath);
        }

        public void LoadData() 
        {
            // 没有成就存档，就写入默认数据
            if (!File.Exists(SavePath))
            {
#if UNITY_EDITOR
                JKLog.Warning("成就文件不存在，初始化");
#endif
                m_Achievement2SaveDict = new();
                foreach (var t in _config.achievements)
                {
                    // 默认false 未解锁
                    m_Achievement2SaveDict.Add(t.id,false);
                }
                // 序列化存储字典
                SaveData();
            }
            else // 如果有,就读取
            {
                string loadJson = File.ReadAllText(SavePath);

                m_Achievement2SaveDict = JsonConvert.DeserializeObject<Dictionary<string, bool>>(loadJson);
#if UNITY_EDITOR
                JKLog.Succeed("成就数据加载成功");
#endif
            }
        }

        public bool IsUnLocked(AchievementData achievementData)
        {
            return m_Achievement2SaveDict[achievementData.id];
        }
        
        public bool IsUnLocked(UI_AchievementItem item)
        {
            return m_Achievement2SaveDict[item.Id];
        }
    }
}