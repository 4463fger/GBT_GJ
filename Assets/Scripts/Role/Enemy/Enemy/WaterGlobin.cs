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
    }
}