using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPickerButton : MonoBehaviour
{
    public Board Board => _board;

    private Board _board;

    private void Start()
    {
        _board = GetComponentInChildren<Board>();
    }
}
