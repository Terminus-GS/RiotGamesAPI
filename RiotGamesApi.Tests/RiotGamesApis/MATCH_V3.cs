﻿using System.Collections.Generic;
using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Match;
using RiotGamesApi.Models;
using RiotGamesApi.Tests.Others;
using Xunit;

namespace RiotGamesApi.Tests.RiotGamesApis
{
	public class MATCH_V3 : BaseTestClass
	{
		[Fact]
		public void GetMatchesByOnlyMatchId()
		{
			var rit = new ApiCall()
				.SelectApi<MatchDto>(LolApiName.Match)
				.For(LolApiMethodName.Matches)
				.AddParameter(new ApiParameter(LolApiPath.OnlyMatchId, MatchId))//not tested
				.Build(Service_Platform)
				.Get();
			if (rit.HasError)
				Assert.Equal("Data not found:404", rit.Exception.Message);
			else
				Assert.False(rit.HasError);
		}

		[Fact]
		public void GetMatchesByAccount()
		{
			var rit = new ApiCall()
				.SelectApi<MatchlistDto>(LolApiName.Match)
				.For(LolApiMethodName.MatchLists)
				.AddParameter(new ApiParameter(LolApiPath.ByAccount, AccountId))
				.Build(Service_Platform)
				.Get(
				new QueryParameter("beginIndex", 10),
				new QueryParameter("champion", 25),
				new QueryParameter("champion", 2),
				new QueryParameter("endIndex", 25)
				);
			Assert.False(rit.HasError);
			Assert.Equal(rit.Result.matches.Count, 15);
		}

		[Fact]
		public void GetMatchesByAccount_Second()
		{
			var rit = LolApi.NonStaticApi.Matchv3
				.GetMatchListsByAccount(Service_Platform, AccountId,
				null, null, 10, null, null,
				new List<int>() { 25, 2 }, 25);

			Assert.False(rit.HasError);
			Assert.Equal(rit.Result.matches.Count, 15);
		}

		[Fact]
		public void GetMatchesByAccountRecent()
		{
			var rit = new ApiCall()
				.SelectApi<MatchlistDto>(LolApiName.Match)
				.For(LolApiMethodName.MatchLists)
				.AddParameter(new ApiParameter(LolApiPath.ByAccountRecent, AccountId))//not tested
				.Build(Service_Platform)
				.Get();
			Assert.False(rit.HasError);
		}

		[Fact]
		public void GetMatcheTimelineByMatch()
		{
			var rit = new ApiCall()
				.SelectApi<MatchTimelineDto>(LolApiName.Match)
				.For(LolApiMethodName.Timelines)
				.AddParameter(new ApiParameter(LolApiPath.ByMatch, MatchId))//not tested
				.Build(Service_Platform)
				.Get();
			if (rit.HasError)
				Assert.Equal("Data not found:404", rit.Exception.Message);
			else
				Assert.False(rit.HasError);
		}

		[Fact]
		public void GetMatchesByTornamentCodeIds()
		{
			var rit = new ApiCall()
				.SelectApi<List<long>>(LolApiName.Match)
				.For(LolApiMethodName.Matches)
				.AddParameter(new ApiParameter(LolApiPath.ByTournamentCodeIds, TournamentCode))//not tested
				.Build(Service_Platform)
				.Get();
			Assert.False(rit.HasError);
		}

		[Fact]
		public void GetMatchesByTornamentCode()
		{
			var rit = new ApiCall()
				.SelectApi<MatchDto>(LolApiName.Match)
				.For(LolApiMethodName.Matches)
				.AddParameter(
					new ApiParameter(LolApiPath.OnlyMatchId, MatchId),
					new ApiParameter(LolApiPath.ByTournamentCode, TournamentCode))//not tested
				.Build(Service_Platform)
				.Get();
			Assert.False(rit.HasError);
		}
	}
}