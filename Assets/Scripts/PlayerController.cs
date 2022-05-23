using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI bestText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    private Stopwatch stopWatch = new Stopwatch();
    private int best_time;

    static string path = "Assets/Resources/record.txt";

    // Start is called before the first frame update
    void Start()
    {
        stopWatch.Start();
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);

        StreamReader reader = new StreamReader(path);
        string time = reader.ReadToEnd();
        bestText.text = "Best Score: " + time;
        best_time = int.Parse(time);
        reader.Close();

        reader = new StreamReader("Assets/Resources/speed.txt");
        speed = float.Parse(reader.ReadToEnd());
        reader.Close();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 8)
        {
            stopWatch.Stop();
            winTextObject.SetActive(true);

            int best_seconds = (int)stopWatch.ElapsedMilliseconds / 1000;

            if (best_time > best_seconds)
            {
                FileStream fcreate = File.Open("Assets/Resources/record.txt", FileMode.Create); // will create the file or overwrite it if it already exists
                StreamWriter writer = new StreamWriter(fcreate);
                bestText.text = "Best Time: " + best_seconds;
                writer.WriteLine(best_seconds);
                writer.Close();
            }

            SceneManager.LoadScene("Menu");
        }
    }
}
