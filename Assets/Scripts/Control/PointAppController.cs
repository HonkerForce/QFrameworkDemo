using System.Collections.Generic;
using System.Linq;
using CounterApp;
using QFramework.Example;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using QFrameworkTest;

namespace PointApp
{
    public class PointAppController : MonoBehaviour
    {
        public Camera m_MainCamera;
        public Canvas m_MainCanvas = null;
        public Button startBtn = null;
        public TextMeshProUGUI m_btnText = null;
        public GameObject m_CubeParentObj = null;
        private List<BoxCollider> m_Cubes = null;

        void Awake()
        {
            if (m_CubeParentObj == null)
            {
                Debug.Log("Cube父节点为空");
                return;
            }

            m_Cubes = m_CubeParentObj.GetComponentsInChildren<BoxCollider>().ToList();

            if (startBtn != null)
            {
                startBtn.onClick.AddListener(() =>
                {
                    new PointStartCommand().Execute();
                });
            }

            GameStartEvent.RegisterTrigger(OnGameStart);

            GamePassEvent.RegisterTrigger(OnGamePass);
            
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
                        hit.transform.gameObject.SetActive(false);
                        
                        new CubeKilledCommand().Execute();
                    }
                }
            }
        }

        void OnDestroy()
        {
            GameStartEvent.UnRegisterTrigger(OnGameStart);

            GamePassEvent.UnRegisterTrigger(OnGamePass);
            
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

            PointAppModel.Instance.count.Value = 0;
        }

        private void OnGameStart()
        {
            InitCube();

            if (m_MainCanvas != null)
            {
                m_MainCanvas.gameObject.SetActive(false);
            }
        }

        private void OnGamePass()
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