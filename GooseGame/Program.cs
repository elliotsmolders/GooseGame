using GooseGame.Business;

GameEngine engine = new GameEngine();

NewGame();
void NewGame()
{
    engine.Init();
}
void RestoreGame()
{
    engine.Restore();
}