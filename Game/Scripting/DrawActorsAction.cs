using System;
using System.Collections.Generic;
using cse210_finalProject.Game.Casting;
using cse210_finalProject.Game.Services;

namespace cse210_finalProject.Game.Scripting
{
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public override void Execute(Cast cast, Script script)
        {
            Player player = (Player)cast.GetFirstActor("player");
            Platform platform = (Platform)cast.GetFirstActor("platform");
            List<Actor> platforms = platform.GetSegments();
            Coin coin = (Coin)cast.GetFirstActor("coin");
            Spike spike = (Spike)cast.GetFirstActor("spike");
            List<Actor> spikes = spike.GetSegments();
            Actor score = cast.GetFirstActor("score");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActor(player);
            videoService.DrawActors(platforms);
            videoService.DrawActor(coin);
            videoService.DrawActors(spikes);
            videoService.DrawActor(score);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}
