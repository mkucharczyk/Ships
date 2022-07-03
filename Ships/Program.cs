// See https://aka.ms/new-console-template for more information

using Ships;

var gameManager = new GameManager(10);

gameManager.InitializeGame(1, 1);
while(!gameManager.IsGameOver())
    gameManager.GameLoop();

gameManager.GameOver();
