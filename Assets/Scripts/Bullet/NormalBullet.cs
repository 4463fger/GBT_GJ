using UnityEngine;

public class NormalBullet : BulletBase
{
    protected float bulletSpeed;
    
    protected override void Shoot()
    {
        gameObject.transform.localPosition += Time.deltaTime * bulletSpeed * transform.up;
        
    }
}
