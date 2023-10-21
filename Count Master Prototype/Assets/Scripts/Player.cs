﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField]
    private float sensitivity;

    private float maxOffset = 3.5f;
    private float horizontalInput;
    private Vector3 finalPos;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * sensitivity * Time.deltaTime);
        finalPos = transform.position;

        finalPos.x = Mathf.Min(maxOffset, finalPos.x);
        finalPos.x = Mathf.Max(-maxOffset, finalPos.x);
        transform.position = finalPos;
    }

}

