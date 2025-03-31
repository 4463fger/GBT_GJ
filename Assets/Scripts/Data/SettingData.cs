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

namespace Game.Data
{
    /// <summary>
    /// 游戏的全局设置: 音量音效
    /// </summary>
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
        // 游戏支持的分辨率(这里给写死)
        public readonly Resolution[] PresetResolutions = 
        {
            new Resolution { width = 1920, height = 1080 },
            new Resolution { width = 1600, height = 900 },
            new Resolution { width = 1366, height = 768 },
            new Resolution { width = 1280, height = 720 }
        };

        public SettingData()
        {
            LoadSettingData();
        }
        
        // 获取当前分辨率
        public Resolution LoadResolution()
        {
            return PresetResolutions[resolutionIndex];
        }
        
        public void LoadSettingData()
        {
            if (!Directory.Exists(Application.persistentDataPath + "/" + "setting"))
            {
#if UNITY_EDITOR
                JKLog.Warning($"依然不存在这个路径{Application.persistentDataPath + "/" + "setting"}");
#endif
                GlobalVolume = 1f;
                MusicVolume = 1f;
                SFXVolume = 1f;
            }
            else
            {
                SettingData data = JKFrame.SaveSystem.LoadSetting<SettingData>("SettingData");
                if (data is null)
                {
                    JKFrame.SaveSystem.SaveSetting(this);
                    data = this;
                }
                GlobalVolume = data.GlobalVolume;
                MusicVolume = data.MusicVolume;
                SFXVolume = data.SFXVolume;
            }
        }

        public void SaveSettingDataWithGlobalVolume(float GlobalVolume)
        {
            this.GlobalVolume = GlobalVolume;
            JKFrame.AudioSystem.GlobalVolume = GlobalVolume;
            JKFrame.SaveSystem.SaveSetting(this);
        }
        
        public void SaveSettingDataWithBGVolume(float BGVolume)
        {
            this.MusicVolume = BGVolume;
            JKFrame.AudioSystem.BGVolume = MusicVolume;
            JKFrame.SaveSystem.SaveSetting(this);
        }
        
        public void SaveSettingDataWithEffectVolume(float EffectVolume)
        {
            this.SFXVolume = EffectVolume;
            JKFrame.AudioSystem.EffectVolume = SFXVolume;
            JKFrame.SaveSystem.SaveSetting(this);
        }
        
        // 保存分辨率设置
        public void SaveResolutionSettings(int index, bool fullscreen)
        {
            resolutionIndex = Mathf.Clamp(index, 0, PresetResolutions.Length - 1);
            isFullscreen = fullscreen;
            JKFrame.SaveSystem.SaveSetting(this);
        }
    }
}