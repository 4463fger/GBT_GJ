/*
* ┌──────────────────────────────────┐
* │  描    述: 帮助面板页面                      
* │  类    名: UIHelpPanel.cs       
* │  创    建: By 4463fger                     
* └──────────────────────────────────┘
*/

using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Main
{
    public class UIHelpPanel : MonoBehaviour
    {
        private CanvasGroup m_CanvansGroup;
        [SerializeField] private Button Btn_Close;

        public void Init()
        {
            m_CanvansGroup = GetComponent<CanvasGroup>();
            m_CanvansGroup.alpha = 0;
            Btn_Close.onClick.AddListener(OnHide);
        }

        public void OnShow()
        {
            m_CanvansGroup
                .DOFade(1f, 0.5f)
                .SetEase(Ease.InQuad);
            gameObject.SetActive(true);
        }

        public void OnHide()
        {
            m_CanvansGroup
                .DOFade(0f, 0.5f)
                .SetEase(Ease.InQuad);;
            gameObject.SetActive(false);
        }
    }
}