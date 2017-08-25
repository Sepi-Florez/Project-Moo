using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
    public static ResourceManager thisManager;
    public int[] resources = new int[3];
    Text[] resourcesText = new Text[3];
    public Transform resourcesTextObj;

    private void Awake() {
        thisManager = this;
        for(int i = 0; i < resourcesTextObj.childCount; i++) {
            resourcesText[i] = resourcesTextObj.GetChild(i).GetComponent<Text>();
        }
    }
    public void Add(int count, int resource) {
        resources[resource] += count;
        Refresh(resource);
    }
    public void Subtract(int count, int resource) {
        resources[resource] -= count;
        Refresh(resource);
    }
    void Refresh(int resource) {
        resourcesText[resource].text = resources[resource].ToString();
    }
}
