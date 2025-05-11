/*
* ┌──────────────────────────────────┐
* │  描    述: 帮助面板页面                      
* │  类    名: UIHelpPanel.cs       
* │  创    建: By 4463fger                     
* └──────────────────────────────────┘
*/

using System;
using DG.Tweening;
using JKFrame;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Main
{
    public class UIHelpPanel : MonoBehaviour
    {
        private CanvasGroup m_CanvansGroup;
        [SerializeField] private Button Btn_Close;

        private AudioClip cancelAudioClip;
        public void Init()
        {
            cancelAudioClip = ResSystem.LoadAsset<AudioClip>("Cancel");

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
            AudioSystem.PlayOneShot(cancelAudioClip);
            
            m_CanvansGroup
                .DOFade(0f, 0.5f)
                .SetEase(Ease.InQuad)
                .OnComplete(() =>
                    {
                        gameObject.SetActive(false);
                    }
                );
        }
    }
}