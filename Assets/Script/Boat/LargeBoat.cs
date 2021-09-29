using UnityEngine;


public class LargeBoat : ABoat {
    public override float GetWeight(float time) {
        return 5.0f + time;
    }
}