using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {
    public static Pointer pointer;

    public delegate void ConstructionDelegate();
    public ConstructionDelegate constructionEvent;

    public LayerMask targetLayer;
    public LayerMask standardLayer;
    public LayerMask constructionLayer;


    public GameObject held;
    public Coroutine hold;
    private void Awake() {
        pointer = this;
        held = null;
    }

    void Update() {
        Controls();
    }
    private void Controls() {
        if(Ray() != null) {
            Ray().Hover();
        }
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
        if (Input.GetButtonDown("Cancel")) {
            if(held != null) {
                CancelConstruction(1);
            }
            else {

            }
        }

    }
    // Checks for objects beneath the cursor.
    public IClickable Ray() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer)){
            //print("Hitting : " + hit.transform.name);
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
    public void Construction (GameObject build) {
    	if(held == null){
            targetLayer = constructionLayer;
		    Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10));
		    held = Instantiate(build, p, Quaternion.identity);
		    hold = StartCoroutine(Hold());
		    constructionEvent();
    	}
    }
    public void CancelConstruction(int i) {
        if(i == 1) {
            ShopManager.thisManager.Refund();
        }
        Destroy(held);
        held = null;
        constructionEvent();
        targetLayer = standardLayer;
    }

    IEnumerator Hold() {
        while(held != null) { 
            Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            held.transform.position = p;
            yield return new WaitForEndOfFrame();
        }

    }
}
