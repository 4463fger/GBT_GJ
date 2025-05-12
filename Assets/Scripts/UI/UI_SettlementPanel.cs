using JKFrame;
using Managers;
using TalentTree;
using TMPro;
using UI.Fight;
using UI.Main;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [UIWindowData(typeof(UI_SettlementPanel),false,"UI_SettlementPanel",3)]
    public class UI_SettlementPanel : UI_WindowBase
    {
        [SerializeField] private Button quitButton;
        [SerializeField] private TextMeshProUGUI resultText;
        [SerializeField] private Transform rewardTf;

        [SerializeField] private GameObject rewardGameobject;
        
        public override void Init()
        {
            quitButton.onClick.AddListener(OnQuitButtonClick);
        }
        
        private void SetText(bool isWin)
        {
            resultText.text = isWin ? "Victory" : "Loss";
            if (isWin)
            {

            }
        }

        private void ShowReward()
        {
            //先初始化天赋点的，后面再说
            GameObject reward = Instantiate(rewardGameobject, rewardTf);
            reward.GetComponent<RewardGameobject>().InitReward
            (TalentTreeManager.Instance.talentsPointIcon,
                TalentTreeManager.Instance.GetPoints(GameManager.Instance.currentLevel));

        }

        private void OnQuitButtonClick()
        {
            FightManager.Instance.UnInitFightManager();
            UISystem.Close<FightUI>();
            UISystem.Close<UI_SettlementPanel>();
            UISystem.Show<UIBackGroundPanel>();
            UISystem.Show<UIGameStartPanel>();
            SceneSystem.LoadScene("GameStart");
        }
    }
}