﻿using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {

        Application.LoadLevel("Level1");
    }

}
