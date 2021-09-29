using UnityEngine;

public abstract class AContainer : MonoBehaviour {

    [SerializeField] protected int selectedWeight;

    [SerializeField] protected Sprite targetSprite;

    public abstract string GetContainerType();

    public int GetSelectedWeight() {
        return selectedWeight;
    }

    public Sprite GetTargetSprite() {
        Debug.Log(string.Format("Get target sprite {0}", targetSprite.ToString()));
        return targetSprite;
    }

}