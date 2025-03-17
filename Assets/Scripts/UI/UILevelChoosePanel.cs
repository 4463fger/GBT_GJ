using Game;
using JKFrame;
using UnityEngine.UI;
using UnityEngine;

namespace UI
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
            Level1.onClick.AddListener(()=>  onSceneCHangeclick("Level1"));
            Level2.onClick.AddListener(() => onSceneCHangeclick("Level2"));
            Level3.onClick.AddListener(() => onSceneCHangeclick("Level3"));
            Level4.onClick.AddListener(() => onSceneCHangeclick("Level4"));
            Level5.onClick.AddListener(() => onSceneCHangeclick("Level5"));
        }

        private void onSceneCHangeclick(string sceneName)
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