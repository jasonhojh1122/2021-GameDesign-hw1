using UnityEngine;

public interface ISlot {
    bool Store(AContainer container);
    AContainer Retrive(AContainer container);
}