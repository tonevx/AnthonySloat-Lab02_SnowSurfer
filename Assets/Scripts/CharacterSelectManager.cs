using UnityEngine;

public class CharacterSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject dinoSprite;
    [SerializeField] GameObject frogSprite;
    [SerializeField] GameObject cloudSprite;
    
    Movement movement;
    void Start()
    {
       Time.timeScale = 0; 
       movement = FindAnyObjectByType<Movement>();
    }

    void BeginGame()
    {
        Time.timeScale = 1f;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseDino()
    {
       dinoSprite.SetActive(true); 
       BeginGame();
    }
    public void ChooseFrog()
    {
        frogSprite.SetActive(true);
        BeginGame();
    }
    public void ChooseCloud()
    {
        cloudSprite.SetActive(true);
        movement.circleCollider2D.offset = new Vector2(0.23f, 1.18f);
        BeginGame();
    }
}
