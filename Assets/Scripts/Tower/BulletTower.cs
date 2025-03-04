﻿using UnityEngine;
/// <summary>
/// 子弹塔
/// </summary>
public class BulletTower : TowerBase
{
    

    private void Attack()
    {
        GameObject bullet=Instantiate(Bullet);
        bullet.transform.up = getEnemyCollider()[0].gameObject.transform.position;
    }

    protected override void Update()
    {
        base.Update();
        if(isTimeEnd()&&isHaveEnemy())
        {
            Attack();
            return;
        }
    }
}