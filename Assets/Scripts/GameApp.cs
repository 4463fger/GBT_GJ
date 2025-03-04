using System;
using Factory;
using JKFrame;
using UI;

namespace Game
{
    // 不同于JKRoot,为游戏管理器初始化
    public class GameApp : SingletonMono<GameApp>
    {
        public FactoryManager FactoryManager;
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
            
            InitManager();
        }

        void InitManager()
        {
            FactoryManager = new();
        }

        private void Start()
        {
            // 游戏开始
            UISystem.Show<UIBackGroundPanel>();
            UISystem.Show<UIGameStartPanel>();
        }

        private void Update()
        {
            
        }
    }
}