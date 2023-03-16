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
        RectangleShape[,] compIconPartSm = new RectangleShape[5,3],compIconPartLg=new RectangleShape[5,3];
        Text[] OpenSlot = new Text[6];
        bool[] compvisible =new bool[6];
        int aitosel=-1,curslot=-1;
        Player[] selectedPlayers = new Player[6];
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
            
            for(int i=0;i<compIconPartSm.GetLength(0);i++){
                compvisible[i] = false;
                for(int j=0;j<compIconPartSm.GetLength(1);j++){
                    if(j==0){
                        compIconPartSm[i,j] = new RectangleShape(new Vector2f(50,50));
                        compIconPartLg[i,j] = new RectangleShape(new Vector2f(100,100));

                    }else if(j==1){
                        compIconPartSm[i,j] = new RectangleShape(new Vector2f(30,30));
                        compIconPartLg[i,j] = new RectangleShape(new Vector2f(80,80));
                    }else if(j==2){
                        compIconPartSm[i,j] = new RectangleShape(new Vector2f(50,20));
                        compIconPartLg[i,j] = new RectangleShape(new Vector2f(100,20));

                    }
                }
            }
            
            if(Support.b.w != null){
                Title.Position = new Vector2f(Support.b.w.Size.X/4,0);
                Cancel.Position = new Vector2f(Support.b.w.Size.X/4,Support.b.w.Size.Y-(Cancel.GetGlobalBounds().Height*2));
                Start.Position = new Vector2f(Cancel.Position.X+Cancel.GetGlobalBounds().Width+250,Cancel.Position.Y);
                
                playerRect[0].Size = new Vector2f(Support.b.w.Size.X/6.15f,Support.b.w.Size.Y/3);
                playerRect[0].Position = new Vector2f(1,Support.b.w.Size.Y*.25f);

                playerPicBox[0] = new RectangleShape();
                playerPicBox[0].Position = new Vector2f(playerRect[0].GetGlobalBounds().Left+20,playerRect[0].GetGlobalBounds().Top+10);
                playerPicBox[0].Size = new Vector2f(playerRect[0].GetGlobalBounds().Width-40,playerRect[0].GetGlobalBounds().Height*.725f);
                playerPicBox[0].FillColor = Color.Blue;
                playerNames[0] = new Text("NoName",Support.b.defFont,25);
                playerNames[0].FillColor = Color.White;
                playerNames[0].Position = new Vector2f(playerRect[0].GetGlobalBounds().Width*.35f,playerRect[0].GetGlobalBounds().Top+playerRect[0].GetGlobalBounds().Height*.80f);
                float prectwidth = playerRect[0].GetGlobalBounds().Width;
                for(int i=1;i<playerRect.Length;i++){
                    playerRect[i] = new RectangleShape();
                playerRect[i].OutlineColor = Color.White;
                playerRect[i].FillColor = Color.Transparent;
                playerRect[i].OutlineThickness = .25f;
                    playerRect[i].Size = playerRect[i-1].Size;
                    playerRect[i].Position = new Vector2f(playerRect[i-1].Position.X+playerRect[i-1].GetGlobalBounds().Width,playerRect[i-1].Position.Y);
                    playerPicBox[i] = new RectangleShape();
                playerPicBox[i].Position = new Vector2f(playerRect[i].GetGlobalBounds().Left+20,playerRect[i].GetGlobalBounds().Top+10);
                playerPicBox[i].Size = new Vector2f(playerRect[i].GetGlobalBounds().Width-40,playerRect[i].GetGlobalBounds().Height*.725f);
                playerPicBox[i].FillColor = Color.Blue;
                playerNames[i] = new Text("NoName",Support.b.defFont,25);
                playerNames[i].FillColor = Color.White;
                playerNames[i].Position = new Vector2f((i*prectwidth)+ playerRect[i].GetGlobalBounds().Width*.35f,playerRect[i].GetGlobalBounds().Top+playerRect[i].GetGlobalBounds().Height*.80f);
                if(i==1){
                    OpenSlot[i-1] = new Text("O",Support.b.defFont,25);
                OpenSlot[i-1].Position = new Vector2f(playerRect[i-1].GetGlobalBounds().Left+5, playerNames[i-1].Position.Y);
                OpenSlot[i-1].FillColor = Color.White;
                OpenSlot[i] = new Text("O",Support.b.defFont,25);
                OpenSlot[i].Position = new Vector2f(playerRect[i].GetGlobalBounds().Left+5, playerNames[i].Position.Y);
                OpenSlot[i].FillColor = Color.White;

                }else{
                    OpenSlot[i] = new Text("O",Support.b.defFont,25);
                OpenSlot[i].Position = new Vector2f(playerRect[i].GetGlobalBounds().Left+5, playerNames[i].Position.Y);
                OpenSlot[i].FillColor = Color.White;
                }
                

                }
            }
        }
        public void MouseClick(object? sender, MouseButtonEventArgs e){
            if(e.Button == Mouse.Button.Left){
                if(Cancel.GetGlobalBounds().Contains((float)e.X,(float)e.Y)){
                    Support.b.menupg = 0;

                }else if(OpenSlot != null){
                    for(int h =0;h<OpenSlot.Length;h++){
                        if(OpenSlot[h].GetGlobalBounds().Contains((float)e.X,(float)e.Y)){
                            
                            for(int i=0;i<compvisible.Length;i++){
                                if(!compvisible[i]){
                                    compvisible[i] = true;
                                    Random r = new Random();
                                    aitosel = (int)r.Next(0,10);
                                    
                                        if(selectedPlayers[h] == null){
                                            selectedPlayers[h] = Support.b.AiPlayers[aitosel];
                                            playerNames[h].DisplayedString = selectedPlayers[h].Name;
                                        }
                                    

                                }
                            }

                        }
                    }

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
            foreach(Text pn in playerNames){
                foreach(bool cv in compvisible){
                    if(cv){
                       target.Draw(pn);
                    }else{
                        target.Draw(pn);
                    }
                }
            }
            foreach(Text os in OpenSlot){
                target.Draw(os);
            }
        }
    }
}