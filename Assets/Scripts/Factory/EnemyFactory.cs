using Game.Enemy;

namespace Factory
{
    public class EnemyFactory : IFactory
    {
        public IEnemy CreateEnemy(EnemyType type)
        {
            IEnemy enemy = null;
            switch (type)
            {
                case EnemyType.哥布林:
                    enemy =  JKFrame.ResSystem.LoadAsset<EnemyBase>("Resources/Prefabs/Enemy/哥布林");
                    break;
                case EnemyType.野猪:
                    enemy = JKFrame.ResSystem.LoadAsset<EnemyBase>("Resources/Prefabs/Enemy/野猪");
                    break;
            }
            return enemy;
        }
    }
}