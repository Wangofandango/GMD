using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
