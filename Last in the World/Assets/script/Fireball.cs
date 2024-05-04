using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;//Скорость движения
    public int damage = 1;//Наносимый урон

    private void Update()
    {
        //У огненого шара постоянное движение вперёд
        transform.Translate(0,0, speed*Time.deltaTime);
    }

    //Когда с тригером столкнётся другой объект, вызывается метод
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(damage);
        }

        Destroy(this.gameObject);
    }
}
