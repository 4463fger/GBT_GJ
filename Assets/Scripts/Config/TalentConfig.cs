using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="TalentConfig",menuName ="Config/TalentConfig")]
public class TalentConfig : ScriptableObject
{
    //规定：Pos按顺序投放
    public List<TalentDataConfig> talantDatas = new List<TalentDataConfig>();
}
public enum TalentType
{

}
