using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonControl : MonoBehaviour
{
    public void LoadScene(string str) {  
        SceneManager.LoadScene(str);  
    }
    
    public void QuitGame(){
        Application.Quit();
    }
}
