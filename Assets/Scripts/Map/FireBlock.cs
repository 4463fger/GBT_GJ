﻿using System.Collections.Generic;
using UnityEngine;

public class FireBlock:MonoBehaviour
{
    private float Damage;
    private float destroyTime;
    private float destroyTimer;
    private int destroyCount;
    private Dictionary<EnemyDamage, int> damages;
    public void InitBlock(float Damage,float destroyTime,int destroyCount)
    { 
        this.Damage = Damage;
        this.destroyTime = destroyTime;
        destroyTimer = destroyTime;
        this.destroyCount = destroyCount;
    }
    private void Update()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            EnemyDamage enemyDamage = collision.gameObject.GetComponent<EnemyDamage>();
            
        }
    }
}