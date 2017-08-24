using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : Build {
    enum BarnType {Chickens, Sheep, Cow}
    BarnType type;
    public int produceCount;

    public override void OnLClick() {
        base.OnLClick();
        if(base.CP == 100) {
            Produce();
        }
    }

    public void Produce() {
        //ResourceManager.thisManager.Add(produceCount,type.
    }
}
