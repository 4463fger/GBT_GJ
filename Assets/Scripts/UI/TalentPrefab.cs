using JKFrame;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Game;
public class TalentPrefab : UI_WindowBase,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private Image selectedImage;
    public TalentDataConfig currentTalent
    {
        get;
        private set;
    }
    [SerializeField] private Image talentIcon;
    public void InitPrefab(TalentDataConfig talentDataConfig, float x,float y)
    {
        currentTalent= talentDataConfig;
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        talentIcon.sprite = currentTalent.talentSprite;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        JKFrame.EventSystem.EventTrigger<TalentDataConfig>(Defines.SetDescription,currentTalent);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selectedImage.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selectedImage.gameObject.SetActive(false);
    }
}
