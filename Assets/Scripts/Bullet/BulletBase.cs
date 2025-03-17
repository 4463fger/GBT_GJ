using JKFrame;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 子弹基类
/// </summary>
public abstract class BulletBase : MonoBehaviour
{
    protected float bulletDamage;
    protected float destroyTime;
    protected float destroyTimer;
    protected AudioClip hitClip;
    protected Collider2D bulletCollider;

    protected HashSet<EnemyDamage> enemyDamages = new HashSet<EnemyDamage>();
    protected virtual void Awake()
    {
        destroyTimer = destroyTime;
    }
    protected virtual void Update()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0) 
        {
            DestroyBullet();
            return;
        }
    }

    protected abstract void Shoot();

    protected virtual void Hit()
    {
        AudioSystem.PlayOneShot(hitClip);
    }
    protected virtual void DestroyBullet()
    {
        Destroy(gameObject);
    }
    protected virtual void OnDestroy()
    {
        Destroy(gameObject);
    }
}