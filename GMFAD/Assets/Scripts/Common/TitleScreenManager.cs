using UnityEngine;

namespace Common
{
    public class TitleScreenManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }
    
        public void StartGame()
        {
            // Load the first scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(ProjectData.Scenes.GameScene.Name);
        }
        
        public void Settings()
        {
            // Load the settings scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(ProjectData.Scenes.SettingsScene.Name);
        }
        
        public void Credits()
        {
            // Load the credits scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(ProjectData.Scenes.CreditsScene.Name);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
