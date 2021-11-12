using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {
	public static BoardManager instance;     // 1
	public List<Sprite> characters = new List<Sprite>(); 
	public List<Sprite> characters_level_1 = new List<Sprite>(); 
	public List<Sprite> characters_level_2 = new List<Sprite>(); 
	public List<Sprite> characters_level_3 = new List<Sprite>();

	public List<Sprite> bird_list= new List<Sprite>();
	public List<Sprite> bird_list_1= new List<Sprite>();
	public List<Sprite> bird_list_2= new List<Sprite>();
	public List<Sprite> bird_list_3= new List<Sprite>();
	public List<Sprite> insect_list= new List<Sprite>();
	public List<Sprite> insect_list_1= new List<Sprite>();
	public List<Sprite> insect_list_2= new List<Sprite>();
	public List<Sprite> insect_list_3= new List<Sprite>();
	public List<Sprite> mammal_list= new List<Sprite>();
	public List<Sprite> mammal_list_1= new List<Sprite>(); 
	public List<Sprite> mammal_list_2= new List<Sprite>(); 
	public List<Sprite> mammal_list_3= new List<Sprite>(); 
	public List<Sprite> fish_list= new List<Sprite>();
	public List<Sprite> fish_list_1= new List<Sprite>();
	public List<Sprite> fish_list_2= new List<Sprite>();  
	public List<Sprite> fish_list_3= new List<Sprite>();    

	public GameObject tile;      // 3
	public int xSize, ySize;     // 4

	public static GameObject[,] tiles;      // 5

	public bool IsShifting { get; set; }     // 6

	void Start () {
			instance = GetComponent<BoardManager>();     // 7
			tiles = new GameObject[xSize, ySize];

			Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
			CreateBoard(offset.x, offset.y); 
	}

	public void CreateBoard (float xOffset, float yOffset) {
			// tiles = new GameObject[xSize, ySize];     // 9

			float startX = transform.position.x;     // 10
			float startY = transform.position.y;

			Sprite[] previousLeft = new Sprite[ySize];
    	Sprite previousBelow = null;

			for (int x = 0; x < xSize; x++) {      // 11
					for (int y = 0; y < ySize; y++) {
							GameObject newTile = Instantiate(tile, new Vector3(startX + (xOffset * x * 1.05f), startY +                                                                 (yOffset * y * 1.05f), 0), tile.transform.rotation);
							tiles[x, y] = newTile;
							newTile.transform.parent = transform; // 1
							newTile.GetComponent<Tile>().setGridPosition(x,y);
							List<Sprite> possibleCharacters = new List<Sprite>(); // 1

							// add switch case depending on level to click in
							switch (GameManager.level) {
								case 1:
									characters = characters_level_1;
									bird_list = bird_list_1;
									insect_list = insect_list_1;
									mammal_list = mammal_list_1;
									fish_list = fish_list_1;
									break;
								case 2:
									characters = characters_level_2;
									bird_list = bird_list_2;
									insect_list = insect_list_2;
									mammal_list = mammal_list_2;
									fish_list = fish_list_2;
									break;
								case 3:
									characters = characters_level_3;
									bird_list = bird_list_3;
									insect_list = insect_list_3;
									mammal_list = mammal_list_3;
									fish_list = fish_list_3;
									break;
								default:
									characters = characters_level_1;
									bird_list = bird_list_1;
									insect_list = insect_list_1;
									mammal_list = mammal_list_1;
									fish_list = fish_list_1;
									break;
							}
							possibleCharacters.AddRange(characters);

							// add switch case here to remove from the possible characters
							if (bird_list.Contains(previousLeft[y])) {
								foreach (UnityEngine.Sprite bird in bird_list) {
									possibleCharacters.Remove(bird);
								}
							} else if (insect_list.Contains(previousLeft[y])) {
								foreach (UnityEngine.Sprite insect in insect_list) {
									possibleCharacters.Remove(insect);
								}
							} else if (mammal_list.Contains(previousLeft[y])) {
								foreach (UnityEngine.Sprite mammal in mammal_list) {
									possibleCharacters.Remove(mammal);
								}
							} else if (fish_list.Contains(previousLeft[y])) {
								foreach (UnityEngine.Sprite fish in fish_list) {
									possibleCharacters.Remove(fish);
								}
							}

							if (bird_list.Contains(previousBelow)) {
								foreach (UnityEngine.Sprite bird in bird_list) {
									possibleCharacters.Remove(bird);
								}
							} else if (insect_list.Contains(previousBelow)) {
								foreach (UnityEngine.Sprite insect in insect_list) {
									possibleCharacters.Remove(insect);
								}
							} else if (mammal_list.Contains(previousBelow)) {
								foreach (UnityEngine.Sprite mammal in mammal_list) {
									possibleCharacters.Remove(mammal);
								}
							} else if (fish_list.Contains(previousBelow)) {
								foreach (UnityEngine.Sprite fish in fish_list) {
									possibleCharacters.Remove(fish);
								}
							}
							Sprite newSprite = possibleCharacters[Random.Range(0, possibleCharacters.Count)];
							newTile.GetComponent<SpriteRenderer>().sprite = newSprite; // 3
							previousLeft[y] = newSprite;
							previousBelow = newSprite;

					}
			}
	}
	
	public IEnumerator FindNullTiles() {
    for (int x = 0; x < xSize; x++) {
        for (int y = 0; y < ySize; y++) {
            if (tiles[x, y].GetComponent<SpriteRenderer>().sprite == null) {
                yield return StartCoroutine(ShiftTilesDown(x, y));
                break;
            }
        }
    }
		for (int x = 0; x < xSize; x++) {
    	for (int y = 0; y < ySize; y++) {
        tiles[x, y].GetComponent<Tile>().ClearAllMatches();
    	}
		}

	}

	public IEnumerator ShiftTilesDown(int x, int yStart, float shiftDelay = .03f) {
    IsShifting = true;
    List<SpriteRenderer>  renders = new List<SpriteRenderer>();
    int nullCount = 0;

    for (int y = yStart; y < ySize; y++) {  // 1
        SpriteRenderer render = tiles[x, y].GetComponent<SpriteRenderer>();
        if (render.sprite == null) { // 2
            nullCount++;
        }
        renders.Add(render);
    }

    for (int i = 0; i < nullCount; i++) { // 3
				GUIManager.instance.Score += 50;
        yield return new WaitForSeconds(shiftDelay);// 4
        for (int k = 0; k < renders.Count - 1; k++) { // 5
            renders[k].sprite = renders[k + 1].sprite;
            renders[k + 1].sprite = GetNewSprite(x, ySize - 1);
        }
    }
    IsShifting = false;
	}

	public Sprite GetNewSprite(int x, int y) {
    List<Sprite> possibleCharacters = new List<Sprite>();
    possibleCharacters.AddRange(characters);
		UnityEngine.Sprite sprite;
    if (x > 0) {
			sprite = tiles[x - 1, y].GetComponent<SpriteRenderer>().sprite;
			if (bird_list.Contains(sprite)) {
				foreach (UnityEngine.Sprite bird in bird_list) {
					possibleCharacters.Remove(bird);
				}
			} else if (insect_list.Contains(sprite)) {
				foreach (UnityEngine.Sprite insect in insect_list) {
					possibleCharacters.Remove(insect);
				}
			} else if (mammal_list.Contains(sprite)) {
				foreach (UnityEngine.Sprite mammal in mammal_list) {
					possibleCharacters.Remove(mammal);
				}
			} else if (fish_list.Contains(sprite)) {
				foreach (UnityEngine.Sprite fish in fish_list) {
					possibleCharacters.Remove(fish);
				}
			}
    }
    if (x < xSize - 1) {
			sprite = tiles[x + 1, y].GetComponent<SpriteRenderer>().sprite;
      if (bird_list.Contains(sprite)) {
				foreach (UnityEngine.Sprite bird in bird_list) {
					possibleCharacters.Remove(bird);
				}
			} else if (insect_list.Contains(sprite)) {
				foreach (UnityEngine.Sprite insect in insect_list) {
					possibleCharacters.Remove(insect);
				}
			} else if (mammal_list.Contains(sprite)) {
				foreach (UnityEngine.Sprite mammal in mammal_list) {
					possibleCharacters.Remove(mammal);
				}
			} else if (fish_list.Contains(sprite)) {
				foreach (UnityEngine.Sprite fish in fish_list) {
					possibleCharacters.Remove(fish);
				}
			}
    }
    if (y > 0) {
			sprite = tiles[x, y-1].GetComponent<SpriteRenderer>().sprite;
      if (bird_list.Contains(sprite)) {
				foreach (UnityEngine.Sprite bird in bird_list) {
					possibleCharacters.Remove(bird);
				}
			} else if (insect_list.Contains(sprite)) {
				foreach (UnityEngine.Sprite insect in insect_list) {
					possibleCharacters.Remove(insect);
				}
			} else if (mammal_list.Contains(sprite)) {
				foreach (UnityEngine.Sprite mammal in mammal_list) {
					possibleCharacters.Remove(mammal);
				}
			} else if (fish_list.Contains(sprite)) {
				foreach (UnityEngine.Sprite fish in fish_list) {
					possibleCharacters.Remove(fish);
				}
			}
    }

    return possibleCharacters[Random.Range(0, possibleCharacters.Count)];
	}


}
