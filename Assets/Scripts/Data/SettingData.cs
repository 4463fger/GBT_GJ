/*
* ┌──────────────────────────────────┐
* │  描    述: 游戏的全局设置                      
* │  类    名: SettingData.cs       
* │  创    建: By 4463fger                     
* └──────────────────────────────────┘
*/

using System;
using JK.Log;
using UnityEngine;
using UnityEngine.Windows;

namespace GameData
{
    [Serializable]
    public class SettingData
    {
        // 音量
        public float GlobalVolume = 1f;
        public float MusicVolume = 1f;
        public float SFXVolume = 1f;
        
        // 分辨率
        public int resolutionIndex = 0;        // 默认选第一个分辨率
        public bool isFullscreen = true;       // 默认全屏
    }
    /// <summary>
    /// 游戏的全局设置: 音量音效
    /// </summary>
    public class SettingDataCenter
    {
        public SettingData _settingData { get; private set; }

        // 游戏支持的分辨率(这里给写死)
        public readonly Resolution[] PresetResolutions = 
        {
            new Resolution { width = 1920, height = 1080 },
            new Resolution { width = 1600, height = 900 },
            new Resolution { width = 1366, height = 768 },
            new Resolution { width = 1280, height = 720 }
        };

        public SettingDataCenter()
        {
            LoadSettingData();
        }
        
        // 获取当前分辨率
        // public Resolution LoadResolution()
        // {
        //     return PresetResolutions[resolutionIndex];
        // }
        
        public void LoadSettingData()
        {
            if (!Directory.Exists(Application.persistentDataPath + "/" + "setting"))
            {
#if UNITY_EDITOR
                JKLog.Warning($"依然不存在这个路径{Application.persistentDataPath + "/" + "setting"}");
#endif
                _settingData = new();
            }
            else
            {
                SettingData data = JKFrame.SaveSystem.LoadSetting<SettingData>("SettingData");
                if (data == null)
                {
                    JKFrame.SaveSystem.SaveSetting(_settingData);
                }
                _settingData = data;
            }
        }

        public void SaveSettingDataWithGlobalVolume(float GlobalVolume)
        {
            _settingData.GlobalVolume = GlobalVolume;
            JKFrame.AudioSystem.GlobalVolume = GlobalVolume;
            JKFrame.SaveSystem.SaveSetting(this);
        }
        
        public void SaveSettingDataWithBGVolume(float BGVolume)
        {
            _settingData.MusicVolume = BGVolume;
            JKFrame.AudioSystem.BGVolume = _settingData.MusicVolume;
            JKFrame.SaveSystem.SaveSetting(this);
        }
        
        public void SaveSettingDataWithEffectVolume(float EffectVolume)
        {
            _settingData.SFXVolume = EffectVolume;
            JKFrame.AudioSystem.EffectVolume = _settingData.SFXVolume;
            JKFrame.SaveSystem.SaveSetting(this);
        }
        
        // // 保存分辨率设置
        // public void SaveResolutionSettings(int index, bool fullscreen)
        // {
        //     _settingData.resolutionIndex = Mathf.Clamp(index, 0, PresetResolutions.Length - 1);
        //     isFullscreen = fullscreen;
        //     JKFrame.SaveSystem.SaveSetting(this);
        // }
    }
}