using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="BuffData",menuName ="Config/BuffData")]
public class BuffData : ScriptableObject
{
    [Header("������Ϣ")]
    public int id;
    public string buffName;
    public string description;
    public Sprite icon;
    public int priority;
    public int maxStack;
    public string[] tags;
    [Header("ʱ����Ϣ")]
    public bool isForever;
    public float duration;
    public float tickTime;
    [Header("���·�ʽ")]
    public BuffUpdateTimeEnum buffUpdateTime;
    public BuffRemoveStackUpdateEnum buffRemoveStackUpdate;
    [Header("�����ص���")]
    public BaseBuffModule OnCreate;
    public BaseBuffModule OnRemove;
    public BaseBuffModule OnTick;
    [Header("�˺��ص���")]
    public BaseBuffModule OnHit;
    public BaseBuffModule OnBehurt;
    public BaseBuffModule OnKill;
    public BaseBuffModule OnBeKill;
}
