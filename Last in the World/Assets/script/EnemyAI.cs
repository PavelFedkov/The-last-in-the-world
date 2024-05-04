
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Параметры сценария
    public float speed = 5.0f;
    public float obstacleRande = 5.0f;
    public bool _alive = true;

    //Снаряды
    [SerializeField]
    private GameObject[] _fireballsprefab;
    private GameObject _fireball;

    private void Start()
    {
        _alive = true;
    }

    private void Update()
    {
        if (_alive)
        {
            //Непрерывное движение вперёд
            transform.Translate(0, 0, speed * Time.deltaTime);

            //Луч из объекта вперёд
            Ray ray  = new Ray(transform.position, transform.forward);
            RaycastHit hit;//Объект удара

            //Пускаем луч и проверяем
            if (Physics.Raycast(ray, out hit))
            {
                //Получаем объект удара
                GameObject hitObject = hit.transform.gameObject;
                //Если объект удара игрок
                if (hitObject.GetComponent<CharacterController>())
                {
                    if (_fireball == null)
                    {
                        int randFireball = Random.Range(0, _fireballsprefab.Length);
                        _fireball = Instantiate(_fireballsprefab[randFireball]) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);//Направим огненный шар перед врагом
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRande)
                {
                    float angleRotation = Random.Range(-100, 100);//Выбираем угол поворота
                    transform.Rotate(0, angleRotation, 0);// поворачиваемся 
                }
            }
        }
    }


    public void SetAlive(bool Alive)
    {
        _alive = Alive;
    }
}
