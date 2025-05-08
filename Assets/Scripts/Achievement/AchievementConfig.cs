using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Achievement
{
    [CreateAssetMenu(fileName = "AchievementConfig", menuName = "Config/Achievement Config")]
    public class AchievementConfig : SerializedScriptableObject
    {
        [TableList(ShowIndexLabels = true)]
        public List<AchievementData> achievements = new();
    }
    
    [Serializable]
    public class AchievementData
    { 
        [Header("配置数据")]
        [LabelText("唯一ID")] 
        public string id;
        
        [LabelText("成就名称")] 
        public string displayName;
        
        [TextArea] 
        public string description;
        
        [PreviewField(50)]
        public Sprite icon;
    }

    [Serializable]
    public class AchievementRuntimeData
    {
        public string achievementID;
        public bool isUnLocked;
        public DateTime unLockTime;
    }
}