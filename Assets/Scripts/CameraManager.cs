using UnityEngine;

namespace Interactive360
{   public class CameraManager : MonoBehaviour
    {

        private static CameraManager Instance = null;

        
        [Tooltip("Only needed for Gaze Based Interactions")]
        public GameObject m_cameraUI;

        public void Start()
        {
            if (Instance)
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
        }
        

        //method to turn camera UI on
        public void turnUIOn()
        {
            if (m_cameraUI)
            {
                m_cameraUI.SetActive(true);
            }
        }

        //method to turn camera UI off
        public void turnUIoff()
        {
            if (m_cameraUI)
            {
                m_cameraUI.SetActive(false);
            }

        }
    }
}
