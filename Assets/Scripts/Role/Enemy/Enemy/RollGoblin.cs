using JKFrame;

namespace Enemy
{
    public class RollGoblin : EnemyBase<RollGoblin>
    {
        protected override void Awake()
        {
            base.Awake();
            isRight = true;
        }

        protected override void Die()
        {
            isDie = true;
            isInit = false;
            this.GameObjectPushPool();
        }
    }
}