using JKFrame;
using UI.Fight;
using UnityEngine;

namespace ManagerScene
{
    public class GameSceneManager : MonoBehaviour
    {
        private void Awake()
        {
            UISystem.Show<FightUI>();
        }

        private void OnDestroy()
        {
            UISystem.Close<FightUI>();
            FightManager.Instance.UnInitFightManager();
        }
    }
}