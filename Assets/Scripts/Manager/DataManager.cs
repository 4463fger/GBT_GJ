/*
* ┌──────────────────────────────────┐
* │  描    述:                       
* │  类    名: 管理游戏数据.cs       
* │  创    建: By 4463fger                     
* └──────────────────────────────────┘
*/

namespace Game.Data
{
    public class DataManager
    {
        // 游戏数据
        public SettingData SettingData;

        public DataManager()
        {
            SettingData = new();
        }
    }
}