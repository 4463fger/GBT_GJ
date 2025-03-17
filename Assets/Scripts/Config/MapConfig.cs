using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName ="MapConfig",menuName ="Config/MapConfig")]
public class MapConfig : SerializedScriptableObject
{
    [DictionaryDrawerSettings (KeyLabel = "�ؿ�",ValueLabel = "������Ϣ")]
    public Dictionary<int, BlockMessage> Mapmessage;
}

[Serializable]
public class BlockMessage
{
    [DictionaryDrawerSettings (KeyLabel = "����·",ValueLabel = "·��Ϣ")]
    public Dictionary<int,List<Vector2>> Road;
    public List<Vector2> �ϰ���;
    public Vector2 ����λ��;
}