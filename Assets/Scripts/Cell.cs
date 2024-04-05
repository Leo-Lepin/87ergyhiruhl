using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Cell : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private const int Size = Config.SIZE;

    public int CountCoin = 0;
    public Dictionary<string, int> Elements = new Dictionary<string, int>();

    public int x;
    public int y;
    [SerializeField] private GameObject _player;

    // ������������� �������� ������ �� � �����������
    public void SetMaterial(Material mat)
    {
        GetComponent<Renderer>().material = mat;
    }

    // ��������� ���� ������� �� ������
    public void OnPointerDown(PointerEventData ev)
    {
        Storage.Is�licked[(int)transform.position.x][(int)transform.position.z] = true;
        Debug.Log(Storage.Is�licked[(int)transform.position.x][(int)transform.position.z]);
    }
    public void OnPointerUp(PointerEventData ev)
    {
        Storage.Is�licked[(int)transform.position.x][(int)transform.position.z] = false;
        Debug.Log(Storage.Is�licked[(int)transform.position.x][(int)transform.position.z]);
    }
}
