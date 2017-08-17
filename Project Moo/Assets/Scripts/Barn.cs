using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : Build {
    enum BarnType {Chickens, Sheep, Cow}
    BarnType type;
    public int produceCount;

    public void OnLClick() {
        Produce();
    }

    public void Produce() {
        print("Producing");
    }

}
