using UnityEngine;

public class NormalBullet : BulletBase
{
    protected float bulletSpeed;
    private BoxCollider2D boxCollider;
    protected override void Shoot()
    {
        gameObject.transform.localPosition += Time.deltaTime * bulletSpeed * transform.up;
        
    }
}
