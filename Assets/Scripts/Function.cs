using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Function : MonoBehaviour {
    public string text;
    //public TextMeshPro textBox; //Falla
    public TMP_Text textBox;
    public void ActivateText() {
        StartCoroutine("ShowText");
    }
    public void DesactivateText() {
        StopCoroutine("ShowText");
        textBox.text = ""; //limpiar
    }
    IEnumerator ShowText() {
        for (int i = 0; i < text.Length; i++) {
            textBox.text += text[i];
            yield return new
           WaitForSeconds(0.02f);
        }
    }
}