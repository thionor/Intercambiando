using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincipalMenuManager : MonoBehaviour
{

    [SerializeField] private string sceneName;

    public void Jogar() {
        SceneManager.LoadScene(sceneName);
    }
    

}
