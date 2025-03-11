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
        // 需要过渡的对象
        private CanvasGroup m_CanvansGroup;
        private void Awake()
        {
            m_CanvansGroup = GetComponent<CanvasGroup>();
            // 总音量设置
            transform.Find("GlobalAudio/Slider").GetComponent<Slider>().onValueChanged.AddListener((value) =>
            {
                JKFrame.AudioSystem.GlobalVolume = value;
            });
            
            // BGM设置
            transform.Find("MusicAudio/Slider").GetComponent<Slider>().onValueChanged.AddListener((value) =>
            {
                JKFrame.AudioSystem.BGVolume = value;
            });
            
            // 音效设置
            transform.Find("EffectAudio/Slider").GetComponent<Slider>().onValueChanged.AddListener((value) =>
            {
                JKFrame.AudioSystem.EffectVolume = value;
            });
            
            // 返回按钮
            transform.Find("Btn_ExitSetting").GetComponent<Button>().onClick.AddListener(Hide);
        }

        public void Show()
        {
            m_CanvansGroup.DOFade(1f, 1f);
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            m_CanvansGroup.DOFade(0f, 1f);
            gameObject.SetActive(false);
            JKFrame.UISystem.GetWindow<UIGameStartPanel>().GameButton.transform
                .DOLocalMoveX(0, 0.3f)
                .SetEase(Ease.InQuad);
        }
    }
}