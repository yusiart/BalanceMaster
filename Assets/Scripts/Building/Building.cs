﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
