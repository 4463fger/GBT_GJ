using Config;
using JKFrame;

public class GameManager:SingletonMono<GameManager>
{
    public LevelConfig[] levelConfigs;
    public MapConfig mapConfig;
}