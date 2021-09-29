using UnityEngine;


public class SmallBoat : ABoat {
    public override float GetWeight(float time) {
        return 60.0f - time;
    }
}