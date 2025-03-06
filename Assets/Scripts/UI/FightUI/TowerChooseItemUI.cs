using JKFrame;
using UnityEngine;
using UnityEngine.EventSystems;
public class TowerChooseItemUI : UI_WindowBase
{
    [SerializeField] private GameObject emptySlot;
    [SerializeField] private Transform slotTransform;
    public static int maxEmptyCount = 9;//可选塔的界面的最大空格数量
    private SlotBase[] slots=new SlotBase[maxEmptyCount];
    public void OnPointerClick(PointerEventData eventData)
    {

    }


    public void CreateSlot()
    {
        for(int i = 0; i < maxEmptyCount; i++) 
        {
            GameObject slot=Instantiate(emptySlot, slotTransform);
            slots[i]=(slot.GetComponent<SlotBase>());
        }
    }
}
