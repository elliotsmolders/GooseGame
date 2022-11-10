using GooseGame.Business;

GameBoard board = GameBoard.GetGameBoard();
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
engine.Run();