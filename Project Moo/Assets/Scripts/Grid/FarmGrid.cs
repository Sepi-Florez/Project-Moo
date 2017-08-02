﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmGrid : MonoBehaviour {
    public static FarmGrid farmGridManager;



    public int w;
    public int h;
    public FarmNode[,] grid;
    public GameObject nodePrefab;


    private void Start() {
        farmGridManager = this;
        grid = new FarmNode[w,h];
        CreateGrid();

        Pointer.pointer.constructionEvent += ConstructionMode;
        
    }
    private void Update() {
        if (Input.GetButtonDown("Jump")) {
            Pointer.pointer.Construction(nodePrefab);
        }
    }
    private void CreateGrid() {
        for(int i = 0; i < w; i++) {
            for (int ii = 0; ii < h; ii++) {
                grid[i, ii] = Instantiate(nodePrefab, new Vector3(ii, i, 0), Quaternion.identity).GetComponent<FarmNode>();
            }
        }
    }
    private void ConstructionMode() {
        for (int i = 0; i < w; i++) {
            for (int ii = 0; ii < h; ii++) {
                grid[i, ii].ConstructionMode();
            }
        }
    }
}
