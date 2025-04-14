using DG.Tweening;
using Game;
using JKFrame;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Main
{
    [UIWindowData(typeof(UIGameStartPanel),true,"Prefabs/UI/UIGameStartPanel",2)]
    public class UIGameStartPanel : UI_WindowBase
    {
        [SerializeField] private UIGameSettingPanel m_GameSettingPanel;
        public GameObject GameButton;


        // 主界面BGM
        private AudioClip bgmClip;
        
        public override void Init()
        {
            bgmClip = ResSystem.LoadAsset<AudioClip>("Prefabs/Audio/LoginBgm");
            
            // Game: 开始游戏 加载 设置
            transform.Find("Game/Btn_StartGame").GetComponent<Button>().onClick.AddListener(OnStartGameClick);
            transform.Find("Game/Btn_Load").GetComponent<Button>().onClick.AddListener(OnLoadClick);
            transform.Find("Game/Btn_Options").GetComponent<Button>().onClick.AddListener(OnOpenSettingsPanelClick);
            
            // Bottom: 
            transform.Find("Bottom/Btn_Help").GetComponent<Button>().onClick.AddListener(onOpenHelpPanelClick);
            transform.Find("Bottom/Btn_ExitGame").GetComponent<Button>().onClick.AddListener(OnQuitGameClick);
        }

        public override void OnShow()
        {
            var _settingData = GameApp.Instance.DataManager.SettingData;
            
            // 默认加载BGM
            AudioSystem.PlayBGAudio(bgmClip,volume: 1,fadeOutTime:0.5f);
            
            // 同步设置当前音量参数
            AudioSystem.BGVolume = _settingData.MusicVolume;
            AudioSystem.GlobalVolume = _settingData.GlobalVolume;
            
            // 应用分辨率设置
            var resolution = GameApp.Instance.DataManager.SettingData.LoadResolution();
            Screen.SetResolution(resolution.width, resolution.height, 
                GameApp.Instance.DataManager.SettingData.isFullscreen);
        }

        public override void OnClose()
        {
            AudioSystem.StopBGAudio();
        }

        #region Game
        
        // 开始游戏 => 跳转到选择关卡
        private void OnStartGameClick()
        {
            SceneSystem.LoadScene("LevelChoose");
            UISystem.Close<UIGameStartPanel>();
            // 加载关卡选择面板
            UISystem.Show<UILevelChoosePanel>();
        }
        
        private void OnLoadClick()
        {
            //TODO:加载存档界面
            Debug.Log("打开存档界面");
        }

        #endregion
        
        // 打开选项
        private void OnOpenSettingsPanelClick()
        {
            // 将自己往左移, 同时显示设置面板
            GameButton.transform
                .DOLocalMoveX(-300, 0.5f)
                .SetEase(Ease.InQuad)
                .OnComplete(() =>
                {
                    m_GameSettingPanel.Show();
                });
        }

        #region Other

        private void OnOpen图鉴Click()
        {
            //TODO:打开图鉴面板
        }
        
        private void OnOpenShopPanelClick()
        {
            //TODO:打开商店面板
        }
        
        private void OnOpenAchievementPanelClick()
        {
            //TODO:打开成就面板
        }

        #endregion
        
        #region Bottom

        // 打开帮助面板
        private void onOpenHelpPanelClick()
        {
            //TODO:打开帮助面板
        }
        
        // 退出游戏
        private void OnQuitGameClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
        
        #endregion
    }
}