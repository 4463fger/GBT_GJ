using Config;
using JKFrame;

namespace Managers
{
    public class GameManager : SingletonMono<GameManager>
    {
        public WaveConfig[] levelConfigs;
        public MapConfig mapConfig;
    }
}