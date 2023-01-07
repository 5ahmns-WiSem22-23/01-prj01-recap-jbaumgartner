using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    float minRange;

    [SerializeField]
    float maxRange;

    [SerializeField]
    GameObject item;

    [SerializeField]
    Text itemCountDisplay;

    [SerializeField]
    Text timeDisplay;

    public static int itemCount;

    float time;

    [SerializeField]
    float maxTime;

    void Start()
    {
        //Spawn bei Start
         SpawnItem();
    }

    void Update()
    {
        // Über die Delta Time kann unabhängig von der FrameRate ein Timer gebaut werden
        time += Time.deltaTime;

        // Wenn die Zeit abgelaufen ist, soll das Spiel neu beginnen
        if(time >= maxTime)
        {
            SceneManager.LoadScene(0);
            itemCount = 0;
        }

        // Der Timer und der Score sollen jeden Frame angezeigt werden
        timeDisplay.text = Mathf.Round(maxTime - time).ToString() + " sec. left"; ;
        itemCountDisplay.text = "Score: " + itemCount.ToString();
    }

    public void SpawnItem()
    {
        //durch random range wird bei spawnen von Item die Item-Position random 
        Instantiate(item, new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), 0), Quaternion.identity);
    }
}
