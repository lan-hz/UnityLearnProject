using System.Linq;
using UnityEngine;


public class AnimalCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        Debug.Log($"AnimalCollision: {gameObject.name} collided with {other.gameObject.name}");

        var list = GameManager.Instance.animalTemp;
        var cmd = list.FirstOrDefault(x => x.obj == gameObject);
        if (cmd != null)
        {
            cmd.enable = false;
            cmd.obj.SetActive(false);
            GameManager.Instance.animalTemp.Remove(cmd);
        }

        var listFood = GameManager.Instance.foodTemp;
        var foodCmd = listFood.FirstOrDefault(x => x.obj == other.gameObject);
        if (foodCmd != null)
        {
            foodCmd.enable = false;
            foodCmd.obj.SetActive(false);
            GameManager.Instance.foodTemp.Remove(foodCmd);
        }

    }
}
