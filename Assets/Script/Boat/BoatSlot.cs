using UnityEngine;

public class BoatSlot : MonoBehaviour, ISlot {

    protected Container container;

    protected string type;

    SpriteRenderer sr;

    void Awake() {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void SetType(Container container) {
        type = container.GetContainerType();
        sr.sprite = container.GetTargetSprite();
    }

    public bool Store(Container container) {
        if (this.container != null) return false;
        this.container = container;
        container.transform.SetParent(gameObject.transform);
        container.transform.localPosition = Vector3.zero;
        return true;
    }

    public Container Retrive(Container container) {
        Container tmp = container;
        container = null;
        return tmp;
    }

    public Container GetContainer() {
        return container;
    }

    public string GetContainerType() {
        return type;
    }

    public void Touch() {
        return;
    }

}