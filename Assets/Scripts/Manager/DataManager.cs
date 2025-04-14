/*
* ┌──────────────────────────────────┐
* │  描    述: 管理游戏数据                      
* │  类    名: DataManager.cs       
* │  创    建: By 4463fger                     
* └──────────────────────────────────┘
*/

using GameData;

namespace Game.Data
{
    public class DataManager
    {
        // 游戏数据
        public SettingData SettingData;
        public ConfigData ConfigData;

        public DataManager()
        {
            SettingData = new();
            ConfigData = new();
        }
    }
}