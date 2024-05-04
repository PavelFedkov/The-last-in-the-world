using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    //объект камеры
    private Camera _camera;
    private void Start()
    {
        //Получаем данные о камере
        _camera = GetComponent<Camera>();

        //Скроем указатель мыыши в игровом окне
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    private void Update()
    {
        //Проверям момент нажатия на 'Выстрел'
        if (Input.GetMouseButtonDown(0))
        {
            //Запоминаем центр экрана
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            //Пускаем лучь из центра экрана относительно камеры
            Ray ray = _camera.ScreenPointToRay(screenCenter);
            RaycastHit hit; //Улавливаем попадание в эту переменную

            //Если попали в кокой то объект
            if(Physics.Raycast(ray, out hit))//Пускаем луч ray, результат считываем в hit
            {
                //Распознование попадания в цель
                GameObject hitObject = hit.transform.gameObject;//Получаем объект, в который попал ray
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>(); //Получаем компонент этого объекта

                //Проверяем,попадание в мишень
                if( target != null )
                {
                    target.ReactToHit();
                }
                else
                {
                    //Запускаем сопрограмму
                    StartCoroutine(SphereInicatorCoroutine(hit.point));
                    //Рисуем отладочную линию, чтобы проследить траекторию луча
                    Debug.DrawLine(this.transform.position, hit.point, Color.green, 4);
                }
            }
        }
    }

    private void OnGUI()
    {
        //Добавление визуального индикатора в центре экрана
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 -size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
    //Сопрограмма, которая создаёт сферу
    private IEnumerator SphereInicatorCoroutine(Vector3 pos)
    {
        //Создаём игровой объект сферу
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos; //Указываем позицию сферы

        yield return new WaitForSeconds(3);

        Destroy(sphere);//Удаляем сферу
    }

}
