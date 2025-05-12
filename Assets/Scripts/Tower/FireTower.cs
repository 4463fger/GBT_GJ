using Item.Bullet;
using UnityEngine;

namespace Tower
{
    public class FireTower : TowerBase
    {
        protected override void Attack()
        {
            //animator.Play("Shoot");
            GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<BulletBase>().SetTarget(getEnemyCollider()[collider2Ds.Length - 1].gameObject);
            Vector3 dir = getEnemyCollider()[collider2Ds.Length - 1].gameObject.transform.position - bullet.transform.position;
            dir.Normalize();
            bullet.transform.up = dir;
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}