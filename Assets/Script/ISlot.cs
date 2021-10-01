using UnityEngine;

public interface ISlot {
    bool Store(Container container);
    void Retrive(Container container);
    void Touch();
}