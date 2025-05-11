using System;
using Achievement;
using Game;
using JKFrame;
using UI.GameStart;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [UIWindowData(typeof(UI_AchievementPanel),false,"UI_AchievementPanel",3)]
    public class UI_AchievementPanel : UI_WindowBase
    {
        private AchievementConfig m_Config;
        
        private UI_AchievementItem m_AchievementItem;
        [SerializeField] private Transform m_Content; // 天赋存这下边
        [SerializeField] private Button Btn_Close; // 关闭页面

        public override void Init()
        {
            m_Config = GameApp.Instance.DataManager.ConfigData.LoadAchievementConfig();

            foreach (var achievementData in m_Config.achievements)
            {
                UI_AchievementItem item = ResSystem.InstantiateGameObject<UI_AchievementItem>(
                    "AchievementItem",  
                    m_Content,           // 父物体
                    keyName: "AchievementItem"
                );
        
                item.InitAchievementItemData(
                    achievementData.id,
                    achievementData.displayName,
                    achievementData.description, 
                    achievementData.icon,
                    GameApp.Instance.AchievementSystem.IsUnLocked(achievementData)
                );
            }
            
            Btn_Close.onClick.AddListener(Close);
        }

        public override void OnShow()
        {
            // 成就传递数据到UI
            // 读取本地成就配置
            var childs = m_Content.GetComponentsInChildren<UI_AchievementItem>();
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i].IsUnLocked(GameApp.Instance.AchievementSystem.IsUnLocked(childs[i]));
            }
        }

        public override void OnClose()
        {
            foreach (Transform child in m_Content)
            {
                ResSystem.PushGameObjectInPool("AchievementItem", child.gameObject);
            }
        }

        private void Close()
        {
            UISystem.Close<UI_AchievementPanel>();
            
        }
    }
}