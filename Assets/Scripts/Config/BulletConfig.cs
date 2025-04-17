using UnityEngine;

namespace Config
{
    public class BulletConfig : ScriptableObject
    {
        public float[] bulletDamage = new float[3];
        public float destroyTime;
        public float destroyTimer;
        public AudioClip hitClip;
    }
}