using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceTabManager : MonoBehaviour {
    public void Sell() {

    }
    public void IncreaseSell(Transform field) {
        int i = System.Convert.ToInt32(field.GetComponent<InputField>().text);
        i++;
        if (i > System.Convert.ToInt32(field.parent.parent.GetChild(0).GetComponent<Text>().text)) {
            return;
        }
        field.GetComponent<InputField>().text = i.ToString();
    }
    public void DecreaseSell(Transform field) {
        int i = System.Convert.ToInt32(field.GetComponent<InputField>().text);
        i--;
        if (i < 0) {
            return;
        }
        field.GetComponent<InputField>().text = i.ToString();
    }
}
