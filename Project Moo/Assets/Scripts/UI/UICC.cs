using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class UICC : MonoBehaviour {
    public static UICC CounterChanger;
    public GameObject countPref;

    public Vector2 offset;

    public void Awake() {
        CounterChanger = this;
    }

    public void CC(int change, Transform counter) {
        print(change + "Is made");
        Transform n = Instantiate(countPref, new Vector2(counter.position.x,counter.position.y) /*transform.GetComponent<Camera>().WorldToScreenPoint(counter.position)*/ + offset, Quaternion.identity).transform;
        n.parent = FindObjectOfType<Canvas>().transform;
        n.parent = counter.parent;
        n.SetAsLastSibling();
        n.GetChild(0).GetComponent<Text>().text = "+ " + change.ToString();
    }
}
