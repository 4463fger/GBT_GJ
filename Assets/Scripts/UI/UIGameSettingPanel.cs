using System.Linq;
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
        [SerializeField] private Dropdown resolutionDropdown; // 分辨率下拉菜单
        [SerializeField] private Toggle fullScreenToggle; // 是否全屏
        
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
            
            // 分辨率选项设置
            resolutionDropdown.ClearOptions();
            resolutionDropdown.AddOptions(_settingData.PresetResolutions
                .Select(r => $"{r.width}x{r.height}")
                .ToList());
            
            // 加载设置
            resolutionDropdown.value = _settingData.resolutionIndex;
            fullScreenToggle.isOn = _settingData.isFullscreen;
            resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
            fullScreenToggle.onValueChanged.AddListener(OnFullscreenChanged);
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
        
        private void OnResolutionChanged(int index)
        {
            ApplyResolution(index, fullScreenToggle.isOn);
            _settingData.SaveResolutionSettings(index, fullScreenToggle.isOn);
        }
        
        private void OnFullscreenChanged(bool isFullscreen)
        {
            ApplyResolution(resolutionDropdown.value, isFullscreen);
            _settingData.SaveResolutionSettings(resolutionDropdown.value, isFullscreen);
        }
        
        // 设置分辨率
        private void ApplyResolution(int index, bool fullscreen)
        {
            Resolution resolution = _settingData.PresetResolutions[index];
            Screen.SetResolution(resolution.width, resolution.height, fullscreen);
        }
    }
}