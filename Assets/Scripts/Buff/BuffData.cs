using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="BuffData",menuName ="Config/BuffData")]
public class BuffData : ScriptableObject
{
    [Header("基本信息")]
    public int id;
    public string buffName;
    public string description;
    public Sprite icon;
    public int priority;
    public int maxStack;
    public string[] tags;
    [Header("时间信息")]
    public bool isForever;
    public float duration;
    public float tickTime;
    [Header("更新方式")]
    public BuffUpdateTimeEnum buffUpdateTime;
    public BuffRemoveStackUpdateEnum buffRemoveStackUpdate;
    [Header("基础回调点")]
    public BaseBuffModule OnCreate;
    public BaseBuffModule OnRemove;
    public BaseBuffModule OnTick;
    [Header("伤害回调点")]
    public BaseBuffModule OnHit;
    public BaseBuffModule OnBehurt;
    public BaseBuffModule OnKill;
    public BaseBuffModule OnBeKill;
}
