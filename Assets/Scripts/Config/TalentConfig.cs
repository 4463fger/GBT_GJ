using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="TalentConfig",menuName ="Config/TalentConfig")]
public class TalentConfig : ScriptableObject
{
    //�涨��Pos��˳��Ͷ��
    public List<TalentDataConfig> talantDatas = new List<TalentDataConfig>();
}
public enum TalentType
{

}
