using JKFrame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_SettlementPanel:UI_WindowBase
{
    [SerializeField] private Button quitButton;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Transform rewardTf;

    [SerializeField] private GameObject rewardGameobject;

    private void SetText(bool isWin)
    {
        resultText.text = isWin ? "Victory" : "Loss";
        if(isWin)
        {

        }
    }
    private void ShowReward()
    {
        //先初始化天赋点的，后面再说
        GameObject reward=Instantiate(rewardGameobject,rewardTf);
        reward.GetComponent<RewardGameobject>().InitReward
            (TalentTreeManager.Instance.talentsPointIcon,TalentTreeManager.Instance.GetPoints(GameManager.Instance.currentLevel));
        
    }
    private void OnQuitButtonClick()
    {
        //执行事件监听：加关卡等级，获得奖励

    }
    private void Start()
    {
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }
}