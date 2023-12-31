using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetUiText : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text textField;
    [SerializeField]
    private string fixedText;

    public void OnSliderValueChanged(float newValue)
    {
        textField.text = $"{fixedText}: {newValue}";
    }
}
