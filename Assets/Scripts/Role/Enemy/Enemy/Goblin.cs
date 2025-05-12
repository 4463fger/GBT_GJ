using JKFrame;

namespace Enemy
{
    public class Goblin : EnemyBase<Goblin>
    {
        protected override void Awake()
        {
            base.Awake();
            isRight = true;
        }
    }
}