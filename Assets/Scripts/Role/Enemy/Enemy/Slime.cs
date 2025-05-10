/*
* ┌──────────────────────────────────┐
* │  描    述: 史莱姆                      
* │  类    名: Slime.cs       
* │  创    建: By 4463fger                     
* └──────────────────────────────────┘
*/

using JKFrame;

namespace Enemy
{
    public class Slime : EnemyBase<Slime>
    {
        protected override void Awake()
        {
            base.Awake();
            isRight = false;
        }
        protected override void Die()
        {
            isDie = true;
            isInit = false;
            this.GameObjectPushPool();
        }
    }
}