using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : Build {
    public enum BarnType {Chickens, Cow, Sheep}
    public BarnType type2;
    public int produceCount;

    bool autoProduce;
    Coroutine autoProduceLoop;
    public int autoProduceTime;

    bool begin = false;

    public override void OnLClick() {
        base.OnLClick();
        if(base.CP == 100) {
            if (!begin) {
                Begin();
                begin = true;
            }
            Produce();
        }
    }
    public void Begin() {
        autoProduce = true;
        autoProduceLoop = StartCoroutine(AutoProduce(autoProduceTime));
    }
    public void Produce() {
        ResourceManager.thisManager.Add(produceCount, (int)type2 + 1);
    }
    public IEnumerator AutoProduce(int time) {
        while(autoProduce){
            Produce();
            yield return new WaitForSeconds(time);
        }
    }
}
