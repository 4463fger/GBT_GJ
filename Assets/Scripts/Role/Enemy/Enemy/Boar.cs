using JKFrame;

namespace Enemy
{
    public class Boar : EnemyBase<Boar>
    {
        // 死亡
        protected override void Die()
        {
            isDie = true;
            isInit = false;
            this.GameObjectPushPool();
        }
    }
}