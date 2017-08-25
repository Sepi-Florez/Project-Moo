using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Build {
    public override void OnLClick() {
        base.OnLClick();
        if (base.CP == 100) {
            print("Storage");
        }
    }
}
