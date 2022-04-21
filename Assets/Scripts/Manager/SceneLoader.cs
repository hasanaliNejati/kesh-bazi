using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void Resatrt()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
