using JKFrame;
using System.Collections.Generic;
using UnityEngine;

public class TalentTreeManager:SingletonMono<TalentTreeManager>
{
    public TalentConfig talentConfig;
    public List<TalentDataConfig> talentDataConfigs=new List<TalentDataConfig>();
    private int curreLevelTalentPoints;
    public Sprite talentsPointIcon;
    public int GetPoints(int level)
    {
        int a=UnityEngine.Random.Range(0, 5);
        curreLevelTalentPoints = a*level;
        return curreLevelTalentPoints;
    }
}