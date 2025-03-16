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
        public float GlobalVolume = 1f;
        public float MusicVolume = 1f;
        public float SFXVolume = 1f;

        public SettingData()
        {
            LoadSettingData();
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
    }
}