using UnityEngine.EventSystems;
using UnityEngine;
using JKFrame;
using UnityEngine.UI;
public class SlotBase : MonoBehaviour, IPointerClickHandler ,IPointerEnterHandler,IPointerExitHandler
{ 
    [SerializeField]private Image slotImage;
    [SerializeField] private Image selectedImage;
    public void OnPointerClick(PointerEventData eventData)
    {
        UISystem.GetWindow<SetTowerUI>();
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
