using System;
using cse210_finalProject.Game.Casting;
using cse210_finalProject.Game.Directing;
using cse210_finalProject.Game.Scripting;
using cse210_finalProject.Game.Services;

namespace cse210_finalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            cast.AddActor("platform", new Platform());
            cast.AddActor("player", new Player(cast));
            cast.AddActor("coin", new Coin(cast));
            cast.AddActor("spike", new Spike(cast));
            cast.AddActor("score", new Score());

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}
