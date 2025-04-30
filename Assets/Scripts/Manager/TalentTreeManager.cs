using JKFrame;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Build.Pipeline;
using UnityEngine;

public class TalentTreeManager:SingletonMono<TalentTreeManager>
{
    public TalentConfig talentConfig;
    public List<TalentDataConfig> talentDataConfigs=new List<TalentDataConfig>();

}