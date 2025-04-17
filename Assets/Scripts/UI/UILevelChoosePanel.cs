using JKFrame;
using Managers;
using UnityEngine.UI;
using UnityEngine;
using UI.Fight;

namespace UI.Main
{
    [UIWindowData(typeof(UILevelChoosePanel),true,"Prefabs/UI/UILevelChoosePanel",2)]
    public class UILevelChoosePanel : UI_WindowBase
    {
        [SerializeField] private Button Level1;
        [SerializeField] private Button Level2;
        [SerializeField] private Button Level3;
        [SerializeField] private Button Level4;
        [SerializeField] private Button Level5;
        public override void Init()
        {
            Level1.onClick.AddListener(()=>  OnSceneCHandeClick("Level1"));
            Level2.onClick.AddListener(() => OnSceneCHandeClick("Level2"));
            Level3.onClick.AddListener(() => OnSceneCHandeClick("Level3"));
            Level4.onClick.AddListener(() => OnSceneCHandeClick("Level4"));
            Level5.onClick.AddListener(() => OnSceneCHandeClick("Level5"));
        }

        private void OnSceneCHandeClick(string sceneName)
        {
            SceneSystem.LoadSceneAsync(sceneName, (op) =>
            {
                if (op == 1.0f)
                {
                    UISystem.Close<UIBackGroundPanel>();
                    UISystem.Close<UILevelChoosePanel>();
                    UISystem.Show<FightUI>();

                    int level = int.Parse(sceneName.Replace("Level",""));
                    FightManager.Instance.InitFightManager(level);
                }
            });
        }
    }
}