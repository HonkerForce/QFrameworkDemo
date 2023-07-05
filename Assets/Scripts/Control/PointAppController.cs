using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace CounterApp
{
    public class PointAppController : MonoBehaviour
    {
        public Camera m_MainCamera;
        public Canvas m_MainCanvas = null;
        public TextMeshProUGUI m_btnText = null;
        public GameObject m_CubeParentObj = null;
        private List<BoxCollider> m_Cubes = null;
        private bool m_bStart = false;
        private int m_nCount = 0;

        private int m_nEndCount = 0;

        void Awake()
        {
            if (m_CubeParentObj == null)
            {
                Debug.Log("Cube父节点为空");
                return;
            }

            m_Cubes = m_CubeParentObj.GetComponentsInChildren<BoxCollider>().ToList();
            if (m_Cubes != null)
            {
                m_nEndCount = m_Cubes.Count;
            }
        }
        
        void Start()
        {
            if (m_MainCanvas != null)
            {
                m_MainCanvas.gameObject.SetActive(true);
                
                if (m_btnText != null)
                {
                    m_btnText.text = "Start";
                }
            }
        }

        void Update()
        {
            if (m_MainCamera != null && Input.GetMouseButtonUp(0))
            {
                RaycastHit hit;
                Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform != null)
                    {
                        OnClicked_Cube((RectTransform)hit.transform);
                    }
                }
            }
        }

        void InitCube()
        {
            if (m_Cubes != null)
            {
                foreach (var cube in m_Cubes)
                {
                    cube.gameObject.SetActive(true);
                }
            }

            m_nCount = 0;
        }

        public void OnClicked_StartBtn()
        {
            InitCube();

            if (m_MainCanvas != null)
            {
                m_MainCanvas.gameObject.SetActive(false);
            }
        }

        public void OnClicked_Cube(RectTransform cube)
        {
            if (cube != null)
            {
                m_nCount++;
                cube.gameObject.SetActive(false);
            }

            if (m_nCount >= m_nEndCount)
            {
                if (m_MainCanvas != null)
                {
                    m_MainCanvas.gameObject.SetActive(true);

                    if (m_btnText != null)
                    {
                        m_btnText.text = "Again";
                    }
                }
            }
        }
    }
}