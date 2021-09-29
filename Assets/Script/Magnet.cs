using UnityEngine;

public class Magnet : MonoBehaviour
{
    public SelectionIndicator indicator;

    private bool withContainer;

    private AContainer container;
    private SpriteRenderer spriteRenderer;
    private ISlot slot;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Container" && withContainer == false) {
            container = other.gameObject.GetComponent<AContainer>();
            spriteRenderer = container.GetComponent<SpriteRenderer>();
            indicator.Indicate(container.gameObject.transform);
        }
        else if (other.gameObject.tag == "Slot") {
            slot = other.gameObject.GetComponent<ISlot>();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Container" && withContainer == false) {
            indicator.Indicate(container.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Container" && withContainer == false) {
            indicator.UnIndicate();
            container = null;
        }
        else if (other.gameObject.tag == "Slot") {
            slot = null;
        }
    }

    public bool IsOnContainer()
    {
        return container != null;
    }

    public bool IsOnSlot()
    {
        return slot != null;
    }

    public void PickUp()
    {
        indicator.UnIndicate();
        container = slot.Retrive(container);
        container.transform.SetParent(gameObject.transform);
        RaiseSortingOrder();
        withContainer = true;
    }

    public void PutDown()
    {
        if (IsOnSlot() && slot.Store(container)) {
            ReduceSortingOrder();
            container = null;
            withContainer = false;
        }
        else {
            if (IsOnSlot())
                Debug.Log("Is On Slot Warn");
            indicator.Warn(container.transform);
        }
    }

    public bool IsWithContainer()
    {
        return withContainer;
    }

    public void RaiseSortingOrder() {
        indicator.RaiseSortingOrder();
        spriteRenderer.sortingOrder = 10;
    }

    public void ReduceSortingOrder() {
        indicator.ReduceSortingOrder();
        spriteRenderer.sortingOrder = 1;
    }

}