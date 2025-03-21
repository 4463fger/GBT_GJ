﻿using Factory;
using Game.Data;
using JKFrame;
using Map;
using UI;
using UnityEngine;

namespace Game
{
    // 不同于JKRoot,为游戏管理器初始化
    public class GameApp : SingletonMono<GameApp>
    {
        public DataManager DataManager;
        public FactoryManager FactoryManager;
        public MapManager MapManager;
        
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
            MapManager = new();
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