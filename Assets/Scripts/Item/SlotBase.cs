using UnityEngine.EventSystems;
using UnityEngine;
using JKFrame;
using UnityEngine.UI;
using TMPro;
public class SlotBase : MonoBehaviour, IPointerClickHandler ,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI CostText;
    [SerializeField] private Image towerImage;
    [SerializeField] private Image selectedImage;
    [SerializeField] private Image nullImage;
    [SerializeField] private TowerConfig towerConfig;
    private bool isInteractable=true;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(isInteractable)
        {

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isInteractable) 
        {
            selectedImage.gameObject.SetActive(true);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(isInteractable) 
        {
            selectedImage.gameObject.SetActive(false);
        }
        
    }
    public void Init(TowerConfig towerConfig)
    {
        if(towerConfig != null)
        {
            this.towerConfig = towerConfig;
            CostText.text = towerConfig.Coin.ToString();
            towerImage.sprite = towerConfig.towerSprite;
        }
        else if(towerConfig==null) 
        {
            nullImage.gameObject.SetActive(true);
            towerImage.gameObject.SetActive(false);
            selectedImage.gameObject.SetActive(false);
            CostText.gameObject.SetActive(false);
            isInteractable = false;
        }
        
    }
}
