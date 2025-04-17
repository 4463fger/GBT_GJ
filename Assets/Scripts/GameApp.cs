using Factory;
using Game.Data;
using JKFrame;
using Managers;
using Managers.Map;
using UI.Main;

// 游戏的主入口,需要跨场景的管理器在这里进行初始化
namespace Game
{
    public class GameApp : SingletonMono<GameApp>
    {
        // 需要跨场景的管理器
        // 不需要跨场景的管理器在每个场景中手动添加即可
        public DataManager DataManager;
        public FactoryManager FactoryManager;
        
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
            
            InitManager();
        }

        void InitManager()
        {
            DataManager = new();
            FactoryManager = new();
        }

        private void Start()
        {
            // 游戏开始
            UISystem.Show<UIBackGroundPanel>();
            UISystem.Show<UIGameStartPanel>();
        }
    }
}