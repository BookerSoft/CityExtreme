using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
namespace CityExtreme.Base.PreGame_Menu{
    public class Lobby_FE : Drawable
    {
        Text[] playerNames = new Text[6];
        RectangleShape[] playerRect=new RectangleShape[6];
        RectangleShape[] playerPicBox = new RectangleShape[6];
        Text Title,Cancel,Start;
        public Lobby_FE(ContextSettings cs){
            Title = new Text("Configure "+ Support.b.curobjective+" Session",Support.b.defFont,70);
            Title.FillColor = Color.White;
            Cancel = new Text("Leave Game",Support.b.defFont,35);
            Cancel.FillColor = Color.White;
            Start = new Text("Start Game",Support.b.defFont,35);
            Start.FillColor = Color.White;
            playerRect[0] = new RectangleShape();
            playerRect[0].OutlineColor = Color.White;
            playerRect[0].FillColor = Color.Transparent;
            playerRect[0].OutlineThickness = .25f;
            if(Support.b.w != null){
                Title.Position = new Vector2f(Support.b.w.Size.X/4,0);
                Cancel.Position = new Vector2f(Support.b.w.Size.X/4,Support.b.w.Size.Y-(Cancel.GetGlobalBounds().Height*2));
                Start.Position = new Vector2f(Cancel.Position.X+Cancel.GetGlobalBounds().Width+250,Cancel.Position.Y);
                
                playerRect[0].Size = new Vector2f(Support.b.w.Size.X/6,Support.b.w.Size.Y/3);
                playerRect[0].Position = new Vector2f(10,Support.b.w.Size.Y*.25f);
            }
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Title);
            target.Draw(Cancel);
            target.Draw(Start);
            target.Draw(playerRect[0]);
        }
    }
}