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
    }
}