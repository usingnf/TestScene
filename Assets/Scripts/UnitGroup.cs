using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGroup : MonoBehaviour
{
    public static Transform instance = null;
    void Awake()
    {
        instance = this.transform;
    }
}
