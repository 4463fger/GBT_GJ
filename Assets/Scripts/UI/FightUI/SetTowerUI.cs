
using JKFrame;
using UnityEngine;
using UnityEngine.UI;
public class SetTowerUI : UI_WindowBase
{
    [SerializeField] private Button buyTowerButton;
    [SerializeField] private Button cancelButton;

    private void OnbuyTowerButtonClick()
    {
        //TODO:金币系统是否有价格购买
    }
    private void OncancelTowerButtonClick() 
    {
        UISystem.Close<SetTowerUI>();
    }
}
