using UnityEngine;

public class TowerBase : MonoBehaviour
{
    protected float attackRadius;//�����뾶

    protected float attackInterval;//�������

    protected float attackDamage;//�����˺�

    protected float attackTimer;//������ʱ��

    protected virtual void Awake()
    {
        attackTimer = attackInterval;
    }
}
