using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Button_ : MonoBehaviour
{
    public Button button;
    private List<Collider> obstacles = new List<Collider>(); // Список препятствий, находящихся в зоне триггера кнопки

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Обнаружено препятствие. Отключение кнопки.");
            obstacles.Add(other); // Добавляем препятствие в список
            button.gameObject.SetActive(false); // Выключаем кнопку
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Объект вышел из зоны триггера.");
            obstacles.Remove(other); // Удаляем препятствие из списка
            CheckAndEnableButton(); // Вызываем метод для проверки и включения кнопки
        }
    }

    void CheckAndEnableButton()
    {
        // Проверяем, есть ли другие препятствия рядом с кнопкой
        if (obstacles.Count == 0)
        {
            Debug.Log("Нет других препятствий рядом с кнопкой. Включение кнопки.");
            button.gameObject.SetActive(true); // Включаем кнопку
        }
    }
}
