using System;
using DG.Tweening;
using JKFrame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Achievement
{
    [UIWindowData(typeof(AchievementPopup),true,"AchievementPopup",4)]
    public class AchievementPopup : UI_WindowBase
    {
        private TextMeshProUGUI _text;
        private Image _image;
        public Action _onComplete;

        public override void Init()
        {
            _text = transform.Find("Name").GetComponent<TextMeshProUGUI>();
            _image = transform.Find("Icon").GetComponent<Image>();
        }

        public void Initialize(string text, Sprite sprite ,Action action = null)
        {
            _text.text = text;
            _image.sprite = sprite;
            _onComplete = action;
        }
        
        public void ShowAnimation()
        {
            // 记录初始位置
            Vector3 originalPos = transform.localPosition;
            
            // 创建动画序列
            Sequence sequence = DOTween.Sequence();
            // 第一阶段：向上移动（假设移动到Y+100位置）
            sequence.Append(transform.DOLocalMoveY(originalPos.y + 150f, 0.5f)
                .SetEase(Ease.OutQuad));
            
            // 停留1秒
            sequence.AppendInterval(2f);
            // 第二阶段：返回原位
            sequence.Append(transform.DOLocalMoveY(originalPos.y, 0.5f)
                .SetEase(Ease.InQuad));
            
            // 动画完成后销毁
            sequence.OnComplete(() => {
                _onComplete?.Invoke();
                _onComplete = null;
            });
        }
    }
}