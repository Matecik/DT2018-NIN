using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDragable : IClickable {

    void OnDragStart();
    void OnDragUpdate();
    void OnDragRelease();
}
