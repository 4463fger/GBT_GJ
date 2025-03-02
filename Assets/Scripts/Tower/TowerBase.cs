using UnityEngine;
/// <summary>
/// ���Ļ���
/// </summary>
public class TowerBase : MonoBehaviour
{
    protected float gridLength;//ש��Ĵ�С�����ڼ��㹥������

    [SerializeField]protected LayerMask enemyLayer;//���˲�

    [Header("��������")]
    protected float attackRadius;//�����뾶

    protected float attackInterval;//�������

    protected float attackDamage;//�����˺�

    protected float attackTimer;//������ʱ��

    protected GameObject Bullet;//�����ӵ�


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
