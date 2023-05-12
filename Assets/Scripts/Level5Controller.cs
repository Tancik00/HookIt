using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Controller : MonoBehaviour
{
    public static Level5Controller Instance;
    public Transform redDoor;
    public Transform greenDoor;
    public Transform yellowDoor;

    public List<GameObject> rainbowCubes;
    public List<GameObject> newRainbowCubes;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void Hit(string tag, GameObject obj)
    {
        switch (tag)
        {
            case "redCube":
                OpenDoor(redDoor);
                break;
            case "greenCube":
                OpenDoor(greenDoor);
                break;
            case "yellowCube":
                OpenDoor(yellowDoor);
                break;
        }
    }

    private void OpenDoor(Transform door)
    {
        var doorPos = door.position;
        doorPos.y += 5f;
        door.position = doorPos;
    }
}
