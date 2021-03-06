﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.Libraries.Lol.v3.TournamentEndPoints
{
    public class SummonerIdParams
    {
        //the tournament participants
        [JsonProperty("participants")]
        public List<long> participants { get; set; }
    }
}