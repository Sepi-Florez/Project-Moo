using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmGrid : MonoBehaviour {
    public int w;
    public int h;
    public FarmNode[,] grid;
    public GameObject nodePrefab;


    private void Awake() {
        grid = new FarmNode[w,h];
        CreateGrid();
        
    }
    private void Update() {
        if (Input.GetButtonDown("Jump")) {
            ConstructionMode();
        }
    }
    private void CreateGrid() {
        for(int i = 0; i < w; i++) {
            print("Starting on W row : " + i);
            for (int ii = 0; ii < h; ii++) {
                print("instantiating height node : " + ii);
                grid[i, ii] = Instantiate(nodePrefab, new Vector3(ii, i, 0), Quaternion.identity).GetComponent<FarmNode>();
            }
        }
    }
    private void ConstructionMode() {
        for (int i = 0; i < w; i++) {
            print("Starting on W row : " + i);
            for (int ii = 0; ii < h; ii++) {
                print("instantiating height node : " + ii);
                grid[i, ii].ConstructionMode();
            }
        }
    }
}
