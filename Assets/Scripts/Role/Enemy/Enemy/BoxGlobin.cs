using JKFrame;
using UnityEngine;

namespace Enemy
{
    public class BoxGlobin : EnemyBase<BoxGlobin>
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