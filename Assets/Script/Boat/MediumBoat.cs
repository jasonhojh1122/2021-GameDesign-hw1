using UnityEngine;


public class MediumBoat : ABoat {
    public override float GetWeight(float time) {
        return 20.0f + time / 2;
    }
}