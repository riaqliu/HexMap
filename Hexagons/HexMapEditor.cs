using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMapEditor : MonoBehaviour
{
    public Color[] colors;
    public HexGrid hexGrid;
    private Color activeColor;
    void Awake()
    {
        SelectColor(0);
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(inputRay, out hit))
        {
            //ColorCell(hit.point);
            EditCell(hexGrid.GetCell(hit.point));
        }
    }

    int activeElevation;
    void EditCell(HexCell cell)
    {
        cell.color = activeColor;
        cell.Elevation = activeElevation;
        hexGrid.Refresh();
        
    }

    public void SelectColor(int index)
    {
        activeColor = colors[index];
    }

    public void SetElevation(float elevation)
    {
        activeElevation = (int) elevation;
    }
}
