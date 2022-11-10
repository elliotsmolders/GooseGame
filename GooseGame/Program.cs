using GooseGame.Business;

GameBoard board = GameBoard.GetGameBoard();
Dice dice = new Dice();
GameEngine engine = new GameEngine(board, dice);

NewGame();
void NewGame()
{
    engine.Init();
    engine.Run();
}
void RestoreGame()
{
    engine.Restore();
}