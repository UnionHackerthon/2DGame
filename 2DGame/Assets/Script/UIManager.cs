using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Start() {
        if (instance != null) {
            instance = this;
        } else {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public void OnClickStart() 
    {
        SceneManager.LoadScene("InGame");
    }

    public void OnCLickEnd() 
    {
        Application.Quit();
    }

    public void OnCLickReStart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnCLickMain()
    {
        SceneManager.LoadScene("Main");
    }
}
