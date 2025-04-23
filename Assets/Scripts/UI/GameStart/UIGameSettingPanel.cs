using DG.Tweening;
using Game;
using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Main
{
    /// <summary>
    /// 设置面板 => 为主面板下的子物体
    /// </summary>
    public class UIGameSettingPanel : MonoBehaviour
    {
        private CanvasGroup m_CanvansGroup;
        private SettingDataCenter _settingDataCenter;
        [SerializeField] private Slider GlobalAudioSlider;
        [SerializeField] private Slider MusicAudioSlider;
        [SerializeField] private Slider EffectAudioSlider;
        
        public void Init()
        {
            _settingDataCenter = GameApp.Instance.DataManager.SettingDataCenter;
            m_CanvansGroup = GetComponent<CanvasGroup>();
            m_CanvansGroup.alpha = 0;

            // 总音量设置
            GlobalAudioSlider.value = _settingDataCenter._settingData.GlobalVolume;
            JKFrame.AudioSystem.GlobalVolume = _settingDataCenter._settingData.GlobalVolume;
            GlobalAudioSlider.onValueChanged.AddListener((value) =>
            {
                JKFrame.AudioSystem.GlobalVolume = value;
                _settingDataCenter.SaveSettingDataWithGlobalVolume(value);
            });

            // BGM设置
            MusicAudioSlider.value = _settingDataCenter._settingData.MusicVolume;
            JKFrame.AudioSystem.BGVolume = _settingDataCenter._settingData.MusicVolume;
            MusicAudioSlider.onValueChanged.AddListener((value) =>
            {
                JKFrame.AudioSystem.BGVolume = value;
                _settingDataCenter.SaveSettingDataWithBGVolume(value);
            });
            
            // 音效设置
            EffectAudioSlider.value = _settingDataCenter._settingData.SFXVolume;
            JKFrame.AudioSystem.EffectVolume = _settingDataCenter._settingData.SFXVolume;
            EffectAudioSlider.onValueChanged.AddListener((value) =>
            {
                JKFrame.AudioSystem.EffectVolume = value;
                _settingDataCenter.SaveSettingDataWithEffectVolume(value);
            });
            
            // 返回按钮
            transform.Find("Btn_ExitSetting").GetComponent<Button>().onClick.AddListener(OnHide);
        }
        
        public void OnShow()
        {
            m_CanvansGroup
                .DOFade(1f, 0.5f)
                .SetEase(Ease.InQuad);
            gameObject.SetActive(true);
        }
        
        public void OnHide()
        {
            m_CanvansGroup
                .DOFade(0f, 0.5f)
                .SetEase(Ease.InQuad);;
            gameObject.SetActive(false);
        }
    }
}