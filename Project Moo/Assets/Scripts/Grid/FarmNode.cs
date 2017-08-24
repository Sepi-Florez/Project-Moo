using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmNode : MonoBehaviour, IClickable {
    enum NodeType { Empty, Road, Building };
    NodeType type = NodeType.Empty;

    bool cons = false;

    GameObject build;
    void Awake() {

    }
    public void OnLClick() {
        if(Pointer.pointer.held != null && type == NodeType.Empty) {
            build = Pointer.pointer.held;
            Pointer.pointer.held = null;
            Pointer.pointer.CancelConstruction();
            type = NodeType.Building;
            build.transform.position = transform.position;
            build.layer = LayerMask.NameToLayer("Build");
            //Color Change ( Might look for a better spot to place this )
            Color c = build.GetComponent<SpriteRenderer>().color;
            c = new Color(c.r, c.g, c.b, 0.1f);
            build.GetComponent<SpriteRenderer>().color = c;
        }
    }
    public void OnRClick() {
        print("Right");
    }
    public void Hover() {
        print("Hovering");
    }
    public void ConstructionMode() {
        if (!cons) {
            cons = !cons;
            if (build == null) {
                type = NodeType.Empty;
            }
            if (type == NodeType.Empty) {
                GetComponent<SpriteRenderer>().color = Color.green;
                print(type);
            }
            else {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        else {
            cons = !cons;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f);
        }
    }
}
