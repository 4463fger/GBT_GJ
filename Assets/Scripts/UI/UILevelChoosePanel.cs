using JKFrame;
using ManagerScene;
using UnityEngine.UI;
using UnityEngine;
using UI.Fight;

namespace UI.Main
{
    [UIWindowData(typeof(UILevelChoosePanel),true,"UILevelChoosePanel",2)]
    public class UILevelChoosePanel : UI_WindowBase
    {
        [SerializeField] private Button Level1;
        [SerializeField] private Button Level2;
        [SerializeField] private Button Level3;
        [SerializeField] private Button Level4;
        [SerializeField] private Button Level5;
        [SerializeField] private Button Btn_ReturnHomePage;
        
        private AudioClip confirmClip;
        public override void Init()
        {
            confirmClip = ResSystem.LoadAsset<AudioClip>("Confirm");    
            Level1.onClick.AddListener(()=>  OnSceneCHandeClick("Level1"));
            Level2.onClick.AddListener(() => OnSceneCHandeClick("Level2"));
            Level3.onClick.AddListener(() => OnSceneCHandeClick("Level3"));
            Level4.onClick.AddListener(() => OnSceneCHandeClick("Level4"));
            Level5.onClick.AddListener(() => OnSceneCHandeClick("Level5"));

            Btn_ReturnHomePage.onClick.AddListener(OnReturnHomePageClick);
        }

        private void OnSceneCHandeClick(string sceneName)
        {
            SceneSystem.LoadSceneAsync(sceneName, (op) =>
            {
                if (op == 1.0f)
                {
                    int level = int.Parse(sceneName.Replace("Level",""));
                    FightManager.Instance.InitFightManager(level);
                }
            });
        }

        private void OnReturnHomePageClick()
        {
            AudioSystem.PlayOneShot(confirmClip);
            SceneSystem.LoadScene("GameStart");
        }
    }
}