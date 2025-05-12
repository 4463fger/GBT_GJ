using DG.Tweening;
using Game;
using JKFrame;
using UI.TalentTree;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Main
{
    [UIWindowData(typeof(UIGameStartPanel),true,"UIGameStartPanel",2)]
    public class UIGameStartPanel : UI_WindowBase
    {
        // 子物体
        [SerializeField] private UIGameSettingPanel m_GameSettingPanel;
        [SerializeField] private UIHelpPanel m_HelpPanel;

        [Header("左侧按钮")]
        [SerializeField] private Button Btn_图鉴;
        [SerializeField] private Button Btn_Shop;
        [SerializeField] private Button Btn_Achievement;
        
        [Header("中间按钮")] 
        [SerializeField] private Button Btn_StartGame;
        [SerializeField] private Button Btn_LoadGame;
        
        [Header("右侧按钮")]
        [SerializeField] private Button Btn_Options;
        [SerializeField] private Button Btn_Help;
        [SerializeField] private Button Btn_ExitGame;

        // 主界面BGM
        private AudioClip bgmClip;
        private AudioClip confirmClip;

        public override void Init()
        {
            // 加载Bgm
            bgmClip = ResSystem.LoadAsset<AudioClip>("LoginBgm");
            confirmClip = ResSystem.LoadAsset<AudioClip>("Confirm");    
            
            // 左侧按钮
            Btn_图鉴.GetComponent<Button>().onClick.AddListener(OnOpenTreeClick);
            Btn_Shop.GetComponent<Button>().onClick.AddListener(OnOpenShopPanelClick);
            Btn_Achievement.GetComponent<Button>().onClick.AddListener(OnOpenAchievementPanelClick);

            // 中间按钮: 开始游戏 加载 
            Btn_StartGame.GetComponent<Button>().onClick.AddListener(OnStartGameClick);
            Btn_LoadGame.GetComponent<Button>().onClick.AddListener(OnLoadClick);
            
            // 右侧按钮
            Btn_Options.GetComponent<Button>().onClick.AddListener(OnOpenSettingsPanelClick);
            Btn_Help.GetComponent<Button>().onClick.AddListener(onOpenHelpPanelClick);
            Btn_ExitGame.GetComponent<Button>().onClick.AddListener(OnQuitGameClick);

            m_GameSettingPanel.Init();
            m_HelpPanel.Init();
        }

        public override void OnShow()
        {
            var _settingDataCenter = GameApp.Instance.DataManager.SettingDataCenter;
            
            // 默认加载BGM
            AudioSystem.PlayBGAudio(bgmClip,volume: 1,fadeOutTime:0.5f);
            
            // 同步设置当前音量参数
            AudioSystem.BGVolume = _settingDataCenter._settingData.MusicVolume;
            AudioSystem.GlobalVolume = _settingDataCenter._settingData.GlobalVolume;
        }

        public override void OnClose()
        {
            m_GameSettingPanel.OnHide();
            m_HelpPanel.OnHide();
            AudioSystem.StopBGAudio();
        }

        #region 左侧按钮
        
        private void OnOpenShopPanelClick()
        {
            //TODO:打开商店面板
            AudioSystem.PlayOneShot(confirmClip);
        }
        
        private void OnOpenTreeClick()
        {
            AudioSystem.PlayOneShot(confirmClip);
            UISystem.Show<UI_TalentTree>();
        }
        
        private void OnOpenAchievementPanelClick()
        {
            //TODO:打开成就面板
            AudioSystem.PlayOneShot(confirmClip);
            UISystem.Show<UI_AchievementPanel>();
        }

        #endregion
        
        #region 中间按钮
        
        // 开始游戏 => 跳转场景
        private void OnStartGameClick()
        {
            AudioSystem.PlayOneShot(confirmClip);
            UISystem.Close<UIGameStartPanel>();
            SceneSystem.LoadScene("LevelChoose");
            UISystem.Show<UILevelChoosePanel>();
        }
        
        private void OnLoadClick()
        {
            AudioSystem.PlayOneShot(confirmClip);
            //TODO:加载存档界面
            Debug.Log("打开存档界面");
        }

        #endregion
        
        #region 右侧按钮

        // 打开选项
        private void OnOpenSettingsPanelClick()
        {
            AudioSystem.PlayOneShot(confirmClip);
            m_GameSettingPanel.OnShow();
        }
        
        // 打开帮助面板
        private void onOpenHelpPanelClick()
        {
            AudioSystem.PlayOneShot(confirmClip);
            m_HelpPanel.OnShow();
        }
        
        // 退出游戏
        private void OnQuitGameClick()
        {
            AudioSystem.PlayOneShot(confirmClip);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        #endregion

        private void OnDestroy()
        {
            DOTween.KillAll();
        }
    }
}