using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.UIElement
{
    public class ScrollViewController : MonoBehaviour,IBeginDragHandler,IEndDragHandler
    {
        private float contentLength; // 容器长度
        private float beginMousePositionX;
        private float endMousePositionX;
        private ScrollRect _scrollRect;
        private float lastProportion; // 上一个位置比例

        public int cellLength;
        public int spacing;
        public int leftOffset;

        private float upperLimit; // 上限值
        private float lowerLimit; // 下限值
        private float firstItemLength; // 移动第一个单元格的距离
        private float oneItemLength; 
        private float oneItemProportion; // 一个单元格所占的比例

        public int totalItemNum; // 单元格个数
        public int currentIndex; // 当前单元格索引
        
        public TextMeshProUGUI LevelText;

        private void Awake()
        {
            _scrollRect = GetComponent<ScrollRect>();
            contentLength = _scrollRect.content.rect.xMax - 2 * leftOffset - cellLength;
            firstItemLength = cellLength / 2 + leftOffset;
            oneItemLength = cellLength + spacing;
            oneItemProportion = oneItemLength / contentLength;
            upperLimit = 1 - firstItemLength / contentLength;
            lowerLimit = firstItemLength / contentLength;
            currentIndex = 1;
            _scrollRect.horizontalNormalizedPosition = 0;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            float offsetX = 0;
            endMousePositionX = Input.mousePosition.x;
            offsetX = (beginMousePositionX - endMousePositionX) * 2;
            if (Mathf.Abs(offsetX) > firstItemLength)
            {
                if (offsetX > 0) // 右滑
                {
                    if (currentIndex >= totalItemNum)
                    {
                        return;
                    }
                    // 可以移动的格子数目
                    int moveCount = 
                        (int)((offsetX - firstItemLength)/oneItemLength) + 1;
                    currentIndex += moveCount;

                    if (currentIndex >= totalItemNum)
                    {
                        currentIndex = totalItemNum;
                    }
                    // 档次需要移动的比例
                    lastProportion += oneItemProportion * moveCount;
                    if (lastProportion >= upperLimit)
                    {
                        lastProportion = 1;
                    }
                }
                else // 左滑
                {
                    if (currentIndex <= 1)
                    {
                        return;
                    }
                    // 可以移动的格子数目
                    int moveCount = 
                        (int)((offsetX + firstItemLength)/oneItemLength) - 1;
                    currentIndex += moveCount;

                    if (currentIndex <= 1)
                    {
                        currentIndex = 1;
                    }
                    
                    // 档次需要移动的比例
                    lastProportion += oneItemProportion * moveCount;
                    if (lastProportion <= lowerLimit)
                    {
                        lastProportion = 0;
                    }
                }
            }
            
            DOTween.To(() => 
                _scrollRect.horizontalNormalizedPosition
                ,lerpValue => _scrollRect.horizontalNormalizedPosition = lerpValue
                ,lastProportion,
                0.5f)
                .SetEase(Ease.OutQuad);

            LevelText.text = $"Level:{currentIndex}";
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            beginMousePositionX = Input.mousePosition.x;
        }
    }
}