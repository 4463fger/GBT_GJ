using System;
using JKFrame;
using UI.Main;
using UnityEngine;

namespace ManagerScene
{
    /// <summary>
    /// 场景管理器
    /// </summary>
    public class GameStartManager : MonoBehaviour
    {
        private void Start()
        {
            UISystem.Show<UIBackGroundPanel>();
            UISystem.Show<UIGameStartPanel>();
        }

        private void OnDestroy()
        {
            UISystem.Close<UIBackGroundPanel>();
            UISystem.Close<UIGameStartPanel>();
        }
    }
}