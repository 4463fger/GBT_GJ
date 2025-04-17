using Enemy;
using UnityEngine;

namespace Factory
{
    public class FactoryManager
    {
        private EnemyFactory EnemyFactory;

        public FactoryManager()
        {
            EnemyFactory = new EnemyFactory();
        }

        /// <summary>
        /// 获取敌人
        /// </summary>
        /// <param name="type">敌人枚举</param>
        public T CreateEnemy<T>(EnemyType type) where T : MonoBehaviour, IHurt
        {
            return EnemyFactory.CreateEnemy<T>(type);
        }
    }
}