using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
    public static ResourceManager thisManager;
    public int[] resources = new int[3];
    Text[] resourcesText = new Text[3];

    private void Awake() {
        thisManager = this;
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
