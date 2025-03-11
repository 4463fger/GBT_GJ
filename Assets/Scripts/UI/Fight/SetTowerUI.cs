using JKFrame;
using TMPro;
using UnityEngine;
public class SetTowerUI:UI_WindowBase
{
    [SerializeField] private Transform SlotTransfrom;
    [SerializeField] private TextMeshProUGUI CoinText;
    [SerializeField] private GameObject emptySlot;
    private TowerConfig[] towerConfigs = new TowerConfig[6];
    public void InitTowerConfigs()
    {
        for(int i = 0;i<6;i++)
        {
            if(i<FightManager.Instance.towerConfigList.Count)
            {
                print("现在是第"+i+"个笼子");
                towerConfigs[i] = FightManager.Instance.towerConfigList[i];
                GameObject Tower=Instantiate(emptySlot, SlotTransfrom);
                Tower?.GetComponent<SlotBase>().Init(FightManager.Instance.towerConfigList[i]);
            }
            else
            {
                towerConfigs[i] = null;
                GameObject Tower = Instantiate(emptySlot, SlotTransfrom);
                Tower?.GetComponent<SlotBase>().Init(null);
            }
        }
    }
    private void Start()
    {
        InitTowerConfigs();
    }



}