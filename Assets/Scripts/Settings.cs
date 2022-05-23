using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Settings : MonoBehaviour
{
    bool isFullScreen = false;

    public GameObject Player;
    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void ChangeSpeed()
    {
        FileStream fcreate = File.Open("Assets/Resources/speed.txt", FileMode.Create); // will create the file or overwrite it if it already exists
        StreamWriter writer = new StreamWriter(fcreate);
        writer.WriteLine("20");
        writer.Close();
    }
}
