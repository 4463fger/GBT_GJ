using System.Collections;
using Game;
using UnityEngine;
using JKFrame;
using Managers;
using TMPro;
using UI.Main;
using UnityEngine.UI;

namespace UI.Fight
{
    [UIWindowData(typeof(FightUI), false, "FightUI", 2)]
    public class FightUI : UI_WindowBase
    {
        // 战斗UI
        [SerializeField] private TextMeshProUGUI CoinText;
        [SerializeField] private TextMeshProUGUI EnemyWaveCountText;
        [SerializeField] private Transform SlotTransfrom;
        
        // 游戏UI
        [SerializeField] private Button Btn_Home;
        [SerializeField] private Button Btn_Paused;
        [SerializeField] private Button Btn_Gaming;

        public override void Init()
        {
            EventSystem.AddEventListener<bool>(Defines.CoinTextChange, CoinTextChange);
            EventSystem.AddEventListener<float,float>(Defines.WaveCountChange, EnemyWaveCountChange);
            
            Btn_Home.onClick.AddListener(OnReturnHomeClick);
            Btn_Paused.onClick.AddListener(OnContinueGame);
            Btn_Gaming.onClick.AddListener(OnPauseGame);
        }

        private void OnReturnHomeClick()
        {
            FightManager.Instance.UnInitFightManager();
            UISystem.Close<FightUI>();
            UISystem.Show<UIGameStartPanel>();
            SceneSystem.LoadScene("GameStart");
        }
        
        private void OnContinueGame()
        {
            Time.timeScale = 1;
            Btn_Paused.gameObject.SetActive(false);
        }
        
        private void OnPauseGame()
        {
            Time.timeScale = 0;
            Btn_Paused.gameObject.SetActive(true);
        }

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

        private void EnemyWaveCountChange(float waveCount,float waveTotalCount)
        {
            EnemyWaveCountText.text = $"{waveCount}/{waveTotalCount}";
            EnemyWaveCountText.fontStyle = FontStyles.Bold;
        }
        
        private void OnDestroy()
        {
            EventSystem.RemoveEventListener<bool>(Defines.CoinTextChange, CoinTextChange);
            EventSystem.RemoveEventListener<float,float>(Defines.WaveCountChange, EnemyWaveCountChange);
        }
    }
}