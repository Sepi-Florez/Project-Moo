using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour, IClickable {
    public enum BuildType { Barn, Storage}
    public BuildType type;

    Animator anim;

    public void Awake() {
        anim = GetComponent<Animator>();
    }

    public void OnLClick() {
        print("Click L on barn");
        anim.SetTrigger("Click");
    }
    public void OnRClick() {

    }
    public void Hover() {
        print("Hovering Barn");
    }
}
