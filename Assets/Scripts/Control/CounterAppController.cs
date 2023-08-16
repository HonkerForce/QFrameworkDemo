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
            
            CounterGame.Get<ICounterAppModel>().count.OnValueChanged += ShowCount;
        }

        public void OnEnable()
        {
            // ShowCount(0);
        }

        public void OnDestroy()
        {
            CounterGame.Get<ICounterAppModel>().count.OnValueChanged -= ShowCount;
        }

        public void ShowCount(int count)
        {
            if (m_txtCount != null)
            {
                m_txtCount.text = count.ToString();
            }
        }
    }
}
