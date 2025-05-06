using JKFrame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RewardGameobject:UI_WindowBase
{
    [SerializeField] private TextMeshProUGUI rewardCount;
    public Image rewardIcon;

    public void InitReward(Sprite sprite,int count)
    {
        rewardCount.text = count.ToString();
        rewardIcon.sprite = sprite;
    }
}