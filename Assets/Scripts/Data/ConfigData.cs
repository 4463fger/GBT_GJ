using Config;

namespace Game.Data
{
    /// <summary>
    /// 读取配置,方便使用
    /// </summary>
    public class ConfigData
    {
        private LevelConfig LevelConfig;

        /// <summary>
        /// 读取关卡配置
        /// </summary>
        /// <param name="level">哪关</param>
        /// <returns>LevelConfig</returns>
        public LevelConfig LoadConfig(int level)
        {
            return JKFrame.ResSystem.LoadAsset<LevelConfig>($"Config/Level{level}");
        }
    }
}