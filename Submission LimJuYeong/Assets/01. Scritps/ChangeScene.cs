using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
   public void ChangeSceneBtn()
    {
        SceneManager.LoadScene("SampleScene");
        // 씬매니저를 통해 게임이 플레이되는 "SampleScene"이라는 씬을 불러오기 
    }
}
