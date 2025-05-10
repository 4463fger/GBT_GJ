using JKFrame;
using UnityEngine;

namespace Enemy
{
    public class WaterGlobin : EnemyBase<WaterGlobin>
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