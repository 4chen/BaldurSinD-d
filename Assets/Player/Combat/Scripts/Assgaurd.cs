﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assgaurd : MonoBehaviour
{
    SphereCollider PushBarrier;
    public float ExpandSize;
    public float PushBack;
    public float PushableRange;

    void Start()
    {
        PushBarrier = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (PushBarrier.radius < PushableRange && PushBarrier.radius != 0)
            PushBarrier.radius += ExpandSize;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, PushBarrier.radius + ExpandSize);
    }
}
