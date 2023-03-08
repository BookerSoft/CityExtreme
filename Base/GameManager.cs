using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
namespace CityExtreme.Base{
    public class GameManager{
        public Player[] players;
        public GameManager(int maxplayers){
            players =new Player[maxplayers];
            

        }
    }
}