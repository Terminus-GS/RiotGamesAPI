﻿using Newtonsoft.Json;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Match
{
    public class MasteryDto
    {
        //
        [JsonProperty("masteryId")]
        public int masteryId { get; set; }

        [JsonProperty("rank")]
        public int rank { get; set; }
    }
}