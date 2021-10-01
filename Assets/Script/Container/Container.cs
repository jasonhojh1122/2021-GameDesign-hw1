using UnityEngine;

public class Container : MonoBehaviour {

    [SerializeField] protected int selectedWeight;

    [SerializeField] protected string containerType;

    [SerializeField] protected Sprite targetSprite;

    public string GetContainerType() {
        return containerType;
    }

    public int GetSelectedWeight() {
        return selectedWeight;
    }

    public Sprite GetTargetSprite() {
        return targetSprite;
    }

}