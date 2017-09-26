using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class UICC : MonoBehaviour {
    public static UICC CounterChanger;
    public GameObject countPref;

    public Vector2 offset;

    public int updateRate;

    public List<int> changes = new List<int>();
    public List<Transform> counters = new List<Transform>();
    
    public void Awake() {
        CounterChanger = this;
    }

    public void CC(int change, Transform counter) {
        bool n = false;
        for(int i = 0; i < counters.Count; i++){
            if(counters[i] == counter){
                n = true;
                changes[i] += change;
            }
        }
        if(!n){
            print("New");
            counters.Add(counter); 
            changes.Add(change);
            StartCoroutine(CCPush(counters.Count - 1));
        }


    }
    public IEnumerator CCPush(int i){
        while(changes[i] != 0) {
            print("Pushing CC");
            Transform n = Instantiate(countPref, new Vector2(counters[i].position.x, counters[i].position.y) /*transform.GetComponent<Camera>().WorldToScreenPoint(counter.position)*/ + offset , Quaternion.identity).transform;
            n.parent = counters[i].parent;
            n.SetAsLastSibling();
            if(changes[i] < 0){
                n.GetChild(0).GetComponent<Text>().color = Color.red;
            }
            else{
                n.GetChild(0).GetComponent<Text>().color = Color.green;
                n.GetChild(0).GetComponent<Text>().text = "+ ";
            }
            n.GetChild(0).GetComponent<Text>().text += changes[i].ToString();
            changes[i] = 0;
            
            yield return new WaitForSeconds(updateRate);
        }
        changes.RemoveAt(i);
        counters.RemoveAt(i);
    }
    public void CCForcePush(int change, Transform counter) {
        print("Forcing Push CC");
        Transform n = Instantiate(countPref, new Vector2(counter.position.x, counter.position.y) /*transform.GetComponent<Camera>().WorldToScreenPoint(counter.position)*/ + offset, Quaternion.identity).transform;
        n.parent = counter.parent;
        n.SetAsLastSibling();
        //n.GetChild(0).GetComponent<Text>().text = "+ " + change.ToString();
        if (change < 0) {
            n.GetChild(0).GetComponent<Text>().color = Color.red;
        }
        else {
            n.GetChild(0).GetComponent<Text>().color = Color.green;
            n.GetChild(0).GetComponent<Text>().text = "+ ";
        }
        n.GetChild(0).GetComponent<Text>().text += change.ToString();
    }
}
