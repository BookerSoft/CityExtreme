using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
namespace CityExtreme.Base.Gui{
    public class TextField : Drawable
    {
        FloatRect bounds = new FloatRect();
        Text Label,InputField;
        bool inMe, inInputField,inputBegun,inputEnded;

        public TextField(string labelmsg,Vector2f LabelPos){
            Label = new Text(labelmsg,Support.b.defFont,25);
            InputField = new Text("Enter "+labelmsg+":",Support.b.defFont,25);
            bounds.Top = LabelPos.Y;
            bounds.Left = LabelPos.X;
            bounds.Height = Label.GetGlobalBounds().Height;
            bounds.Width = Label.GetGlobalBounds().Width + InputField.GetGlobalBounds().Width;
            Label.Position = LabelPos;

            InputField.Position = new Vector2f(bounds.Left+Label.GetGlobalBounds().Width,bounds.Top);
            inMe = false;
            inInputField = false;
            inputBegun = false;
            inputEnded= false;
        }
        public void SetInputDisplayedStr(string s){
            InputField.DisplayedString = s;

        }
        public void MouseMoved(object? sender , MouseMoveEventArgs e){
            if(bounds.Contains((float)e.X,(float)e.Y)){
                inMe =true;
                if(InputField.GetGlobalBounds().Contains((float)e.X,e.Y)){
                    inInputField =true;
                }

            }
        }
        public void MouseClick(object? sender ,MouseButtonEventArgs e){
            if(inMe && inInputField && e.Button == Mouse.Button.Left){
                inputBegun = true;
                InputField.DisplayedString = "";
            }
        }
        public void TextEvent(object? sender, TextEventArgs e){
            if(e.Unicode != "\r" && e.Unicode != "\b" && inputBegun){
                InputField.DisplayedString += e.Unicode;

            }else if(e.Unicode =="\b" && InputField.DisplayedString.Length>0 && inputBegun){
                InputField.DisplayedString.Remove(InputField.DisplayedString.Length-1,-1);
            }
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Label);
            if(inputBegun)
            target.Draw(InputField);
            else
            target.Draw(InputField);

        
        }
    }
}