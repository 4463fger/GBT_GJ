using DG.Tweening;
using Game;
using GameData;
using JKFrame;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Main
{
    /// <summary>
    /// 设置面板 => 为主面板下的子物体
    /// </summary>
    public class UIGameSettingPanel : MonoBehaviour
    {
        [SerializeField] private Image 激活的音量;
        [SerializeField] private Image 未激活的音量;
        
        private CanvasGroup m_CanvansGroup;
        private SettingDataCenter _settingDataCenter;
        [SerializeField] private Image[] GlobalAudioIcons;
        [SerializeField] private Image[] MusicAudioIcons;
        [SerializeField] private Image[] EffectAudioIcons;
        
        // 音量级别（0 - 10）
        private int _globalVolumeLevel = 5; // 初始值50%
        private int _musicVolumeLevel = 5;
        private int _effectVolumeLevel = 5;

        private AudioClip cancelAudioClip;
        public void Init()
        {
            _settingDataCenter = GameApp.Instance.DataManager.SettingDataCenter;
            m_CanvansGroup = GetComponent<CanvasGroup>();
            m_CanvansGroup.alpha = 0;

            cancelAudioClip = ResSystem.LoadAsset<AudioClip>("Cancel");

            // 总音量设置
            _globalVolumeLevel = (int)(_settingDataCenter._settingData.GlobalVolume * 10);
            JKFrame.AudioSystem.GlobalVolume = _settingDataCenter._settingData.GlobalVolume;
            UpdateGlobalVolumeUI(_globalVolumeLevel);
            for (int i = 0; i < GlobalAudioIcons.Length; i++)
            {
                var i1 = i;
                GlobalAudioIcons[i].GetComponent<Button>().onClick.AddListener(() => SetGlobalVolume(i1));
            }

            // BGM设置
            _musicVolumeLevel = (int)(_settingDataCenter._settingData.MusicVolume * 10);
            JKFrame.AudioSystem.BGVolume = _settingDataCenter._settingData.MusicVolume;
            UpdateBgmVolumeUI(_musicVolumeLevel);
            for (int i = 0; i < MusicAudioIcons.Length; i++)
            {
                var i1 = i;
                MusicAudioIcons[i].GetComponent<Button>().onClick.AddListener(() => SetMusicAudioVolume(i1));
            }
            
            // 音效设置
            _effectVolumeLevel = (int)(_settingDataCenter._settingData.SFXVolume * 10);
            JKFrame.AudioSystem.EffectVolume = _settingDataCenter._settingData.SFXVolume;
            UpdateEffectVolumeUI(_effectVolumeLevel);
            for (int i = 0; i < EffectAudioIcons.Length; i++)
            {
                var i1 = i;
                EffectAudioIcons[i].GetComponent<Button>().onClick.AddListener(() => SetEffectVolume(i1));
            }
            
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
            AudioSystem.PlayOneShot(cancelAudioClip);
            m_CanvansGroup
                .DOFade(0f, 0.5f)
                .SetEase(Ease.InQuad)
                .OnComplete(() =>
                    {
                        gameObject.SetActive(false);
                    }
                );
        }

        #region 更新音量
        
        private void SetGlobalVolume(int iconIndex)
        {
            // 如果你点的这个当前图标是已经被激活的
            // 获取当前图标是否已激活
            // 0 1 2 3 4 5 6 7 8 9 
            bool isCurrentActive = GlobalAudioIcons[iconIndex].sprite == 激活的音量.sprite;
            // 判断点击的是否是最后一个图标
            bool isLastActive = iconIndex == (_globalVolumeLevel - 1);
            
            // 如果点击的图标是最后一个激活的 → 设置为0级（静音）
            if (isCurrentActive && isLastActive)
            {
                _globalVolumeLevel = 0;
            }
            else
            {
                // 否则设置为对应的级别
                _globalVolumeLevel = iconIndex + 1; // iconIndex 0~9 → 级别1~10
            }   
            _globalVolumeLevel = Mathf.Clamp(_globalVolumeLevel, 0, 10); // 0 - 10
            UpdateGlobalVolumeUI(_globalVolumeLevel);
        }
        private void UpdateGlobalVolumeUI(int level)
        {
            for (int i = 0; i < GlobalAudioIcons.Length; i++)
            {
                if (i < level)
                {
                    GlobalAudioIcons[i].sprite = 激活的音量.sprite;
                }
                else
                {
                    GlobalAudioIcons[i].sprite = 未激活的音量.sprite;
                }
            }
            // 更新实际音量
            float value = level == 0 ? 0f : level / 10f; // 0级对应0%，其他为10%~100%
            JKFrame.AudioSystem.GlobalVolume = value;
            _settingDataCenter.SaveSettingDataWithGlobalVolume(value);
        }
        
        private void SetMusicAudioVolume(int iconIndex)
        {
            bool isCurrentActive = MusicAudioIcons[iconIndex].sprite == 激活的音量.sprite;
            bool isLastActive = iconIndex == (_musicVolumeLevel - 1);
            
            if (isCurrentActive && isLastActive)
            {
                _musicVolumeLevel = 0;
            }
            else
            {
                // 否则设置为对应的级别
                _musicVolumeLevel = iconIndex + 1; // iconIndex 0~9 → 级别1~10
            }   
            _musicVolumeLevel = Mathf.Clamp(_musicVolumeLevel, 0, 10); // 0 - 10
            UpdateBgmVolumeUI(_musicVolumeLevel);
        }
        private void UpdateBgmVolumeUI(int level)
        {
            for (int i = 0; i < MusicAudioIcons.Length; i++)
            {
                if (i < level)
                {
                    MusicAudioIcons[i].sprite = 激活的音量.sprite;
                }
                else
                {
                    MusicAudioIcons[i].sprite = 未激活的音量.sprite;
                }
            }
            // 更新实际音量
            float value = level == 0 ? 0f : level / 10f; // 0级对应0%，其他为10%~100%
            JKFrame.AudioSystem.BGVolume = value;
            _settingDataCenter.SaveSettingDataWithBGVolume(value);
        }

        private void SetEffectVolume(int iconIndex)
        {
            bool isCurrentActive = EffectAudioIcons[iconIndex].sprite == 激活的音量.sprite;
            bool isLastActive = iconIndex == (_effectVolumeLevel - 1);
            
            if (isCurrentActive && isLastActive)
            {
                _effectVolumeLevel = 0;
            }
            else
            {
                _effectVolumeLevel = iconIndex + 1; // iconIndex 0~9 → 级别1~10
            }   
            _effectVolumeLevel = Mathf.Clamp(_effectVolumeLevel, 0, 10); // 0 - 10
            UpdateEffectVolumeUI(_effectVolumeLevel);
        }
        private void UpdateEffectVolumeUI(int level)
        {
            for (int i = 0; i < EffectAudioIcons.Length; i++)
            {
                if (i < level)
                {
                    EffectAudioIcons[i].sprite = 激活的音量.sprite;
                }
                else
                {
                    EffectAudioIcons[i].sprite = 未激活的音量.sprite;
                }
            }
            // 更新实际音量
            float value = level == 0 ? 0f : level / 10f; // 0级对应0%，其他为10%~100%
            JKFrame.AudioSystem.EffectVolume = value;
            _settingDataCenter.SaveSettingDataWithEffectVolume(value);
        }

        #endregion
    }
}