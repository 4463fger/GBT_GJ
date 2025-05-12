/*
* ┌──────────────────────────────────┐
* │  描    述: 游戏的各种常量                       
* │  类    名: Defines.cs       
* │  创    建: By 4463fger                     
* └──────────────────────────────────┘
*/

namespace Game
{
    public class Defines
    {
        // UI事件
        // [1]: GameStartPanel
        public const string UpdateSettingTextEvent = "UpdateSettingTextEvent";

        // [2]: FightUI
        public const string WaveCountChange = "WaveCountChange";
        public const string CoinTextChange = "CoinTextChange";
        public const string SetDescription = "SetDescription";
        
        // 成就相关
        public const string Achievement2UIShow = "Achievement2UIShow";
    }
}