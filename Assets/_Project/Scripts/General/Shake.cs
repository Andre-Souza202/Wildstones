using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shake : MonoBehaviour
{
    public static Shake Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ShakeObject()
    {
        transform.DOShakePosition(2f, 100f, 80, 50f, true);
    }
}
