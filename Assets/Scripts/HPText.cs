using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPText : MonoBehaviour
{
    [Header("Inspector")]
    [SerializeField] private TextMeshProUGUI hpText;
    private void Start()
    {
        GameManager.Instance.hpEvent += SetHpText;
    }

    private void OnDestroy()
    {
        GameManager.Instance.hpEvent -= SetHpText;
    }

    public void SetHpText(int hp)
    {
        hpText.text = hp.ToString();
    }
}
