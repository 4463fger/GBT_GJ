using UnityEngine;
using JKFrame;
using Config;
using ManagerScene;

[UIWindowData(typeof(UI_SetTower), true, "UI_SetTower", 4)]
public class UI_SetTower : UI_WindowBase
{
    [SerializeField] private RectTransform rectTf;
    [SerializeField] private Transform TowerTf;
    [SerializeField] private GameObject emptySlot;
    private TowerConfig[] towerConfigs;
    public void InitSetTower()
    {
        towerConfigs=new TowerConfig[FightManager.Instance.towerConfigList.Count];
        for (int i = 0; i < FightManager.Instance.towerConfigList.Count; i++)
        {
            towerConfigs[i] = FightManager.Instance.towerConfigList[i];
            GameObject Tower = Instantiate(emptySlot, TowerTf);
            //Tower?.GetComponent<SlotBase>().Init(FightManager.Instance.towerConfigList[i]);
        }
    }
    public void Start()
    {
        InitSetTower();
    }
    public void Show(Vector3 pos)
    {
        float offset = 50;
        Vector3 UIPos=Camera.main.WorldToViewportPoint(pos);
        Vector2 screenPosition = new Vector2((UIPos.x * Screen.width)-960,(UIPos.y * Screen.height)-540+offset);
        rectTf.anchoredPosition = screenPosition;
        
    }
}
