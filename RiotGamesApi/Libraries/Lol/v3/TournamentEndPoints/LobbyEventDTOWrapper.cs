﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.Libraries.Lol.v3.TournamentEndPoints
{
    public class LobbyEventDTOWrapper
    {
        [JsonProperty("eventList")]
        public List<LobbyEventDTO> eventList { get; set; }
    }
}