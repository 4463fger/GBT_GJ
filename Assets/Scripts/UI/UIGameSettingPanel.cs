using System.Linq;
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
        // 需要过渡的对象
        private CanvasGroup m_CanvansGroup;
        private SettingDataCenter _settingDataCenter = GameApp.Instance.DataManager.SettingDataCenter;
        [SerializeField] private Slider GlobalAudioSlider;
        [SerializeField] private Slider MusicAudioSlider;
        [SerializeField] private Slider EffectAudioSlider;
        [SerializeField] private Dropdown resolutionDropdown; // 分辨率下拉菜单
        [SerializeField] private Toggle fullScreenToggle; // 是否全屏
        
        private void Awake()
        {
            m_CanvansGroup = GetComponent<CanvasGroup>();

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
            transform.Find("Btn_ExitSetting").GetComponent<Button>().onClick.AddListener(Hide);
            
            // // 分辨率选项设置
            // resolutionDropdown.ClearOptions();
            // resolutionDropdown.AddOptions(_settingDataCenter._settingData.PresetResolutions
            //     .Select(r => $"{r.width}x{r.height}")
            //     .ToList());
            
            // // 加载分辨率的设置
            // resolutionDropdown.value = _settingDataCenter._settingData.resolutionIndex;
            // fullScreenToggle.isOn = _settingDataCenter._settingData.isFullscreen;
            // resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
            // fullScreenToggle.onValueChanged.AddListener(OnFullscreenChanged);
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
        
        // private void OnResolutionChanged(int index)
        // {
        //     ApplyResolution(index, fullScreenToggle.isOn);
        //     _settingDataCenter._settingData.SaveResolutionSettings(index, fullScreenToggle.isOn);
        // }
        //
        // private void OnFullscreenChanged(bool isFullscreen)
        // {
        //     ApplyResolution(resolutionDropdown.value, isFullscreen);
        //     _settingDataCenter._settingData.SaveResolutionSettings(resolutionDropdown.value, isFullscreen);
        // }
        //
        // // 设置分辨率
        // private void ApplyResolution(int index, bool fullscreen)
        // {
        //     Resolution resolution = _settingDataCenter._settingData.PresetResolutions[index];
        //     Screen.SetResolution(resolution.width, resolution.height, fullscreen);
        // }
    }
}