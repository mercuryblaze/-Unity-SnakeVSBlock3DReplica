using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Text amountText;

    private int _amount;

    private void OnEnable()
    {
        _amount = Random.Range(1, 6);
        amountText.text = _amount.ToString();
    }
}
