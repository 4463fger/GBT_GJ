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
        public int screenWidth = 1920;
        public int screenHeight = 1080;    
        public bool isFullscreen = true;
    }
    /// <summary>
    /// 游戏的全局设置: 音量音效
    /// </summary>
    public class SettingDataCenter
    {
        public SettingData _settingData { get; private set; } = new();

        public SettingDataCenter()
        {
            LoadSettingData();
        }
        
        private void LoadSettingData()
        {
            SettingData data = JKFrame.SaveSystem.LoadSetting<SettingData>("SettingData");
            if (data == null)
            {
                // 设置数据不存在 ，那就初始化一个然后存起来
                JKFrame.SaveSystem.SaveSetting(_settingData);
            }
            _settingData = data;
        }

        public void SaveSettingDataWithGlobalVolume(float GlobalVolume)
        {
            _settingData.GlobalVolume = GlobalVolume;
            JKFrame.AudioSystem.GlobalVolume = GlobalVolume;
            JKFrame.SaveSystem.SaveSetting(_settingData);
        }
        
        public void SaveSettingDataWithBGVolume(float BGVolume)
        {
            _settingData.MusicVolume = BGVolume;
            JKFrame.AudioSystem.BGVolume = _settingData.MusicVolume;
            JKFrame.SaveSystem.SaveSetting(_settingData);
        }
        
        public void SaveSettingDataWithEffectVolume(float EffectVolume)
        {
            _settingData.SFXVolume = EffectVolume;
            JKFrame.AudioSystem.EffectVolume = _settingData.SFXVolume;
            JKFrame.SaveSystem.SaveSetting(_settingData);
        }
        
        // 保存分辨率设置
        public void SaveResolutionSettings(Resolution resolution, bool fullscreen)
        {
            _settingData.screenWidth = resolution.width;
            _settingData.screenHeight = resolution.height;
            _settingData.isFullscreen = fullscreen;
            JKFrame.SaveSystem.SaveSetting(_settingData);
        }
    }
}