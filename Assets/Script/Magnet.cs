using UnityEngine;

public class Magnet : MonoBehaviour
{
    public SelectionIndicator indicator;

    private bool withContainer;

    [SerializeField] private GameObject container;
    [SerializeField] private GameObject slot;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Container" && withContainer == false) {
            // Debug.Log(string.Format("Enter {0}", other.gameObject.name));
            container = other.gameObject;
            indicator.Indicate(container.gameObject.transform.position);
        }
        else if (other.gameObject.tag == "Slot") {
            // Debug.Log(string.Format("Enter {0}", other.gameObject.name));
            slot = other.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Container" && withContainer == false) {
            // Debug.Log(string.Format("Exit {0}", other.gameObject.name));
            indicator.UnIndicate();
            container = null;
        }
        else if (other.gameObject.tag == "Slot") {
            // Debug.Log(string.Format("Exit {0}", other.gameObject.name));
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
        container.transform.SetParent(gameObject.transform);
        withContainer = true;
    }

    public void PutDown()
    {
        Debug.Log(string.Format("Put Down on {0}", slot.name));
        // slot.GetComponent<Slot>().PutContainer(container);
        container.transform.SetParent(slot.transform);
        container.transform.localPosition = Vector3.zero;
        withContainer = false;
    }

    public bool IsWithContainer()
    {
        return withContainer;
    }

}