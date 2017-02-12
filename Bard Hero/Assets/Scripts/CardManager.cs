using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour {

    public List<GameObject> warriorDeck;        //setup decks in inspector
    public List<GameObject> mageDeck;
    public List<GameObject> healerDeck;

    public List<int> deadHands = new List<int>();

    public GameObject warriorCardInHand;
    public GameObject mageCardInHand;
    public GameObject healerCardInHand;
    public GameObject highlight;

    public NoteGenerator noteGenerator;
    public PlayNoteSensor playNoteSensor;

    public int cardsInHand = 3;
    public float cardSpacing = 1.0f;
    

    private bool strummed = false;
    private int selectedIndex;
    private GameObject selectedCard;

    private Transform handPosition;
    private Transform deckPosition;

	// Use this for initialization
	void Start () {
        handPosition = transform.Find("Hand");
        DrawWarriorCard();
        DrawMageCard();
        DrawHealerCard();
        UpdateHandPositions();
    }
	
	// Update is called once per frame
	void Update () {
        CardSelectInput();

        if (deadHands.Count == 3)
        {
            GameOver();
        }
	}

    void DrawWarriorCard()
    {
        int draw = Random.Range(0, warriorDeck.Count);
        GameObject card = Instantiate(warriorDeck[draw]);
        card.transform.parent = handPosition;
        warriorCardInHand = card;
        
    }

    void DrawMageCard()
    {
        int draw = Random.Range(0, mageDeck.Count);
        GameObject card = Instantiate(mageDeck[draw]);
        card.transform.parent = handPosition;
        mageCardInHand = card;
        
    }

    void DrawHealerCard()
    {
        int draw = Random.Range(0, healerDeck.Count);
        GameObject card = Instantiate(healerDeck[draw]);
        card.transform.parent = handPosition;
        healerCardInHand = card;
        
    }

    void UpdateHandPositions ()
    {
        warriorCardInHand.transform.position = handPosition.position + new Vector3(cardSpacing * 0, 0, 0);
        mageCardInHand.transform.position = handPosition.position + new Vector3(cardSpacing * 1, 0, 0);
        healerCardInHand.transform.position = handPosition.position + new Vector3(cardSpacing * 2, 0, 0);
    }

    void CardSelectInput()
    {
        if ((Input.GetAxis("StrumGuitar") < -0.5 || Input.GetAxisRaw("Horizontal") > 0.5) && strummed == false)
        {
            strummed = true;
            selectedIndex = (selectedIndex + 1) % cardsInHand;
            highlight.transform.position = handPosition.position + new Vector3(cardSpacing * selectedIndex, 0, 0);
            Debug.Log("SelectedIndex" + selectedIndex);

        }
        if ((Input.GetAxis("StrumGuitar") > 0.5 || Input.GetAxisRaw("Horizontal") < -0.5) && strummed == false)
        {
            strummed = true;
            selectedIndex = (selectedIndex - 1) % cardsInHand;
            if (selectedIndex < 0)
            {
                selectedIndex = 2;
            }
            highlight.transform.position = handPosition.position + new Vector3(cardSpacing * selectedIndex, 0, 0);
            Debug.Log("SelectedIndex" + selectedIndex);

        }
        if (Input.GetButtonDown("Fret1") || Input.GetButtonDown("StrumKey"))
        {
            if (!deadHands.Contains(selectedIndex)) { 
                playCard(selectedIndex);
            }
        }

        if (Input.GetAxis("StrumGuitar") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            strummed = false;
        }


        
    }

    void playCard(int selectedIndex)
    {
        GameObject selectedCard = null;
        Debug.Log("Playing index" + selectedIndex);
        if (selectedIndex == 0)
        {
            selectedCard = warriorCardInHand;
            DrawWarriorCard();
        }
        else if (selectedIndex == 1)
        {
            selectedCard = mageCardInHand;
            DrawMageCard();
        }
        else if (selectedIndex == 2)
        {
            selectedCard = healerCardInHand;
            DrawHealerCard();
        }

        Destroy(selectedCard);
        UpdateHandPositions();

        CardInfo info = selectedCard.GetComponent<CardInfo>();
        NoteChart noteChart = NoteCharts.getChartByTitle(info.cardTitle);


        if (info.characterClass == CharacterClass.Warrior)
        {
            Debug.Log("Picking warrior sounds");
            playNoteSensor.currentSound = playNoteSensor.guitarNote;
        }
        else if (info.characterClass == CharacterClass.Mage){
            Debug.Log("Picking mage sounds");
            playNoteSensor.currentSound = playNoteSensor.bassNote;
        }
        else if (info.characterClass == CharacterClass.Healer)
        {
            Debug.Log("Picking healer sounds");
            playNoteSensor.currentSound = playNoteSensor.fluteNote;
        }
        noteGenerator.playSong(info.cardTitle, 0.25f, 1000.0f);
        gameObject.SetActive(false);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win()
    {
        Debug.Log("Win");
        SceneManager.LoadScene("WinScene");
    }
}
