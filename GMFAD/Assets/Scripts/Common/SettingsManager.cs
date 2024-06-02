using UnityEngine;

namespace Common
{
    public class SettingsManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }
    
        public void ReturnToTitleScreen()
        {
            // Load the first scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(ProjectData.Scenes.TitleScreen.Name);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
