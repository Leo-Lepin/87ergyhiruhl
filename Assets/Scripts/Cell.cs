using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Cell : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private const int SIZE = Config.SIZE;

<<<<<<< Updated upstream
    public int countCoin = 0;
    public Dictionary<string,int> elements=new Dictionary<string, int>();
=======
    public int CountCoin = 0;
    public Dictionary<string, int> Elements = new Dictionary<string, int>();
>>>>>>> Stashed changes
    public int x;
    public int y;
    [SerializeField] private GameObject player;

    // ������������� �������� ������ �� � �����������
    public void setMaterial(Material mat)
    {
        GetComponent<Renderer>().material = mat;
    }

    // ��������� ���� ������� �� ������
    public void OnPointerDown(PointerEventData ev)
    {
        GameObject.Find("Storage").GetComponent<Storage>().Is�licked[(int)transform.position.x, (int)transform.position.z] = true;
        Debug.Log(1);
    }
    public void OnPointerUp(PointerEventData ev)
    {
        GameObject.Find("Storage").GetComponent<Storage>().Is�licked[(int)transform.position.x, (int)transform.position.z] = false;
        Debug.Log(0);
    }
}
