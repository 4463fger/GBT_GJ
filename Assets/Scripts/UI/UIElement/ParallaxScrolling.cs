/*
* ┌──────────────────────────────────┐
* │  描    述: 滚动视图                      
* │  类    名: ParallaxScrolling.cs       
* │  创    建: By 4463fger                     
* └──────────────────────────────────┘
*/

using UnityEngine;

namespace UI.UIElement
{
    [RequireComponent(typeof(RectTransform))]
    public class ParallaxScrolling : MonoBehaviour
    {
        [Range(0, 1)] 
        [Tooltip("移动权重,数值越大，移动越快")]
        [SerializeField] private float Weight; // 1表示与基础速度完全同步，0表示静止
        [SerializeField] private float speed; // 基础移动速度
        
        private RectTransform rectTransform;
        private float originalX; // 初始X坐标
        
        public void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            originalX = rectTransform.anchoredPosition.x;
            Debug.Log(originalX);
        }
        
        private void Update()
        {
            // 更新位置
            rectTransform.anchoredPosition += Vector2.right * (speed * Weight * Time.deltaTime);
            if (rectTransform.anchoredPosition.x > originalX + rectTransform.rect.width)
            {
                rectTransform.anchoredPosition = new Vector2(
                    originalX - rectTransform.rect.width,
                    rectTransform.anchoredPosition.y);
            }
            else if (rectTransform.anchoredPosition.x < originalX - rectTransform.rect.width)
            {
                rectTransform.anchoredPosition = new Vector2(originalX + rectTransform.rect.width, rectTransform.anchoredPosition.y);
            }
        }
    }
}