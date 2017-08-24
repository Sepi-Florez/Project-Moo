using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour, IClickable {
    public enum BuildType { Barn, Storage }
    public BuildType type;

    public int CR;
    public int CP;

    Animator anim;

    public void Awake() {
        anim = GetComponent<Animator>();
    }
    //Virtual Class cant call this function. Put this code into the onclick function
    /*public void Contruct() {
        CP += CR;
        Color c = transform.GetComponent<SpriteRenderer>().color;
        c = new Color(c.r, c.g, c.b, 255 / 100 * CP);
        transform.GetComponent<SpriteRenderer>().color = c;
    }*/
    public virtual void OnLClick() {
        if(CP < 100) {
            CP += CR;
            Color c = transform.GetComponent<SpriteRenderer>().color;
            c = new Color(c.r, c.g, c.b, (float)CP / 100f);
            transform.GetComponent<SpriteRenderer>().color = c;
            print(c + "And" + transform.GetComponent<SpriteRenderer>().color);
        }
        anim.SetTrigger("Click");
    }
    public virtual void OnRClick() {
        print("Right Click");
    }
    public void Hover() {
        print("Hovering");
    }

}
