using JKFrame;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightUI:UI_WindowBase
{
    public TextMeshProUGUI coinText;
    public Button pauseButton;

    private void OnPauseButtonClick()
    {

    }

    private void SetCoin(int Coin)
    {
        coinText.text = Coin.ToString();
    }

    private IEnumerable ChangeCoin(bool isCanChange)
    {
        int coinIndex = 0;
        Color textOriginColor=coinText.color;
        if(isCanChange) 
        {
            while(coinIndex<3)
            {
                coinText.color = Color.red;
                yield return new WaitForSeconds(1);
                coinText.color = textOriginColor;
                coinIndex++;
            }
            
        }
        else
        {
            while (coinIndex < 3)
            {
                coinText.color = Color.green;
                yield return new WaitForSeconds(1);
                coinText.color = textOriginColor;
                coinIndex++;
            }
        }
    }

    private void Start()
    {
        pauseButton.onClick.AddListener(OnPauseButtonClick);
        EventSystem.AddEventListener<int>("CoinChange",SetCoin);
    }

    private void OnDestroy()
    {
        EventSystem.RemoveEventListener<int>("CoinChange", SetCoin);
    }
}