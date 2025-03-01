using UnityEngine;

public class BulletTower:TowerBase
{
    public GameObject Bullet;

    private void Update()
    {
    }

    private void Attack()
    {
        attackTimer-= Time.deltaTime;
        
    }
}