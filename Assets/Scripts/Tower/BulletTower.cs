using Item.Bullet;
using UnityEngine;

namespace Tower
{
    /// <summary>
    /// 子弹塔
    /// </summary>
    public class BulletTower : TowerBase
    {
        protected override void Attack()
        {
            animator.Play("Shoot");
            GameObject bullet = Instantiate(Bullet,transform.position,Quaternion.identity);
            Vector3 targetPosition = getEnemyCollider()[collider2Ds.Length - 1].gameObject.transform.position;
            Vector3 direction = (targetPosition - bullet.transform.position).normalized;
            gameObject.transform.up = direction;
            bullet.GetComponent<BulletBase>().SetTarget(getEnemyCollider()[collider2Ds.Length - 1].gameObject);
            Vector3 dir= getEnemyCollider()[collider2Ds.Length - 1].gameObject.transform.position-bullet.transform.position;
            dir.Normalize();
            bullet.transform.up = dir;
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}