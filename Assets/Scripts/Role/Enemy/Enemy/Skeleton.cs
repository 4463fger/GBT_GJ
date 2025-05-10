using JKFrame;

namespace Enemy
{
    public class Skeleton : EnemyBase<Skeleton>
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