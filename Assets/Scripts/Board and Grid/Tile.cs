using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
	public static Color selectedColor = new Color(.5f, .5f, .5f, 1.0f);
	public static Tile previousSelected = null;

	public SpriteRenderer render;
	public bool isSelected = false;

	public Vector2[] adjacentDirections = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
    public List<string> adjdir = new List<string>(new string[]{"up","down","left","right"});
	public bool matchFound = false;
    public int gridPositionX;
    public int gridPositionY;

	void Awake() {
		render = GetComponent<SpriteRenderer>();
    }

	public void Select() {
		isSelected = true;
		render.color = selectedColor;
		previousSelected = gameObject.GetComponent<Tile>();
		SFXManager.instance.PlaySFX(Clip.Select);
	}

	public void Deselect() {
		isSelected = false;
		render.color = Color.white;
		previousSelected = null;
	}
    public void setGridPosition(int x, int y){
        gridPositionX = x;
        gridPositionY = y;
    }

    public string getGridPosition(){
        string gridPosString = "Grid Position - X: " + gridPositionX + ", Y: " + gridPositionY;
        return gridPosString;
    }
	void OnMouseDown() {
	// 1
    if (render.sprite == null || BoardManager.instance.IsShifting) {
        return;
    }

    if (isSelected) { // 2 Is it already selected?
        Deselect();
    } else {
        if (previousSelected == null) { // 3 Is it the first tile selected?
            Select();
        } else {
                    if (GetAllAdjacentTiles().Contains(previousSelected.gameObject)) { // 1
                            SwapSprite(previousSelected.render); // 2
                            previousSelected.ClearAllMatches();
                            previousSelected.Deselect();
                            ClearAllMatches();
                    } else { // 3
                            previousSelected.GetComponent<Tile>().Deselect();
                            Select();
                    }
				}

    }
	}

	public void SwapSprite(SpriteRenderer render2) { // 1
        if (render.sprite == render2.sprite) { // 2
            return;
        }

        Sprite tempSprite = render2.sprite; // 3
        render2.sprite = render.sprite; // 4
        render.sprite = tempSprite; // 5
        SFXManager.instance.PlaySFX(Clip.Swap); // 6
            GUIManager.instance.MoveCounter--;
	}

    public GameObject GetAdjacentTile(string direction){
        GameObject adjacentTile;
        switch(direction){
            case "up": // Y+1
                // Debug.Log("x,y: " + (gridPositionX).ToString() + ", "+ (gridPositionY+1).ToString());
                if ((gridPositionY+1) > 7){
                    return null;
                }
                adjacentTile = BoardManager.tiles[gridPositionX,gridPositionY+1];
                return adjacentTile;               
            case "down":
                // Debug.Log("x,y: " + (gridPositionX).ToString() + ", "+ (gridPositionY-1).ToString());
                if ((gridPositionY-1) < 0){
                    return null;
                }
                adjacentTile = BoardManager.tiles[gridPositionX,gridPositionY-1];
                return adjacentTile;    
            case "left":
                // Debug.Log("x,y: " + (gridPositionX-1).ToString() + ", "+ gridPositionY.ToString());
                if ((gridPositionX-1) < 0){
                    return null;
                }
                adjacentTile = BoardManager.tiles[gridPositionX-1,gridPositionY];
                return adjacentTile;            
            case "right": //X+1
                // Debug.Log("x,y: " + (gridPositionX+1).ToString() + ", "+ (gridPositionY).ToString());
                if ((gridPositionX+1) > 7){
                    return null;
                }
                adjacentTile = BoardManager.tiles[gridPositionX+1,gridPositionY];
                return adjacentTile;       
            default:
                return null;
        }
    }
	public List<GameObject> GetAllAdjacentTiles() {
    List<GameObject> adjacentTiles = new List<GameObject>();
    for (int i = 0; i < adjacentDirections.Length; i++) {
        adjacentTiles.Add(GetAdjacentTile(adjdir[i]));
    }
    return adjacentTiles;
	}

	public List<GameObject> FindMatch(string direction) { // 1
        List<GameObject> matchingTiles = new List<GameObject>(); // 2

        GameObject tileGameObject = GetAdjacentTile(direction);
        while (tileGameObject != null && tileGameObject.GetComponent<SpriteRenderer>().sprite.name.Split('-')[0] == render.sprite.name.Split('-')[0]) { // change render.sprite to change level
            matchingTiles.Add(tileGameObject.gameObject);
            Debug.Log("old Tile - " + tileGameObject.GetComponent<Tile>().getGridPosition());
            tileGameObject = tileGameObject.GetComponent<Tile>().GetAdjacentTile(direction);
        }

        foreach(GameObject adjTile in matchingTiles) {
            Debug.Log("FindMatch: "+ adjTile.GetComponent<Tile>().render.sprite.name);
        }
        return matchingTiles; // 5
	}	
    
    public void ClearMatch(string[] paths) // 1
	{
        List<GameObject> matchingTiles = new List<GameObject>(); // 2            
        for (int i = 0; i < paths.Length; i++) // 3
        { 
            matchingTiles.AddRange(FindMatch(paths[i]));
        }
        if (matchingTiles.Count >= 2) // 4
        {
            for (int i = 0; i < matchingTiles.Count; i++) // 5
            {
                matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;
            }
            matchFound = true; // 6
        }
	}

	public void ClearAllMatches() {
    if (render.sprite == null)
        return;

    ClearMatch(new string[]{"left","right"});
    ClearMatch(new string[]{"up","down"});
    if (matchFound) {
        render.sprite = null;
        matchFound = false;
				StopCoroutine(BoardManager.instance.FindNullTiles());
				StartCoroutine(BoardManager.instance.FindNullTiles());
        SFXManager.instance.PlaySFX(Clip.Clear);
    }
	}

}



