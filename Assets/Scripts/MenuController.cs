using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject play_confirm_object;
    public GameObject exit_confirm_object;
    public TextMeshProUGUI best_menu_object;

    public void PlayPressed()
    {
        TextAsset txt = (TextAsset)Resources.Load("record", typeof(TextAsset));
        List<string> lines = new List<string>(txt.text.Split('\n')); 

        play_confirm_object.gameObject.SetActive(true);
        best_menu_object.text = "Best Score: " + lines[0];
    }

    public void ExitPressed()
    {
        exit_confirm_object.gameObject.SetActive(true);
    }

    public void YesPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void NoPlay()
    {
        play_confirm_object.gameObject.SetActive(false);
    }

    public void YesExit()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }

    public void NoExit()
    {
        exit_confirm_object.gameObject.SetActive(false);
    }

}
