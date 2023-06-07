using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace CounterApp
{
    public class CounterAppController : MonoBehaviour
    {
        private int m_nCount = 0;

        public int Count
        {
            get => m_nCount;
            set
            {
                m_nCount = Math.Max(0, value);
                ShowCount();
            }
        }

        public UnityEngine.UI.Button m_btnAdd;
        public UnityEngine.UI.Button m_btnSub;
        public TMP_Text m_txtCount;

        void Awake()
        {
            if (m_btnAdd != null)
            {
                m_btnAdd.onClick.RemoveAllListeners();
                m_btnAdd.onClick.AddListener(OnClick_Add);
            }

            if (m_btnSub != null)
            {
                m_btnSub.onClick.RemoveAllListeners();
                m_btnSub.onClick.AddListener(OnClick_Sub);
            }
        }

        public void OnEnable()
        {
            ShowCount();
        }

        public void OnClick_Add()
        {
            Count++;
            // ShowCount();
        }

        public void OnClick_Sub()
        {
            Count--;
            // ShowCount();
        }

        public void ShowCount()
        {
            if (m_txtCount != null)
            {
                m_txtCount.text = Count.ToString();
            }
        }
    }
}
