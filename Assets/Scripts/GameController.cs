using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
   public static GameController gc;
        public TMP_Text ringsText;
        public TMP_Text starText;
        public TMP_Text lifeText;
        public int Rings;
        public int Star;
        public int lives = 3;

    void Awake()
    {
        if (gc == null)
        {
            gc = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(gc != this) 
        {
            Destroy(gameObject);
        }
        RefreshScreen();
    }
    public void SetLives(int life){
        lives += life;
        if(lives >=0)
            RefreshScreen();
    }
    public void RefreshScreen()
    {
        ringsText.text = Rings.ToString();
        lifeText.text = lives.ToString();
    }

}
