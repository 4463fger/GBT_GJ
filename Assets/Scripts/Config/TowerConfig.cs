using System;
using UnityEngine;
[CreateAssetMenu(fileName = "TowerConfig", menuName = "Config/TowerConfig")]
[Serializable]
public class TowerConfig:ScriptableObject
{
    public int Coin;//所需消耗的金币   
    public string towerName;//塔的名字
    public string towerDescrption;//塔的描述
    public Sprite towerSprite;//塔的图标
}