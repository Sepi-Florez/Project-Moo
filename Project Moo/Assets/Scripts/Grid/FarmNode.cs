using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmNode : MonoBehaviour, IClickable {
    enum NodeType { Empty, Road, Building };
    NodeType type = NodeType.Empty;
    bool cons = false;
    void Start() {
        
    }
    public void OnLClick() {
        print("Left");
    }
    public void OnRClick() {
        print("Right");
    }
    public void ConstructionMode() {
        if (!cons) {
            cons = !cons;
            if (type == NodeType.Empty) {
                GetComponent<SpriteRenderer>().color = Color.green;
            }
            else {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        else {
            cons = !cons;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.01f);
        }
    }
}
