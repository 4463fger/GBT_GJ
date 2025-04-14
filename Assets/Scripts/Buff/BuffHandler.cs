using System.Collections.Generic;
using UnityEngine;

namespace Buff
{
    public class BuffHandler : MonoBehaviour
    {
        public LinkedList<BuffInfo> buffList = new();

        public void AddBuff(BuffInfo buffInfo)
        {
            var findBuffInfo = FindBuff(buffInfo.buffData.id);
            if (findBuffInfo != null)
            {
                //buff存在
                if (findBuffInfo.curStack < findBuffInfo.buffData.maxStack)
                {
                    findBuffInfo.curStack++;
                    switch (findBuffInfo.buffData.buffUpdateTime)
                    {
                        case BuffUpdateTimeEnum.Add:
                            findBuffInfo.durationTimer += findBuffInfo.buffData.duration;
                            break;
                        case BuffUpdateTimeEnum.Replace:
                            findBuffInfo.durationTimer = findBuffInfo.buffData.duration;
                            break;
                    }

                    findBuffInfo.buffData.OnCreate.Apply(findBuffInfo);
                }
                else
                {
                    buffInfo.durationTimer = findBuffInfo.buffData.duration;
                    buffInfo.buffData.OnCreate.Apply(buffInfo);
                    buffList.AddLast(buffInfo);
                    InsertionSortLinkedList(buffList);
                }
            }
        }

        public void RemoveBuff(BuffInfo buffInfo)
        {
            switch (buffInfo.buffData.buffRemoveStackUpdate)
            {
                case BuffRemoveStackUpdateEnum.Clear:
                    buffInfo.buffData.OnRemove.Apply(buffInfo);
                    buffList.Remove(buffInfo);
                    break;
                case BuffRemoveStackUpdateEnum.Reduce:
                    buffInfo.curStack--;
                    buffInfo.buffData.OnRemove.Apply(buffInfo);
                    if (buffInfo.curStack == 0)
                        buffList.Remove(buffInfo);
                    else
                        buffInfo.durationTimer = buffInfo.buffData.duration;
                    break;
            }
        }

        private void InsertionSortLinkedList(LinkedList<BuffInfo> list)
        {
            if (list == null || list.First == null) return;
            var current = list.First.Next;
            while (current != null)
            {
                var next = current.Next;
                var prev = current.Previous;
                while (prev != null && prev.Value.buffData.priority > current.Value.buffData.priority)
                    prev = prev.Previous;
                if (prev == null)
                {
                    list.Remove(current);
                    list.AddFirst(current);
                }
                else
                {
                    list.Remove(current);
                    list.AddAfter(prev, current);
                }

                current = current.Next;
            }
        }

        private BuffInfo FindBuff(int buffDataID)
        {
            foreach (var buffInfo in buffList)
                if (buffInfo.buffData.id == buffDataID)
                    return buffInfo;

            return default;
        }


        private void BuffTickAndRemove()
        {
            var deleteBuffList = new List<BuffInfo>();
            foreach (var buffInfo in buffList)
            {
                if (buffInfo.buffData.OnTick != null)
                {
                    if (buffInfo.tickTimer < 0)
                    {
                        buffInfo.buffData.OnTick.Apply(buffInfo);
                        buffInfo.tickTimer = buffInfo.buffData.tickTime;
                    }
                    else
                    {
                        buffInfo.tickTimer -= Time.deltaTime;
                    }
                }

                if (buffInfo.durationTimer < 0)
                    deleteBuffList.Add(buffInfo);
                else
                    buffInfo.durationTimer -= Time.deltaTime;
            }

            foreach (var buffInfo in deleteBuffList) RemoveBuff(buffInfo);
        }

        private void Update()
        {
            BuffTickAndRemove();
        }
    }
}