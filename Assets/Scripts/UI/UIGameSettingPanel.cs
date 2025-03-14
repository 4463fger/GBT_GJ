using DG.Tweening;
using Game;
using Game.Data;
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
        private SettingData _settingData = GameApp.Instance.DataManager.SettingData;
        [SerializeField] private Slider GlobalAudioSlider;
        [SerializeField] private Slider MusicAudioSlider;
        [SerializeField] private Slider EffectAudioSlider;
        
        private void Awake()
        {
            m_CanvansGroup = GetComponent<CanvasGroup>();

            // 总音量设置
            GlobalAudioSlider.value = _settingData.GlobalVolume;
            JKFrame.AudioSystem.GlobalVolume = _settingData.GlobalVolume;
            GlobalAudioSlider.onValueChanged.AddListener((value) =>
            {
                JKFrame.AudioSystem.GlobalVolume = value;
                _settingData.SaveSettingDataWithGlobalVolume(value);
            });

            // BGM设置
            MusicAudioSlider.value = _settingData.MusicVolume;
            JKFrame.AudioSystem.BGVolume = _settingData.MusicVolume;
            MusicAudioSlider.onValueChanged.AddListener((value) =>
            {
                JKFrame.AudioSystem.BGVolume = value;
                _settingData.SaveSettingDataWithBGVolume(value);
            });
            
            // 音效设置
            EffectAudioSlider.value = _settingData.SFXVolume;
            JKFrame.AudioSystem.EffectVolume = _settingData.SFXVolume;
            EffectAudioSlider.onValueChanged.AddListener((value) =>
            {
                JKFrame.AudioSystem.EffectVolume = value;
                _settingData.SaveSettingDataWithEffectVolume(value);
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