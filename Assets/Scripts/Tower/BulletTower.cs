using UnityEngine;

namespace Tower
{
    /// <summary>
    /// 子弹塔
    /// </summary>
    public class BulletTower : TowerBase
    {
        private int PosX;
        private int PosY;

        public BulletTower(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }

        private void Attack()
        {
            GameObject bullet = Instantiate(Bullet);
            bullet.transform.up = getEnemyCollider()[0].gameObject.transform.position;
        }

        protected override void Update()
        {
            base.Update();
            if (isTimeEnd() && isHaveEnemy())
            {
                Attack();
                return;
            }
        }
    }
}