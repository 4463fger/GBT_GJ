using Game.Enemy;
using JKFrame;

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
        public IEnemy CreateEnemy(EnemyType type)
        {
            return EnemyFactory.CreateEnemy(type);
        }
    }
}