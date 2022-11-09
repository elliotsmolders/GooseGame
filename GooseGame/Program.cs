using GooseGame.Business;

GameEngine engine = new GameEngine();

void NewGame()
{
    engine.Init();
}
void RestoreGame()
{
    engine.Restore();
}
engine.Run();

var gameBoard = GameBoard.GetGameBoard();