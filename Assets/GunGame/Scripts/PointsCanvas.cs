using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCanvas : MonoBehaviour
{
    public int Points
    {
        set
        {
            GetComponentInChildren<Text>().text = value.ToString();
        }
    }

    private Text _text;

    private void Start()
    {
        _text = GetComponentInChildren<Text>();
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        Color color = _text.color;
        color.a = Mathf.MoveTowards(color.a, 0, Time.deltaTime * .5f);
        _text.color = color;

        transform.position += Vector3.up * Time.deltaTime * 2;
    }
}
