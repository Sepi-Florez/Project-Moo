using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {
    void Update() {
        Controls();

    }
    private void Controls() {

        if (Input.GetButtonDown("Fire1")) {
            if(Ray() != null) {
                Ray().OnLClick();
            }
        }
        else if (Input.GetButtonDown("Fire2")){
            if (Ray() != null) {
                Ray().OnRClick();
            }
        }
    }
    public IClickable Ray() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)){
            IClickable clickInterface = hit.transform.GetComponent(typeof(IClickable)) as IClickable;
            if(clickInterface != null) {
                return clickInterface;
            }
            else {
                return null;
            }
        }
        else {
            return null;
        }

    }

}
