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
        Debug.Log(string.Format("Get target sprite {0}", targetSprite.ToString()));
        return targetSprite;
    }

}