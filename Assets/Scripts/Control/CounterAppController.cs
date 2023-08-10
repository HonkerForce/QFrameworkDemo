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
        public UnityEngine.UI.Button m_btnAdd;
        public UnityEngine.UI.Button m_btnSub;
        public TMP_Text m_txtCount;

        void Awake()
        {
            if (m_btnAdd != null)
            {
                m_btnAdd.onClick.RemoveAllListeners();
                m_btnAdd.onClick.AddListener(() =>
                {
                    new CountAddCommand().Execute();
                });
            }

            if (m_btnSub != null)
            {
                m_btnSub.onClick.RemoveAllListeners();
                m_btnSub.onClick.AddListener(() =>
                {
                    new CountSubCommand().Execute();
                });
            }
            
            CounterAppModel.Instance.count.OnValueChanged += ShowCount;
        }

        public void OnEnable()
        {
            ShowCount();
        }

        public void OnDestroy()
        {
            CounterAppModel.Instance.count.OnValueChanged -= ShowCount;
        }

        public void ShowCount()
        {
            if (m_txtCount != null)
            {
                m_txtCount.text = CounterAppModel.Instance.count.Value.ToString();
            }
        }
    }
}
