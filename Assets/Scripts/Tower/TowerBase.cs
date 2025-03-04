using UnityEngine;
/// <summary>
/// 塔的基类
/// </summary>
public class TowerBase : MonoBehaviour
{
    protected float gridLength;//砖块的大小，用于计算攻击距离

    [SerializeField]protected LayerMask enemyLayer;//敌人层

    [Header("塔的数据")]
    protected float attackRadius;//攻击半径

    protected float attackInterval;//攻击间隔

    protected float attackDamage;//攻击伤害

    protected float attackTimer;//攻击计时器

    protected GameObject Bullet;//塔的子弹


    protected virtual void Awake()
    {
        attackTimer = attackInterval;
    }

    protected virtual void Update()
    {
        if(isHaveEnemy())
        attackTimer -= Time.deltaTime;
    }
    protected bool isTimeEnd()
    {
        return attackTimer == attackInterval;
    }

    protected Collider2D[] getEnemyCollider()
    {
        return Physics2D.OverlapCircleAll(gameObject.transform.position, attackRadius * gridLength, enemyLayer);
    }

    protected bool isHaveEnemy()
    {
        return getEnemyCollider().Length > 0;
    }
}
