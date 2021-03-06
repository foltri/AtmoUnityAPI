﻿/*
  NewMarker.cs - This script handles the onDetected event of Tracking Handler.
  It puts GameObjects with colored circle sprites on the scene in the position 
  of markers found on the table. GameObjects are named by the corresponding 
  markers' unique ids. Circle color depends on the ID of the marker.
  Created by Atmo, February 2, 2018.
*/

using UnityEngine;

public class NewMarker : MonoBehaviour {

    public GameObject highlight;

    // Handles onDetected event of Tracking Handler
    public void HandleOnDetected(Marker marker)
    {
        switch (marker.markerID)
        {
            case 0:
                AddHighlight(marker.position, new Color32(0xF8, 0xB0, 0x68, 100), marker.uniqueID);
                break;
            case 1:
                AddHighlight(marker.position, new Color32(0xFF, 0x4F, 0x68, 100), marker.uniqueID);
                break;
            case 2:
                AddHighlight(marker.position, new Color32(0x39, 0x46, 0x4e, 100), marker.uniqueID);
                break;
            case 3:
                AddHighlight(marker.position, new Color32(0x6C, 0xE8, 0x90, 100), marker.uniqueID);
                break;
            case 4:
                AddHighlight(marker.position, new Color32(0x75, 0x61, 0xFF, 100), marker.uniqueID);
                break;
            case 5:
                AddHighlight(marker.position, new Color32(0x00, 0x61, 0xFF, 100), marker.uniqueID);
                break;
            default:
                break;
        }
    }

    private void AddHighlight(Vector2 position, Color32 color, int id)
    {
        GameObject h = Instantiate(highlight);
        h.transform.position = position;
        h.GetComponent<SpriteRenderer>().color = color;
        h.name = id.ToString();
    }
}
