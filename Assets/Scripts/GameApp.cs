using Achievement;
using Factory;
using Game.Data;
using JKFrame;

// 游戏的主入口,需要跨场景的管理器在这里进行初始化
namespace Game
{
    public class GameApp : SingletonMono<GameApp>
    {
        // 需要跨场景的管理器
        // 不需要跨场景的管理器在每个场景中手动添加即可
        public DataManager DataManager;
        public FactoryManager FactoryManager;

        public AchievementSystem AchievementSystem;
        
        protected override void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            base.Awake();
            DontDestroyOnLoad(gameObject);
            
            InitManager();
        }

        void InitManager()
        {
            DataManager = new();
            FactoryManager = new();
            AchievementSystem = new();
            
            AchievementSystem.Init();
        }
    }
}