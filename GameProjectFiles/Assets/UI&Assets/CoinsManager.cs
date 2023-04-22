using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using DG.Tweening;
using System.Collections.Generic;
using DG.Tweening;

public class CoinsManager : MonoBehaviour
{
	//References
	[Header ("UI references")]
	[SerializeField] Text coinUIText;
	[SerializeField] GameObject animatedCoinPrefab;
	[SerializeField] Transform target;
	public static CoinsManager Instance;
	
	[Space]
	[Header ("Available coins : (coins to pool)")]
	[SerializeField] int maxCoins;
	Queue<GameObject> coinsQueue = new Queue<GameObject> ();


	[Space]
	[Header ("Animation settings")]
	[SerializeField] [Range (0.5f, 0.9f)] float minAnimDuration;
	[SerializeField] [Range (0.9f, 2f)] float maxAnimDuration;

	[SerializeField] Ease easeType;
    [SerializeField] float spread;

	Vector3 targetPosition;


	private int _c = 0;

	public int Coins {
		get{ return _c; }
		set {
			_c = value;
			//update UI text whenever "Coins" variable is changed
			coinUIText.text = Coins.ToString ();
		}
	}
    public bool isactive = false;
	void Awake ()
	{
		Instance = this;
		targetPosition = target.position;

		//prepare pool
		PrepareCoins ();
	}
    private void Update()
    {
        if (isactive==true)
        {
            AddCoins(animatedCoinPrefab.transform.position, 7);
            AddCoins(animatedCoinPrefab.transform.position, 7);



            //Show (+7) number
            Destroy(Instantiate(animatedCoinPrefab, animatedCoinPrefab.transform.position, Quaternion.identity), 1f);
            isactive = false;
        }
        
    }
    private void Start()
    {
        
    }
    void PrepareCoins ()
	{
		GameObject coin;
		for (int i = 0; i < maxCoins; i++) {
			coin = Instantiate (animatedCoinPrefab);
			coin.transform.parent = transform;
			coin.SetActive (false);
			coinsQueue.Enqueue (coin);
		}
	}

	public void Animate (Vector3 collectedCoinPosition, int amount)
	{
		for (int i = 0; i < amount; i++) {
			//check if there's coins in the pool
			if (coinsQueue.Count > 0) {
				//extract a coin from the pool
				GameObject coin = coinsQueue.Dequeue ();
                coin.SetActive(true);

                //move coin to the collected coin pos
                coin.transform.position =coin.transform.position + new Vector3 (Random.Range (-spread, spread), 0f, 0f);

				//animate coin to target position
				float duration = Random.Range (minAnimDuration, maxAnimDuration);
                //LeanTween.scale(coin,new Vector3(1,1,0f), duration).setEase(easeType);
                coin.transform.DOLocalMove(targetPosition,duration).SetEase(easeType).OnComplete(() => {


                    //executes whenever coin reach target position
                    coin.SetActive(false);
                    coinsQueue.Enqueue (coin);
                    //Coins++;
                });
			}
		}
	}

	public void AddCoins (Vector3 collectedCoinPosition, int amount)
	{
		Animate (collectedCoinPosition, amount);
	}
}
