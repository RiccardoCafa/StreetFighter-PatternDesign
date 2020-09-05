using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viola : MonoBehaviour
{
    public static Viola Instance;

    public AudioSource Source;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Source = GetComponent<AudioSource>();
    }
}
