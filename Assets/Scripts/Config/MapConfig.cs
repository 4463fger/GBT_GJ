using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "MapConfig", menuName = "Config/MapConfig")]
    public class MapConfig : SerializedScriptableObject
    {
        [DictionaryDrawerSettings(KeyLabel = "关卡", ValueLabel = "网格信息")]
        public Dictionary<int, BlockMessage> Mapmessage;
    }

    [Serializable]
    public class BlockMessage
    {
        [DictionaryDrawerSettings(KeyLabel = "哪条路", ValueLabel = "路信息")]
        public Dictionary<int, List<Vector2>> Road;

        public List<Vector2> 障碍物;
        public Vector2 生成位置;
    }
}