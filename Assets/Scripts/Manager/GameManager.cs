using Config;
using JKFrame;

public class GameManager:SingletonMono<GameManager>
{
    public WaveConfig[] levelConfigs;
    public MapConfig mapConfig;
}