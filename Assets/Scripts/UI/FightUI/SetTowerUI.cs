
using JKFrame;
using UnityEngine;
using UnityEngine.UI;
public class SetTowerUI : UI_WindowBase
{
    [SerializeField] private Button buyTowerButton;
    [SerializeField] private Button cancelButton;

    private void OnbuyTowerButtonClick()
    {
        //TODO:���ϵͳ�Ƿ��м۸���
    }
    private void OncancelTowerButtonClick() 
    {
        UISystem.Close<SetTowerUI>();
    }
}
