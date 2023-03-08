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
                
                playerRect[0].Size = new Vector2f(Support.b.w.Size.X/6.15f,Support.b.w.Size.Y/3);
                playerRect[0].Position = new Vector2f(1,Support.b.w.Size.Y*.25f);
                playerPicBox[0] = new RectangleShape();
                playerPicBox[0].Position = new Vector2f(playerRect[0].GetGlobalBounds().Left,playerRect[0].GetGlobalBounds().Top);
                playerPicBox[0].Size = new Vector2f(playerRect[0].GetGlobalBounds().Width,playerRect[0].GetGlobalBounds().Height*.75f);
                playerPicBox[0].FillColor = Color.Blue;

                for(int i=1;i<playerRect.Length;i++){
                    playerRect[i] = new RectangleShape();
                playerRect[i].OutlineColor = Color.White;
                playerRect[i].FillColor = Color.Transparent;
                playerRect[i].OutlineThickness = .25f;
                    playerRect[i].Size = playerRect[i-1].Size;
                    playerRect[i].Position = new Vector2f(playerRect[i-1].Position.X+playerRect[i-1].GetGlobalBounds().Width,playerRect[i-1].Position.Y);
                    playerPicBox[i] = new RectangleShape();
                playerPicBox[i].Position = new Vector2f(playerRect[i].GetGlobalBounds().Left,playerRect[i].GetGlobalBounds().Top);
                playerPicBox[i].Size = new Vector2f(playerRect[i].GetGlobalBounds().Width,playerRect[i].GetGlobalBounds().Height*.75f);
                playerPicBox[i].FillColor = Color.Blue;


                }
            }
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Title);
            target.Draw(Cancel);
            target.Draw(Start);
            foreach(RectangleShape pr in playerRect){
                target.Draw(pr);
            }
            foreach(RectangleShape ppb in playerPicBox){
                target.Draw(ppb);
            }
        }
    }
}