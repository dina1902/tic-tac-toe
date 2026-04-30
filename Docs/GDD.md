# Desciption
A local multiplayer Tic-Tac-Toe game built with simple 3D objects for the board, X, and O.
Players take turns clicking cells to place their mark. The game handles turn switching, valid and invalid moves, win/draw detection, session score tracking, and a result popup at the end of each round.
Player actions and game results are supported by sounds for valid and invalid moves

# Requirements
- Playable local TIC-TAC-TOE GAME
- Visual interface
- Working Results popup
- Working sounds

# Elements
- Cell
- Board
- SoundManager
- GameManager
- Score View
- Result Popup
- New Game Button

```mermaid
sequenceDiagram
    Player ->> Cell : Click on cell
    Cell ->> Board : Placement requested
    Board ->> SoundManager : Play success/failure sound
    Board ->> Cell : Place X or O
    Board ->> GameManager : Report move result
    GameManager ->> GameManager : Is game ended
    GameManager ->> ResultPopup : Show results
```

# Dependencies

All communication goes through `GameEvents`, a single static event aggregator. No business class references another — they only know about `GameEvents`. The only remaining structural reference is `Board` owning its `Cell[]` for state queries.

```mermaid
graph TD
    Cell -- raises CellClicked --> GameEvents
    Board -- raises MoveMade / InvalidMove / GameWon / GameDrawn<br/>subscribes CellClicked --> GameEvents
    SoundManager -- subscribes MoveMade / InvalidMove / GameWon / GameDrawn --> GameEvents
    GameManager -- raises ScoreChanged / ResultReady<br/>subscribes GameWon / GameDrawn --> GameEvents
    ScoreView -- subscribes ScoreChanged --> GameEvents
    ResultPopup -- subscribes ResultReady --> GameEvents
    Board -. owns .-> Cell
```