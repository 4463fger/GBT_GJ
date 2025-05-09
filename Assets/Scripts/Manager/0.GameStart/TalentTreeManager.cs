using JKFrame;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

namespace TalentTree
{
    public class TalentTreeManager : SingletonMono<TalentTreeManager>
    {
        [Tooltip("天赋配置")]
        [SerializeField] private TalentConfig talentConfig;

        public TalentConfig TalentConfig => talentConfig;

        /// <summary>
        /// 存储天赋的容器
        /// Key :   天赋名字
        /// Value : 是否解锁
        /// </summary>
        private Dictionary<string, bool> m_Talent2SaveDict;
        
        private int curreLevelTalentPoints;
        public Sprite talentsPointIcon;
        
        private string SavePath => Path.Combine(Application.persistentDataPath, "talent_save.json");

        protected override void Awake()
        {
            base.Awake();
            Init();
        }

        private void Init()
        {
            LoadData();
            //Todo:将解锁的显示，更新到UI
        }

        public int GetPoints(int level)
        {
            int a = UnityEngine.Random.Range(0, 5);
            curreLevelTalentPoints = a * level;
            return curreLevelTalentPoints;
        }
        
        //TODO : 解锁天赋
        private void UnLockedTalent()
        {
            // TODO:解锁某个天赋 ，到游戏数据中
            // TODO:更新UI
            SaveData();
        }

        // 保存配置
        public void SaveData()
        {
            string dataJson = JsonConvert.SerializeObject(m_Talent2SaveDict,Formatting.Indented);
            IOTool.SaveJson(dataJson,SavePath);
        }
        
        public void LoadData() 
        {
            // 没有天赋配置，就写入默认数据
            if (!File.Exists(SavePath))
            {
#if UNITY_EDITOR
                Debug.LogWarning("天赋存档文件不存在，初始化");
#endif
                m_Talent2SaveDict = new();
                foreach (var t in talentConfig.talantDatas)
                {
                    // 默认false 未解锁
                    m_Talent2SaveDict.Add(t.talentName,false);
                }
                // 序列化存储字典
                SaveData();
            }
            else // 如果有,就读取
            {
                string loadJson = File.ReadAllText(SavePath);

                m_Talent2SaveDict = JsonConvert.DeserializeObject<Dictionary<string, bool>>(loadJson);
#if UNITY_EDITOR
                JKLog.Succeed("天赋数据加载成功");
#endif
            }
        }
    }
}