using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameStart
{
    public class UI_AchievementItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI Name;
        [SerializeField] private TextMeshProUGUI Des;
        [SerializeField] private Image Icon;
        
        [SerializeField] private Image Mask;

        public string Id { get; private set; }

        public void InitAchievementItemData(string id ,string name, string des , Sprite icon , bool unLocked)
        {
            this.Id = id;
            Name.text = name;
            Des.text = des;
            Icon.sprite = icon;
            IsUnLocked(unLocked);
        }

        public void IsUnLocked(bool isUnLocked)
        {
            if (isUnLocked == true)
            {
                Mask.gameObject.SetActive(false);
            }
            else
            {
                Mask.gameObject.SetActive(true);
            }
        }
    }
}