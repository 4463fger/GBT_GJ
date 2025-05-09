using JKFrame;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
namespace TalentTree
{
    public class TalentTreeManager : SingletonMono<TalentTreeManager>
    {
        public List<TalentDataConfig> allTalentsConfig= new List<TalentDataConfig>();
        public Dictionary<string,TalentDataConfig> allTalentsConfigs=new Dictionary<string,TalentDataConfig>();
        public TalentConfig talentConfig;
        public List<TalentDataConfig> talentDataConfigs = new List<TalentDataConfig>();
        private int curreLevelTalentPoints;
        public Sprite talentsPointIcon;
        private string SavePath => Path.Combine(Application.persistentDataPath, "talent_save.json");
        
        public void InitDic()
        {

        }
        public int GetPoints(int level)
        {
            int a = UnityEngine.Random.Range(0, 5);
            curreLevelTalentPoints = a * level;
            return curreLevelTalentPoints;
        }
        public void SaveData()
        {
            List<string> stringList=new List<string>();
            for(int i = 0; i < talentDataConfigs.Count; i++) 
            {
                stringList.Add(talentDataConfigs[i].talentName);
            }
        }
        public void LoadData() 
        {
            
        }
    }
}