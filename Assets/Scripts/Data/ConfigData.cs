
using Achievement;
using Config;
using UnityEngine;

namespace GameData
{
    /// <summary>
    /// 读取配置,方便使用
    /// </summary>
    public class ConfigData
    {
        /// <summary>
        /// 读取关卡配置
        /// </summary>
        /// <param name="level">哪关</param>
        /// <returns>LevelConfig</returns>
        public WaveConfig LoadWaveConfig(int level)
        {
            return JKFrame.ResSystem.LoadAsset<WaveConfig>($"Level{level}");
        }

        #region MapConfig
        
        /// <summary>
        /// 读取关卡配置列表
        /// </summary>
        /// <param name="level">地图关卡数</param>
        /// <returns>地图网格信息</returns>
        public BlockMessage LoadMapBlockMessage(int level)
        {
            MapConfig mapConfig = JKFrame.ResSystem.LoadAsset<MapConfig>("MapConfig");
            return mapConfig.Mapmessage[level];
        }
        
        #endregion

        public AchievementConfig LoadAchievementConfig()
        {
            return JKFrame.ResSystem.LoadAsset<AchievementConfig>("AchievementConfig");
        }
    }
}