using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TransTela : MonoBehaviour
{
   public void ChangeScene(string SampleScene) 
    {
        SceneManager.LoadScene(SampleScene);
    }
}
