using JKFrame;
using UI.Main;
using UnityEngine;

namespace ManagerScene
{
    public class LevelChooseManager : MonoBehaviour
    {
        private void Start()
        {
            UISystem.Show<UIBackGroundPanel>();
            UISystem.Show<UILevelChoosePanel>();
        }

        private void OnDestroy()
        {
            UISystem.Close<UIBackGroundPanel>();
            UISystem.Close<UILevelChoosePanel>();
        }
    }
}