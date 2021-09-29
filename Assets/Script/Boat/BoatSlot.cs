using UnityEngine;

public class BoatSlot : MonoBehaviour, ISlot {

    protected AContainer container;

    protected string type;

    SpriteRenderer sr;

    void Awake() {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void SetType(string type, Sprite sprite) {
        this.type = type;
        sr.sprite = sprite;
    }

    public bool Store(AContainer container) {
        if (this.container != null) return false;
        this.container = container;
        container.transform.SetParent(gameObject.transform);
        container.transform.localPosition = Vector3.zero;
        return true;
    }

    public AContainer Retrive(AContainer container) {
        return null;
    }

    public AContainer GetContainer() {
        return container;
    }

    public string GetContainerType() {
        return type;
    }

}