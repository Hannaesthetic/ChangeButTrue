using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maker : MonoBehaviour
{
    public GameObject prefab;


    private void OnMouseDown()
    {
        GameObject go = Instantiate(prefab, transform.position, transform.rotation);
        Draggable draggable = go.GetComponent<Draggable>();
        Draggable.dragged = draggable;
    }
}
