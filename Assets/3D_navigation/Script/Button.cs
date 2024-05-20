using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Button_ : MonoBehaviour
{
    public Button button;
    private List<Collider> obstacles = new List<Collider>(); // ������ �����������, ����������� � ���� �������� ������

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("���������� �����������. ���������� ������.");
            obstacles.Add(other); // ��������� ����������� � ������
            button.gameObject.SetActive(false); // ��������� ������
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("������ ����� �� ���� ��������.");
            obstacles.Remove(other); // ������� ����������� �� ������
            CheckAndEnableButton(); // �������� ����� ��� �������� � ��������� ������
        }
    }

    void CheckAndEnableButton()
    {
        // ���������, ���� �� ������ ����������� ����� � �������
        if (obstacles.Count == 0)
        {
            Debug.Log("��� ������ ����������� ����� � �������. ��������� ������.");
            button.gameObject.SetActive(true); // �������� ������
        }
    }
}
