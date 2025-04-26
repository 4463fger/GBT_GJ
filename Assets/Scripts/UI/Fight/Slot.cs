using Config;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    [SerializeField] private Button SelectedButton;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Image towerIcon;
    public void Init(TowerConfig towerConfig)
    {
        coinText.text = towerConfig.Coin.ToString();
        towerIcon.sprite = towerConfig.towerSprite;
    }
    private void CanbeMake()
    {
        //if(true)
        //{
        //    gameObject.GetComponent<Image>().color=new Color(1f,1f,1f,0.7f);
        //    SelectedButton.enabled = false;
        //}
        //else
        //{
        //    gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        //    SelectedButton.enabled = true;
        //}
    }
    private void Update()
    {
        CanbeMake();
    }
    public void OnSelectButtonClick()
    {

    }

}
