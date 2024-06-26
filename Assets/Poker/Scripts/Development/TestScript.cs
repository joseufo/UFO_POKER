using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
	public Sprite frontSprite;
	public Sprite backSprite;
	public float uncoverTime = 12.0f;

	// Use this for initialization
	void Start()
	{

		return;
		GameObject card = new GameObject("Card"); // parent object
		GameObject cardFront = new GameObject("CardFront");
		GameObject cardBack = new GameObject("CardBack");

		cardFront.transform.parent = card.transform; // make front child of card
		cardBack.transform.parent = card.transform; // make back child of card

		// front (motive)
		cardFront.AddComponent<SpriteRenderer>();
		cardFront.GetComponent<SpriteRenderer>().sprite = frontSprite;
		cardFront.GetComponent<SpriteRenderer>().sortingOrder = -1;

		// back
		cardBack.AddComponent<SpriteRenderer>();
		cardBack.GetComponent<SpriteRenderer>().sprite = backSprite;
		cardBack.GetComponent<SpriteRenderer>().sortingOrder = 1;

		int cardWidth = (int)frontSprite.rect.width;
		int cardHeight = (int)frontSprite.rect.height;

		Debug.Log(cardWidth);
		Debug.Log(cardHeight);

		card.tag = "Card";
		card.transform.parent = transform;
		card.transform.position = transform.position;
		card.AddComponent<BoxCollider2D>();
		card.GetComponent<BoxCollider2D>().size = new Vector2(cardWidth, cardHeight);

		Debug.Log("Start done");
	}

	public Transform card;
	// Update is called once per frame
	bool uncover = false;
	void Update()
	{
		if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
			// we hit a card
			if (uncover == false) uncover = true; else uncover = false;
			StartCoroutine(RotShowCard(card, uncover));
			if (hit.collider != null)
			{
				Debug.Log(hit.collider.gameObject.name);
				//StartCoroutine(uncoverCard(hit.collider.gameObject.transform, true));
			}
		}
	}

	IEnumerator uncoverCard(Transform card, bool uncover)
	{

		float minAngle = uncover ? 0 : 180;
		float maxAngle = uncover ? 180 : 0;

		float t = 0;
		bool uncovered = false;

		while (t < 1f)
		{
			t += Time.deltaTime * uncoverTime; ;

			float angle = Mathf.LerpAngle(minAngle, maxAngle, t);
			card.eulerAngles = new Vector3(0, angle, 0);

			if (((angle >= 90 && angle < 180) || (angle >= 270 && angle < 360)) && !uncovered)
			{
				uncovered = true;
				for (int i = 0; i < card.childCount; i++)
				{
					// reverse sorting order to show the otherside of the card
					// otherwise you would still see the same sprite because they are sorted 
					// by order not distance (by default)
					Transform c = card.GetChild(i);
					c.GetComponent<SpriteRenderer>().sortingOrder *= -1;

					yield return null;
				}
			}

			yield return null;
		}

		yield return 0;
	}

	IEnumerator RotShowCard(Transform card, bool uncover)
	{

		float minAngle = uncover ? 0 : 180;
		float maxAngle = uncover ? 180 : 0;
		card.gameObject.GetComponent<SpriteRenderer>().flipX = true;
		float t = 0;
		bool uncovered = false;

		while (t < 1f)
		{
			t += Time.deltaTime * uncoverTime; ;

			float angle = Mathf.LerpAngle(minAngle, maxAngle, t);
			card.eulerAngles = new Vector3(0, angle, 0);

			if (((angle >= 90 && angle < 180) || (angle >= 270 && angle < 360)) && !uncovered)
			{
				uncovered = true;
                if (uncover) { 
				card.gameObject.GetComponent<SpriteRenderer>().sprite = frontSprite;
				card.gameObject.GetComponent<SpriteRenderer>().flipX = true;}
                else {
					card.gameObject.GetComponent<SpriteRenderer>().sprite = backSprite;
					card.gameObject.GetComponent<SpriteRenderer>().flipX = false;
				}
                for (int i = 0; i < card.childCount; i++)
				{
					// reverse sorting order to show the otherside of the card
					// otherwise you would still see the same sprite because they are sorted 
					// by order not distance (by default)
					//Transform c = card.GetChild(i);
					//c.GetComponent<SpriteRenderer>().sortingOrder *= -1;

					yield return null;
				}
			}

			yield return null;
		}

		yield return 0;
	}

	class Player
	{
		public int Chips { get; set; }
		public int TotalBet { get; set; }
		public Hand Hand { get; set; }
	}

	class Hand
	{
		// define hand ranking methods here
	}

	class PokerGame
	{
		private List<Player> players;
		private List<int> pots;

		public void AllocatePot(List<Player> winners)
		{
			// Allocate main pot to winners
			int mainPotSize = pots[0];
			int mainPotShare = mainPotSize / winners.Count;
			foreach (Player winner in winners)
			{
				winner.Chips += mainPotShare;
			}
			int remainingChips = mainPotSize % winners.Count;

			// Allocate side pots to winners
			for (int i = 1; i < pots.Count; i++)
			{
				int sidePotSize = pots[i];
				List<Player> eligiblePlayers = new List<Player>();
				foreach (Player player in players)
				{
					if (player.TotalBet >= sidePotSize)
					{
						eligiblePlayers.Add(player);
					}
				}
				int sidePotShare = sidePotSize / eligiblePlayers.Count;
				foreach (Player winner in winners)
				{
					if (eligiblePlayers.Contains(winner))
					{
						winner.Chips += sidePotShare;
					}
				}
				remainingChips += sidePotSize % eligiblePlayers.Count;
			}

			// Return any remaining chips (if the pot couldn't be split evenly)
			//return remainingChips;
		}
	}
}
