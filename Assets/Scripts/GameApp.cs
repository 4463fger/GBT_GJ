using Factory;
using JKFrame;

namespace Game
{
    // 不同于JKRoot,为游戏管理器初始化
    public class GameApp : SingletonMono<GameApp>
    {
        public FactoryManager FactoryManager;
        protected override void Awake()
        {
            base.Awake();

            InitManager();
        }

        void InitManager()
        {
            FactoryManager = new();
        }
    }
}