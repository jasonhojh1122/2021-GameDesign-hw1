using UnityEngine;


public class LargeBoat : ABoat {
    public override float GetWeight(float time) {
        return 10.0f + time;
    }
}