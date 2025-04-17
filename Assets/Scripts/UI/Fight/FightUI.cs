using System.Collections;
using UnityEngine;
using JKFrame;
using Managers;
using TMPro;

namespace UI.Fight
{
    [UIWindowData(typeof(FightUI), true, "Prefabs/UI/FightUI", 2)]
    public class FightUI : UI_WindowBase
    {
        [SerializeField] private TextMeshProUGUI CoinText;

        [SerializeField] private TextMeshProUGUI EnemyWaveCountText;

        [SerializeField] private Transform SlotTransfrom;

        private void CoinTextChange(bool isCanBuy)
        {
            if (isCanBuy)
            {
                //TODO:更新金币UI
            }
            else
            {
                StartCoroutine(BuyLoss());
            }
        }

        private IEnumerator BuyLoss()
        {
            int i = 3;
            Color originTextColor = CoinText.color;
            while (i > 0)
            {
                CoinText.color = Color.red;
                yield return new WaitForSeconds(0.5f);
                CoinText.color = originTextColor;
                i--;
            }

        }

        private void EnemyWaveCountChange()
        {

        }

        private void Start()
        {
            EventSystem.AddEventListener<bool>("CoinTextChange", CoinTextChange);
            EventSystem.AddEventListener("EnemyWaveCountChange", EnemyWaveCountChange);
        }

        private void OnDestroy()
        {
            EventSystem.RemoveEventListener<bool>("CoinTextChange", CoinTextChange);
            EventSystem.RemoveEventListener("EnemyWaveCountChange", EnemyWaveCountChange);
        }
    }
}