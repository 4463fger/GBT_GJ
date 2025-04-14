using UnityEngine;

namespace Buff
{
    public enum BuffUpdateTimeEnum
    {
        Add,
        Replace,
        Keep
    }

    public enum BuffRemoveStackUpdateEnum
    {
        Clear,
        Reduce
    }

    public class BuffInfo
    {
        public BuffData buffData;
        public GameObject createor;
        public GameObject target;
        public float durationTimer;
        public float tickTimer;
        public int curStack;
    }

    public class DamageInfo
    {
    }
}