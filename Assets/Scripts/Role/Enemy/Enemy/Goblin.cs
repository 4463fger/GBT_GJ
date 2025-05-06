using JKFrame;

namespace Enemy
{
    public class Goblin : EnemyBase<Goblin>
    {
        protected override void Die()
        {
            isDie = true;
            isInit = false;
            this.GameObjectPushPool();
        }
    }
}