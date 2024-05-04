using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefab;//массив объектов шаблонов
    private GameObject _enemy ;
    int enemycol = 0;
    private void Update()
    {
        //Создаём нового врага, если его нет
        //Так можно регулировать колличество врагов на сцене
        if (_enemy == null)
        {
            while ( enemycol < 3)
            {
                int randEnemy = Random.Range(0, _enemyPrefab.Length);//Случайно выбираем врага
                _enemy = Instantiate(_enemyPrefab[randEnemy]) as GameObject;//Создаём клона как игровой объект
                _enemy.transform.position = new Vector3(Random.Range(-24, 24), 3, Random.Range(-24, 24));//Задаём позицию появления
                float angle = Random.Range(0, 360);
                _enemy.transform.Rotate(0, angle, 0);//Поворачиваем
                enemycol++;
            }
            enemycol = 0;
        }
    }
}
