using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// 设置面板 => 为主面板下的子物体
    /// </summary>
    public class UIGameSettingPanel : MonoBehaviour
    {
        private Image Bg;
        private GameObject Btn_Options;
        private GameObject Btn_ExitSetting;
        
        private void Awake()
        {
            Bg = transform.Find("Bg").GetComponent<Image>();
            Btn_Options = transform.Find("Btn_Options").gameObject;
            Btn_ExitSetting = transform.Find("Btn_ExitSetting").gameObject;
            Btn_Options.GetComponent<Button>().onClick.AddListener(OnOptionsClick);
            Btn_ExitSetting.GetComponent<Button>().onClick.AddListener(OnExitSettingClick);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        private void OnOptionsClick()
        {
            //TODO:打开选项设置面板
            // 设置分辨率,声音,语言等
        }

        private void OnExitSettingClick()
        {
            Hide();
        }
    }
}