using UnityEngine;

public interface ISlot {
    bool Store(Container container);
    Container Retrive(Container container);
    void Touch();
}