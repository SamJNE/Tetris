using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridManager : MonoBehaviour
{

    // Piece Shape Structures - 0 denotes an empty space; 17-23 denote sections of the currently falling piece, and its colour.
    // The grid itself also uses values 1-7 to denote sections of the previous pieces, 8 for the border blocks at grid edges,
    // and 9-15 for the "ghost pieces" outlining where the current piece will land.

    static readonly int[,] pieceRed0 = new int[3, 3]
    {
        {17, 17, 00},
        {00, 17, 17},
        {00, 00, 00}
    };
    static readonly int[,] pieceRed1 = new int[3, 3]
    {
        {00, 00, 17},
        {00, 17, 17},
        {00, 17, 00}
    };
    static readonly int[,] pieceRed2 = new int[3, 3]
    {
        {00, 00, 00},
        {17, 17, 00},
        {00, 17, 17}
    };
    static readonly int[,] pieceRed3 = new int[3, 3]
    {
        {00, 17, 00},
        {17, 17, 00},
        {17, 00, 00}
    };

    static readonly int[,] pieceOrange0 = new int[3, 3]
    {
        {00, 00, 18},
        {18, 18, 18},
        {00, 00, 00}
    };
    static readonly int[,] pieceOrange1 = new int[3, 3]
    {
        {00, 18, 00},
        {00, 18, 00},
        {00, 18, 18}
    };
    static readonly int[,] pieceOrange2 = new int[3, 3]
    {
        {00, 00, 00},
        {18, 18, 18},
        {18, 00, 00}
    };
    static readonly int[,] pieceOrange3 = new int[3, 3]
    {
        {18, 18, 00},
        {00, 18, 00},
        {00, 18, 00}
    };

    static readonly int[,] pieceYellow = new int[3, 3]
    {
        {00, 19, 19},
        {00, 19, 19},
        {00, 00, 00}
    };

    static readonly int[,] pieceGreen0 = new int[3, 3]
    {
        {00, 20, 20},
        {20, 20, 00},
        {00, 00, 00}
    };
    static readonly int[,] pieceGreen1 = new int[3, 3]
    {
        {00, 20, 00},
        {00, 20, 20},
        {00, 00, 20}
    };
    static readonly int[,] pieceGreen2 = new int[3, 3]
    {
        {00, 00, 00},
        {00, 20, 20},
        {20, 20, 00}
    };
    static readonly int[,] pieceGreen3 = new int[3, 3]
    {
        {20, 00, 00},
        {20, 20, 00},
        {00, 20, 00}
    };

    static readonly int[,] pieceCyan0 = new int[4, 4]
    {
        {00, 00, 00, 00},
        {21, 21, 21, 21},
        {00, 00, 00, 00},
        {00, 00, 00, 00}
    };
    static readonly int[,] pieceCyan1 = new int[4, 4]
    {
        {00, 00, 21, 00},
        {00, 00, 21, 00},
        {00, 00, 21, 00},
        {00, 00, 21, 00}
    };
    static readonly int[,] pieceCyan2 = new int[4, 4]
    {
        {00, 00, 00, 00},
        {00, 00, 00, 00},
        {21, 21, 21, 21},
        {00, 00, 00, 00}
    };
    static readonly int[,] pieceCyan3 = new int[4, 4]
    {
        {00, 21, 00, 00},
        {00, 21, 00, 00},
        {00, 21, 00, 00},
        {00, 21, 00, 00}
    };

    static readonly int[,] pieceBlue0 = new int[3, 3]
    {
        {22, 00, 00},
        {22, 22, 22},
        {00, 00, 00}
    };
    static readonly int[,] pieceBlue1 = new int[3, 3]
    {
        {00, 22, 22},
        {00, 22, 00},
        {00, 22, 00}
    };
    static readonly int[,] pieceBlue2 = new int[3, 3]
    {
        {00, 00, 00},
        {22, 22, 22},
        {00, 00, 22}
    };
    static readonly int[,] pieceBlue3 = new int[3, 3]
    {
        {00, 22, 00},
        {00, 22, 00},
        {22, 22, 00}
    };

    static readonly int[,] piecePurple0 = new int[3, 3]
    {
        {00, 23, 00},
        {23, 23, 23},
        {00, 00, 00}
    };
    static readonly int[,] piecePurple1 = new int[3, 3]
    {
        {00, 23, 00},
        {00, 23, 23},
        {00, 23, 00}
    };
    static readonly int[,] piecePurple2 = new int[3, 3]
    {
        {00, 00, 00},
        {23, 23, 23},
        {00, 23, 00}
    };
    static readonly int[,] piecePurple3 = new int[3, 3]
    {
        {00, 23, 00},
        {23, 23, 00},
        {00, 23, 00}
    };

    static readonly int[][,] piecesRed = new int[][,] {pieceRed0, pieceRed1, pieceRed2, pieceRed3};
    static readonly int[][,] piecesOrange = new int[][,] {pieceOrange0, pieceOrange1, pieceOrange2, pieceOrange3};
    static readonly int[][,] piecesYellow = new int[][,] {pieceYellow};
    static readonly int[][,] piecesGreen = new int[][,] {pieceGreen0, pieceGreen1, pieceGreen2, pieceGreen3};
    static readonly int[][,] piecesCyan = new int[][,] {pieceCyan0, pieceCyan1, pieceCyan2, pieceCyan3};
    static readonly int[][,] piecesBlue = new int[][,] {pieceBlue0, pieceBlue1, pieceBlue2, pieceBlue3};
    static readonly int[][,] piecesPurple = new int[][,] {piecePurple0, piecePurple1, piecePurple2, piecePurple3};

    string[] colours = new string[] {"Red", "Orange", "Yellow", "Green", "Cyan", "Blue", "Purple"};
    List<string> upcomingPieces = new List<string>();

    // Rotation Offsets - When attempting to rotate, these offsets are used to move the piece to different potential positions

    static readonly (int x, int y)[] cyan0RightOffset = {(0,0), (0,-2), (0,1), (2,1), (-1,-2)};
    static readonly (int x, int y)[] cyan1RightOffset = {(0,0), (0,-1), (0,2), (2,-1), (-1,2)};
    static readonly (int x, int y)[] cyan2RightOffset = {(0,0), (0,2), (0,-1), (1,2), (-1,-1)};
    static readonly (int x, int y)[] cyan3RightOffset = {(0,0), (0,-2), (0,1), (1,-2), (-2,1)};

    static readonly (int x, int y)[] cyan0LeftOffset = {(0,0), (0,2), (0,-1), (2,-1), (-1,2)};
    static readonly (int x, int y)[] cyan1LeftOffset = {(0,0), (0,2), (0,-1), (1,2), (-2,-1)};
    static readonly (int x, int y)[] cyan2LeftOffset = {(0,0), (0,-2), (0,1), (1,-2), (-1,1)};
    static readonly (int x, int y)[] cyan3LeftOffset = {(0,0), (0,1), (0,-2), (2,1), (-1,-2)};
    
    static readonly (int x, int y)[] other0RightOffset = {(0,0), (0,-1), (1,-1), (-2,0), (-2,-1)};
    static readonly (int x, int y)[] other1RightOffset = {(0,0), (0,1), (-1,1), (2,0), (2,1)};
    static readonly (int x, int y)[] other2RightOffset = {(0,0), (0,1), (1,1), (-2,0), (-2,1)};
    static readonly (int x, int y)[] other3RightOffset = {(0,0), (0,-1), (-1,-1), (2,0), (2,-1)};

    static readonly (int x, int y)[] other0LeftOffset = {(0,0), (0,1), (1,1), (-2,0), (-2,1)};
    static readonly (int x, int y)[] other1LeftOffset = {(0,0), (0,1), (-1,1), (2,0), (2,1)};
    static readonly (int x, int y)[] other2LeftOffset = {(0,0), (0,-1), (1,-1), (-2,0), (-2,-1)};
    static readonly (int x, int y)[] other3LeftOffset = {(0,0), (0,-1), (-1,-1), (2,0), (2,-1)};

    // Other Variables

    const int height = 20;  // x  - in all coordinate pairs throughout, the first number denotes the row, and the second the column
    const int width = 10;   // y
    (Image cell, int state)[,] grid = new (Image, int)[height + 2, width + 2];  // the actual grid structure
    public Sprite[] cell_states = new Sprite[16];
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI linesText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    float tickInterval = 1.3f;   // delay before the current piece moves downwards a line
    float moveIntervalLong = 0.4f;   // initial delay between first and second moves, when holding left/right/down
    float moveIntervalShort = 0.05f; // subsequent delay, between second/third/fourth moves
    float lastTick;
    float lastMove;
    float moveStartTime;
    bool moving = false;
    string moveDir = "";
    int score = 0;
    int lines = 0;
    int level = 1;
    int linesPerLevel = 10;
    bool gamePaused = false;
    bool gameOver = false;

    string heldPiece = "";
    bool canHoldPiece = true;

    (int posTop, int posLeft, string colour, int rotation, int[][,] pieceSet, int[,] shape, int size) currentPiece;  // top left corner, shape and size of current piece
    (int x, int y) spawnPos = (21, 4);  // top left point where pieces spawn in
    (int x, int y) ghostPos = (-1, -1);

    private UpdateHoldBox holdBoxScript;
    private UpdateNextBox nextBoxScript;

    // Start is called before the first frame update
    void Start()
    {
        holdBoxScript = GameObject.Find("Hold Box").GetComponent<UpdateHoldBox>();
        nextBoxScript = GameObject.Find("Next Box").GetComponent<UpdateNextBox>();
        lastTick = Time.time;
        lastMove = Time.time;
        InitialiseGridDisplay();
        AddPiecesToQueue();
        SpawnNextPiece();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && !gamePaused)
        {
            // handles the player starting to move
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !moving)
            {
                moving = MoveLeft();
                if (moving)
                {
                    moveDir = "Left";
                    moveStartTime = Time.time;
                    lastMove = Time.time;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && !moving)
            {
                moving = MoveRight();
                if (moving)
                {
                    moveDir = "Right";
                    moveStartTime = Time.time;
                    lastMove = Time.time;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && !moving)
            {
                moving = MoveDown();
                if (moving)
                {
                    IncScore(1);
                    moveDir = "Down";
                    moveStartTime = Time.time;
                    lastMove = Time.time;
                }
            }

            // handles the player holding a movement key
            if (Input.GetKey(KeyCode.LeftArrow) && moveDir == "Left")
            {
                if (Time.time - lastMove > moveIntervalShort && Time.time - moveStartTime > moveIntervalLong)
                {
                    moving = MoveLeft();
                    if (moving)
                    {
                        lastMove = Time.time;
                    }
                    else
                    {
                        moveDir = "";
                    }
                }
            }
            if (Input.GetKey(KeyCode.RightArrow) && moveDir == "Right")
            {
                if (Time.time - lastMove > moveIntervalShort && Time.time - moveStartTime > moveIntervalLong)
                {
                    moving = MoveRight();
                    if (moving)
                    {
                        lastMove = Time.time;
                    }
                    else
                    {
                        moveDir = "";
                    }
                }
            }
            if (Input.GetKey(KeyCode.DownArrow) && moveDir == "Down")
            {
                if (Time.time - lastMove > moveIntervalShort && Time.time - moveStartTime > moveIntervalLong)
                {
                    moving = MoveDown();
                    if (moving)
                    {
                        lastMove = Time.time;
                        IncScore(1);
                    }
                    else
                    {
                        moveDir = "";
                    }
                }
            }

            // handles the player ceasing movement
            if (Input.GetKeyUp(KeyCode.LeftArrow) && moveDir == "Left")
            {
                moving = false;
                moveDir = "";
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) && moveDir == "Right")
            {
                moving = false;
                moveDir = "";
            }
            if (Input.GetKeyUp(KeyCode.DownArrow) && moveDir == "Down")
            {
                moving = false;
                moveDir = "";
            }

            if (Input.GetKeyDown(KeyCode.Z) && !moving)
            {
                bool rotated = RotateLeft();
                if (rotated)
                {
                    lastMove = Time.time;
                }
            }  // triggers anticlockwise rotations
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.X)) && !moving)
            {
                bool rotated = RotateRight();
                if (rotated)
                {
                    lastMove = Time.time;
                }
            }  // triggers clockwise rotations
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DropPiece();
                lastMove = Time.time;
                lastTick = Time.time;
            }  // drops the current piece
            if (Input.GetKeyDown(KeyCode.C) && canHoldPiece)  //
            {
                HoldPiece();
            }  // holds the current piece, if possible

            if (Time.time - lastTick > tickInterval)
            {
                bool moved = MoveDown();
                if (moved)
                {
                    lastTick = Time.time;
                }
                if (!moved && Time.time - lastMove > moveIntervalLong)  // checking lastMove lets player move/rotate the piece on the ground before it locks
                {
                    LockPiece();
                    lastTick = Time.time;
                }
            }
            UpdateGridDisplay();
            //Debug.Log("Moving: " + moving + "; Rotation: " + currentPiece.rotation);
        }
    }

    void SpawnNextPiece()  // spawns the next scheduled piece (as shown in the "next" box)
    {
        string nextPiece = upcomingPieces[0];
        upcomingPieces.RemoveAt(0);
        if (upcomingPieces.Count < 5) // ensures there are always new pieces
        {
            AddPiecesToQueue();
        }
        SpawnPiece(nextPiece);
        nextBoxScript.UpdateSprites(upcomingPieces);
    }

    bool MoveDown()  // attempts to move current piece down once
    {
        bool canMoveDown = IsValidPlace(currentPiece.posTop - 1, currentPiece.posLeft, currentPiece.shape);
        if (canMoveDown)
        {
            UnplacePiece();
            currentPiece.posTop--;
            PlacePiece();
        }
        return canMoveDown;
    }

    bool MoveLeft()  // attempts to move current piece left once
    {
        bool canMoveLeft = IsValidPlace(currentPiece.posTop, currentPiece.posLeft - 1, currentPiece.shape);
        if (canMoveLeft)
        {
            UnplacePiece();
            currentPiece.posLeft--;
            PlacePiece();
            PlaceGhostPiece();
        }
        return canMoveLeft;
    }

    bool MoveRight()  // attempts to move current piece right once
    {
        bool canMoveRight = IsValidPlace(currentPiece.posTop, currentPiece.posLeft + 1, currentPiece.shape);
        if (canMoveRight)
        {
            UnplacePiece();
            currentPiece.posLeft++;
            PlacePiece();
            PlaceGhostPiece();
        }
        return canMoveRight;
    }

    bool RotateLeft() // attempts to rotate current piece anticlockwise, translating it if necessary
    {
        bool canRotateLeft = false;
        if (currentPiece.colour != "Yellow")
        {
            int rotation = currentPiece.rotation;
            (int x, int y)[] offsets = GetOffsets(currentPiece.colour, rotation, "Left");
            rotation = (rotation + 3) % 4;

            int x = 0;
            int y = 0;
            int attempt = 0;

            while (canRotateLeft == false && attempt < 5) // finds first offset that works. If none work, rotation fails.
            {
                x = offsets[attempt].x;
                y = offsets[attempt].y;
                canRotateLeft = IsValidPlace(currentPiece.posTop + x, currentPiece.posLeft + y, currentPiece.pieceSet[rotation]);
                attempt++;
            }

            if (canRotateLeft)
            {
                UnplacePiece();
                currentPiece.shape = currentPiece.pieceSet[rotation];
                currentPiece.rotation = rotation;
                currentPiece.posTop += x;
                currentPiece.posLeft += y;
                PlacePiece();
                PlaceGhostPiece();
            }
        }
        return canRotateLeft;
    }

    bool RotateRight() // attempts to rotate current piece clockwise, translating it if necessary
    {
        bool canRotateRight = false;
        if (currentPiece.colour != "Yellow")
        {
            int rotation = currentPiece.rotation;
            (int x, int y)[] offsets = GetOffsets(currentPiece.colour, rotation, "Right");
            rotation = (rotation + 1) % 4;

            int x = 0;
            int y = 0;
            int attempt = 0;

            while (canRotateRight == false && attempt < 5) // finds first offset that works. If none work, rotation fails.
            {
                x = offsets[attempt].x;
                y = offsets[attempt].y;
                canRotateRight = IsValidPlace(currentPiece.posTop + x, currentPiece.posLeft + y, currentPiece.pieceSet[rotation]);
                attempt++;
            }

            if (canRotateRight)
            {
                UnplacePiece();
                currentPiece.shape = currentPiece.pieceSet[rotation];
                currentPiece.rotation = rotation;
                currentPiece.posTop += x;
                currentPiece.posLeft += y;
                PlacePiece();
                PlaceGhostPiece();
            }
        }
        return canRotateRight;
    }

    bool IsValidPlace(int x, int y, int[,] shape)   // determines if specified piece can be placed at given coordinates
    {
        bool validPlace = true;
        for (int i = 0; i < currentPiece.size; i++)  // iterates through each cell in current piece's bounding box
        {
            for (int j = 0; j < currentPiece.size; j++)
            {
                int row = x - i;
                int column = y + j;
                if (row >= 0 && column >= 0 && column <= width + 1)  // ensures cell is within play area
                {
                    int pieceValue = shape[i, j];
                    int gridValue = grid[row, column].state;
                    if (pieceValue > 0 && gridValue > 0 && gridValue <= 8)  // if a section of the piece would be placed in an occupied cell
                    {
                        validPlace = false;
                    }
                }
            }
        }
        return validPlace;
    }

    void PlacePiece() // adds values in current piece's bounding box to corresponding cells on grid
    {
        for (int i = 0; i < currentPiece.size; i++)  // iterates through each cell in current piece's bounding box
        {
            for (int j = 0; j < currentPiece.size; j++)
            {
                int row = currentPiece.posTop - i;
                int column = currentPiece.posLeft + j;
                if (row >= 0 && column >= 0 && column <= width)  // ensures cell is within play area
                {
                    int pieceValue = currentPiece.shape[i, j];
                    int gridValue = grid[row, column].state;
                    if (pieceValue > 0 && gridValue > 8) // if overwriting a ghost block
                    {
                        grid[row, column].state = pieceValue;
                    }
                    else
                    {
                        grid[row, column].state += pieceValue;
                    }
                }   
            }
        }
    }

    void UnplacePiece() // subtracts values in current piece's bounding box to corresponding cells on grid
    {
        for (int i = 0; i < currentPiece.size; i++)  // iterates through each cell in current piece's bounding box
        {
            for (int j = 0; j < currentPiece.size; j++)
            {
                int row = currentPiece.posTop - i;
                int column = currentPiece.posLeft + j;
                if (row > 0 && column >= 0 && column <= width)  // ensures cell is within play area
                {
                    int pieceValue = currentPiece.shape[i, j];
                    grid[row, column].state -= pieceValue;
                }
            }
        }
    }

    void PlaceGhostPiece() // shows an outline of where the current piece will land, if the player doesn't make any more movements
    {
        // removes previous ghost piece, if existent
        UnplaceGhostPiece();

        // finds lowest row that current piece can descend to
        int row = currentPiece.posTop;
        int column = currentPiece.posLeft;
        bool validPlace = true;
        while (validPlace)
        {
            row--;
            validPlace = IsValidPlace(row, column, currentPiece.shape);
        }
        row++;
        ghostPos.x = row;
        ghostPos.y = column;

        // places ghost blocks in that row
        for (int i = 0; i < currentPiece.size; i++)  // iterates through each cell in current piece's bounding box
        {
            for (int j = 0; j < currentPiece.size; j++)
            {
                int x = row - i;
                int y = column + j;
                if (x >= 0 && y >= 0 && y <= width)  // ensures cell is within play area
                {
                    int pieceValue = currentPiece.shape[i, j];
                    int gridValue = grid[x, y].state;
                    if (pieceValue > 0 && gridValue == 0) // if overwriting a ghost block
                    {
                        grid[x, y].state = pieceValue - 8;
                    }
                }
            }
        }
    }

    void UnplaceGhostPiece()
    {
        if (ghostPos != (-1, -1)) // if ghost piece has been placed
        {
            for (int i = 0; i < currentPiece.size; i++)  // iterates through each cell in current piece's bounding box
            {
                for (int j = 0; j < currentPiece.size; j++)
                {
                    int x = ghostPos.x - i;
                    int y = ghostPos.y + j;
                    if (x >= 0 && y >= 0 && y <= width)  // ensures cell is within play area
                    {
                        int gridValue = grid[x, y].state;
                        if (gridValue > 8 && gridValue < 17) // if ghost block is present
                        {
                            grid[x, y].state = 0;
                        }
                    }
                }
            }
        }
    }

    void HoldPiece()
    {
        string temp = currentPiece.colour;
        UnplacePiece();
        UnplaceGhostPiece();
        if (heldPiece == "") // if this is the first piece the player is holding
        {
            SpawnNextPiece();
        }
        else
        {
            SpawnPiece(heldPiece);
        }
        heldPiece = temp;
        canHoldPiece = false;
        holdBoxScript.UpdateSprite(heldPiece);
    }

    void SpawnPiece(string colour)  // spawns a new piece of a given colour at the top of the board, and resets currentPiece accordingly
    {
        currentPiece.posTop = spawnPos.x;
        currentPiece.posLeft = spawnPos.y;
        currentPiece.colour = colour;
        currentPiece.rotation = 0;
        currentPiece.pieceSet = GetPieceSet(colour);
        currentPiece.shape = currentPiece.pieceSet[0];
        if (colour == "Cyan")
        {
            currentPiece.size = 4;
        }
        else
        {
            currentPiece.size = 3;
        }
        
        if (!IsValidPlace(currentPiece.posTop, currentPiece.posLeft, currentPiece.shape)) 
        {
            gameOver = true;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            Debug.Log("Game Over");                 // if a newly generated piece spawns inside any existing blocks, triggers game over
        }

        // update grid states
        for (int i = 0; i < currentPiece.size; i++)
        {
            for (int j = 0; j < currentPiece.size; j++)
            {
                int row = currentPiece.posTop - i;
                int column = currentPiece.posLeft + j;
                int pieceValue = currentPiece.shape[i, j];
                int gridValue = grid[row, column].state;
                if (pieceValue > 0)
                {
                    grid[row, column].state = pieceValue;
                }
            }
        }
        PlaceGhostPiece();
    }

    void LockPiece() // freezes current piece in place
    {
        for (int i = 0; i < currentPiece.size; i++)
        {
            for (int j = 0; j < currentPiece.size; j++)
            {
                int row = currentPiece.posTop - i;
                int column = currentPiece.posLeft + j;
                int pieceValue = currentPiece.shape[i, j];
                if (row > 0 && column <= width && pieceValue > 0)  // ensures cell is not empty, and within play area
                {
                    grid[row, column].state = pieceValue % 16;
                }   
            }
        }
        canHoldPiece = true;
        StartCoroutine(ClearLines());
    }

    IEnumerator ClearLines()
    {
        List<int> fullLines = new List<int>();
        int linesCleared;
        gamePaused = true;

        // find which lines are full

        for (int x = height + 1; x > 0; x--)
        {
            int filledCells = 0;
            for (int y = 1; y <= width; y++)
            {
                if (grid[x, y].state > 0) // if cell is filled
                {
                    filledCells++;
                }
            }
            if (filledCells == width) // if entire line is filled
            {
                fullLines.Add(x);
            }
        }
        linesCleared = fullLines.Count;

        // score points for line clears

        switch (linesCleared)
        {
            case 1:
                IncLines(1);
                IncScore(100);
                break;
            case 2:
                IncLines(2);
                IncScore(300);
                break;
            case 3:
                IncLines(3);
                IncScore(600);
                break;
            case 4:
                IncLines(4);
                IncScore(1200);
                break;
        }

        // clear full lines

        if (linesCleared > 0)
        {
            for (int i = 1; i <= 8; i++)  // cycles through each of the 7 colours, before setting it to blank
            {
                foreach (int x in fullLines)
                {
                    for (int y = 1; y <= width; y++)
                    {
                        grid[x, y].state = i % 8;
                    }
                }
                UpdateGridDisplay();
                yield return new WaitForSeconds(0.08f);
            }
        }

        // move other lines down

        foreach (int line in fullLines)
        {
            for (int x = line; x <= height; x++)
            {
                for (int y = 1; y <= width; y++)
                {
                    grid[x, y].state = grid[x + 1, y].state;
                }
            }
            for (int y = 1; y <= width; y++) // clears very top line (separated so that it doesn't try to compare to line above it)
            {
                grid[height + 1, y].state = 0;
            }
        }

        UpdateGridDisplay();
        gamePaused = false;
        SpawnNextPiece();
    }

    void DropPiece() // immediately moves current piece down as far as possible, and locks it in place
    {
        UnplacePiece();
        int rowsDropped = currentPiece.posTop - ghostPos.x;
        IncScore(2 * rowsDropped);
        currentPiece.posTop = ghostPos.x;
        currentPiece.posLeft = ghostPos.y;
        PlacePiece();
        LockPiece();
    }

    int[][,] GetPieceSet(string colour)
    {
        switch (colour)
        {
            case "Red":
                return piecesRed;
            case "Orange":
                return piecesOrange;
            case "Yellow":
                return piecesYellow;
            case "Green":
                return piecesGreen;
            case "Cyan":
                return piecesCyan;
            case "Blue":
                return piecesBlue;
            default:
                return piecesPurple;
        }
    }

    (int, int)[] GetOffsets(string colour, int rotation, string direction) // returns appropriate list of offsets, based on what rotation is attempted
    {
        if (colour == "Cyan")
        {
            switch (rotation, direction)
            {
                case (0, "Left"):
                    return cyan0LeftOffset;
                case (0, "Right"):
                    return cyan0RightOffset;
                case (1, "Left"):
                    return cyan1LeftOffset;
                case (1, "Right"):
                    return cyan1RightOffset;
                case (2, "Left"):
                    return cyan2LeftOffset;
                case (2, "Right"):
                    return cyan2RightOffset;
                case (3, "Left"):
                    return cyan3LeftOffset;
                default:
                    return cyan3RightOffset;
            }
        }
        else
        {
            switch (rotation, direction)
            {
                case (0, "Left"):
                    return other0LeftOffset;
                case (0, "Right"):
                    return other0RightOffset;
                case (1, "Left"):
                    return other1LeftOffset;
                case (1, "Right"):
                    return other1RightOffset;
                case (2, "Left"):
                    return other2LeftOffset;
                case (2, "Right"):
                    return other2RightOffset;
                case (3, "Left"):
                    return other3LeftOffset;
                default:
                    return other3RightOffset;
            }
        }
    }
    
    void UpdateGridDisplay()
    {
        for (int x = 1; x <= height; x++)
        {
            for (int y = 1; y <= width; y++)
            {
                int state = grid[x, y].state % 16;
                grid[x, y].cell.sprite = cell_states[state];
            }
        }
    }

    void InitialiseGridDisplay()
    {
        for (int x = 0; x < height + 2; x++)
        {
            for (int y = 0; y < width + 2; y++)
            {
                GameObject NewObj = new GameObject();
                Image NewImage = NewObj.AddComponent<Image>();
                NewObj.GetComponent<RectTransform>().SetParent(gameObject.transform, false);
                NewObj.name = "(" + x + "," + y + ")";
                if (x == 0 || y == 0 || x > height || y > width)
                {
                    grid[x, y].state = 8;    // sets borders
                }
                else
                {
                    grid[x, y].state = 0;   // sets interior as empty
                }
                NewImage.sprite = cell_states[grid[x, y].state];
                grid[x, y].cell = NewImage;

                if (x > height && y > 0 && y <= width)   // sets top border as empty, but still appearing to contain border blocks
                {
                    grid[x, y].state = 0;
                }

                NewObj.SetActive(true);
            }
        }
    }

    void AddPiecesToQueue()
    {
        Shuffle(colours);
        foreach (string colour in colours)
        {
            upcomingPieces.Add(colour);
        }
    }

    void Shuffle(string[] deck)
    {
        for (int i = 0; i < deck.Length; i++)
        {
            string temp = deck[i];
            int randomIndex = Random.Range(i, deck.Length);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    void IncScore(int increase)
    {
        score += (increase * level);
        scoreText.text = "Score:\n" + score;
    }

    void IncLines(int increase)
    {
        lines += increase;
        linesText.text = "Lines:\n" + lines;

        level = (lines / linesPerLevel) + 1;
        levelText.text = "Level:\n" + level;
        tickInterval = Mathf.Max(1.4f - (level * 0.1f),   3.5f / (level + 2.5f));  // decreases interval by 0.1s for each early level, then slows down once interval is at ~0.3s
    }

    public void RestartGame()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        gameOver = false;
        ClearGrid();
        lastTick = Time.time;
        lastMove = Time.time;
        score = 0;
        lines = 0;
        level = 1;
        scoreText.text = "Score:\n" + score;
        linesText.text = "Lines:\n" + lines;
        levelText.text = "Level:\n" + level;
        tickInterval = 1.3f;
        heldPiece = "";
        holdBoxScript.UpdateSprite("Empty");
        upcomingPieces.Clear();
        AddPiecesToQueue();
        SpawnNextPiece();
    }

    void ClearGrid()
    {
        for (int x = 1; x <= height + 1; x++)
        {
            for (int y = 1; y <= width; y++)
            {
                grid[x, y].state = 0;
            }
        }
    }
}
