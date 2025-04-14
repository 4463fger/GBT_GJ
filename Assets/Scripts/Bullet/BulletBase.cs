using System.Collections.Generic;
using JKFrame;
using UnityEngine;
using Enemy;

namespace Item.Bullet
{
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

        protected HashSet<IHurt> enemyDamages = new();

        protected virtual void Awake()
        {
            destroyTimer = destroyTime;
        }

        protected virtual void Update()
        {
            destroyTimer -= Time.deltaTime;
            if (destroyTimer <= 0) DestroyBullet();
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
}