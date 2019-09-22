using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayButton : MonoBehaviour
{
    public float randomRange;
    public float randomAngle;
    public GameObject win;
    public GameObject lose;
    public List<GameObject> prefabs;
    public Bill billObj;
    // Start is called before the first frame update
    
    private float valuePaid;
    private float changeDue;

    private void Awake()
    {
        SetCosts();
    }

    private void OnMouseDown()
    {
        CheckCosts();
    }

    private void SetCosts()
    {
        float bill = Random.Range(0, 12000);
        billObj.SetCost(bill / 100f);
        float amountToPay = Mathf.Ceil(Random.Range(1f, 1.2f) * bill);
        valuePaid = 0f;
        while (amountToPay > valuePaid)
        {
            MakeCoin(Random.Range(0, prefabs.Count));
        }
        changeDue = valuePaid - bill;
    }

    private void CheckCosts()
    {
        float amountPaid = 0f;
        foreach(Draggable draggable in FindObjectsOfType<Draggable>())
        {
            amountPaid += draggable.currency * 100f;
        }
        if (Mathf.CeilToInt(amountPaid) == Mathf.CeilToInt(changeDue))
        {
            win.SetActive(true);
            lose.SetActive(false);
        } else
        {
            lose.SetActive(true);
            win.SetActive(false);
        }
        Debug.Log($"Paid {Mathf.CeilToInt(amountPaid)} and needed {Mathf.CeilToInt(changeDue)}");

        foreach (Draggable draggable in FindObjectsOfType<Draggable>())
        {
            if (draggable.currency > 0f)
            {
                Destroy(draggable.gameObject);
            }
        }
        SetCosts();
    }

    private void MakeCoin(int index)
    {
        GameObject go = Instantiate(prefabs[index], new Vector3(0f, 20f, 0f), Quaternion.identity);
        Draggable draggable = go.GetComponent<Draggable>();
        draggable.targetPosition = new Vector3(Random.Range(-randomRange, randomRange), Random.Range(-randomRange, randomRange), 0f);
        draggable.angle = Random.Range(-randomAngle, randomAngle);
        valuePaid += draggable.currency * 100f;
    }
}
