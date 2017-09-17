using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenuManager : MonoBehaviour {
    public Animator anim;

    public bool hidden = false;
    public Transform hideButton;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    public void Hide() {
        if (hidden) {
            hideButton.localScale = new Vector3(1, 1, 1);
            anim.SetBool("Hide", false);
            hidden = !hidden;
        }
        else {
            hideButton.localScale = new Vector3(1, -1, 1);
            anim.SetBool("Hide", true);
            hidden = !hidden;   
        }
    }
    public void ChangeTab(Transform tab) {
        tab.SetAsLastSibling();
        if(anim.GetBool("Hide") == true) {
            Hide();
        }
    }
}
