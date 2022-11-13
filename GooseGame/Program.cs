using GooseGame.Business;

GameEngine engine = new GameEngine(board);

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