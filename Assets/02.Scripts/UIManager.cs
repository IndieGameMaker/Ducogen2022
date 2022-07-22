using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OnStartGameClick()
    {
        // 게임 씬 호출(로딩)
        SceneManager.LoadScene("Play");
    }
}
