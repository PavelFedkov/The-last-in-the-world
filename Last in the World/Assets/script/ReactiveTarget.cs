using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private EnemyAI _enemyAI;
    void Start()
    {
        //Получаем данные о EnemyAI
        _enemyAI = GetComponent<EnemyAI>();
    }

    public void ReactToHit()
    {
        //Усли такой компонент есть
        if ( _enemyAI != null )
            _enemyAI.SetAlive(false);

        //Запускаем сопрограмму для смерти
        StartCoroutine(DieCoroutine(3));
    }

    private IEnumerator DieCoroutine(float waitSecond)
    {
        this.transform.Rotate(45, 0, 0);//Поворачиваем объект имитируя падение

        yield return new WaitForSeconds(waitSecond);

        Destroy(this.transform.gameObject);
    }
}
