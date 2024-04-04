using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected const int SIZE = Config.SIZE;

    // ���������� �����
    private int _x = 0;
    private int _y = 0;

    // ��������� ����
    private static int[][] _moveAdd = new[] {
        new[] { 1, 0 },
        new[] { 0, 1 },
        new[] { -1, 0 },
        new[] { 0, -1 }
    };

    // �������� ������������ ����� 
    [SerializeField] private float Speed;


    private IEnumerator MoveObject(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            float speed = Speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target, speed);
            yield return null;
        }
    }
    public void Update()
    {
        Storage storage = GameObject.Find("Storage").GetComponent<Storage>();
        if (storage.IsMove)
        {
            foreach (int[] add in _moveAdd)
            {
                // ������� ���������� ������, � ������� ����� �����
                int newX = _x + add[0];
                int newY = _y + add[1];
                if (Mathf.Min(newX, newY) < 0 || SIZE <= Mathf.Max(newX, newY)) continue;

                // ���� ������ �������
                if (storage.Is�licked[newX, newY])
                {
                    StartCoroutine(MoveObject(new Vector3(newX, 1, newY)));
                    _x = newX;
                    _y = newY;
                }
            }
        }

    }
}
