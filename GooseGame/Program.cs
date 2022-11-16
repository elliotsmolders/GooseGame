using GooseGame.Business;

GameBoard board = new GameBoard();
GameEngine engine = new GameEngine(board);

NewGame();
void NewGame()
{
    engine.Init();
}
void RestoreGame()
{
    engine.Restore();
}