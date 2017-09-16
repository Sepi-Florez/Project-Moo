using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : Build {
    public enum BarnType {Chickens, Sheep, Cow}
    public BarnType type2;
    public int produceCount;

    public override void OnLClick() {
        base.OnLClick();
        if(base.CP == 100) {
            Produce();
        }
    }

    public void Produce() {
        ResourceManager.thisManager.Add(produceCount, (int)type2 + 1);
    }
}
