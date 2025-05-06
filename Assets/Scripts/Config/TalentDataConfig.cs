using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TalentDataConfig", menuName = "Config/TalentDataConfig")]
public class TalentDataConfig:ScriptableObject
{
    public Vector2 talentPos;//x：在天赋树的第几层 y：在x层的第几列
    public string talentName;//天赋名称
    public string talentDescription;//天赋描述
    public TalentType talentType;//天赋类型
    public Sprite talentSprite;//天赋图标
    public float value;//天赋给予的数值
    public List<TalentDataConfig> preData;//前置天赋
    public GetTalentConfig getTalentConfig;//获取该天赋后需要做的事
    public int currentLevelMaxIndex;//当前天赋层最大值
}