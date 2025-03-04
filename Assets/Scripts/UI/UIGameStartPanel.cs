using JKFrame;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [UIWindowData(typeof(UIGameStartPanel),true,"Prefabs/UI/UIGameStartPanel",2)]
    public class UIGameStartPanel : UI_WindowBase
    {
        [SerializeField] private UIGameSettingPanel m_GameSettingPanel;
        public override void Init()
        {
            transform.Find("Middle/Btn_StartGame").GetComponent<Button>().onClick.AddListener(OnStartGameClick);
            transform.Find("Middle/Btn_Settings").GetComponent<Button>().onClick.AddListener(OnOpenSettingsPanelClick);
            transform.Find("Middle/Btn_ExitGame").GetComponent<Button>().onClick.AddListener(OnQuitGameClick);
        }

        public override void OnShow()
        {
            //TODO:播放主界面BGM
        }

        public override void OnClose()
        {
            //TODO:实现UI动画
        }
        
        private void OnStartGameClick()
        {
            SceneSystem.LoadScene("LevelChoose");
            UISystem.Close<UIGameStartPanel>();
        }
        
        private void OnOpenSettingsPanelClick()
        {
            m_GameSettingPanel.Show();
        }
        
        private void OnQuitGameClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}