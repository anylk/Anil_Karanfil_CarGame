﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1.5f);   
    }
}
