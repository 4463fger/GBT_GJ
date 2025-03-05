using Game;
using JKFrame;
using UnityEngine.UI;

namespace UI
{
    [UIWindowData(typeof(UILevelChoosePanel),true,"Prefabs/UI/UILevelChoosePanel",2)]
    public class UILevelChoosePanel : UI_WindowBase
    {
        public override void Init()
        {
            transform.Find("Scroll View/Viewport/Content/Level1").GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneSystem.LoadSceneAsync("Level 1", (op) =>
                {
                    if (op == 1.0f)
                    {
                        GameApp.Instance.MapManager.Init();
                        UISystem.Close<UIBackGroundPanel>();
                        UISystem.Close<UILevelChoosePanel>();
                    }
                });
            });
        }
    }
}