﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Owin;
using Microsoft.Extensions.DependencyInjection;
using RiotGamesApi.Cache;
using RiotGamesApi.RateLimit;

namespace RiotGamesApi.AspNet
{
    public static class Extension
    {
        /// <summary>
        /// necessary for using LeagueOfLegendsApi 
        /// </summary>
        /// <param name="services">
        /// </param>
        /// <param name="riotApiKey">
        /// RiotGames DeveloperKey or ProductionKey 
        /// </param>
        /// <exception cref="Exception">
        /// A delegate callback throws an exception. 
        /// </exception>
        public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey)
        {
            RiotGamesApi.Extension2.AddLeagueOfLegendsApi(services, riotApiKey, null, null);
        }

        /// <summary>
        /// necessary for using LeagueOfLegendsApi 
        /// </summary>
        /// <param name="services">
        /// </param>
        /// <param name="riotApiKey">
        /// RiotGames DeveloperKey or ProductionKey 
        /// </param>
        /// <param name="cacheOption">
        /// custom api caching options (default: ApiCaching is NOT USED ) 
        /// </param>
        /// <exception cref="Exception">
        /// A delegate callback throws an exception. 
        /// </exception>
        public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey,
            Func<CacheOption, CacheOption> cacheOption)
        {
            RiotGamesApi.Extension2.AddLeagueOfLegendsApi(services, riotApiKey, cacheOption, null);
        }

        /// <exception cref="Exception">
        /// A delegate callback throws an exception. 
        /// </exception>
        public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey,
            Func<RateLimitData, RateLimitData> rateLimitOption2)
        {
            RiotGamesApi.Extension2.AddLeagueOfLegendsApi(services, riotApiKey, null, rateLimitOption2);
        }

        /// <summary>
        /// necessary for using RiotGamesApi.AspNetCore wrapper 
        /// </summary>
        /// <param name="app">
        /// </param>
        /// <returns>
        /// </returns>
        public static IAppBuilder UseRiotGamesApi(this IAppBuilder app, IServiceCollection services)
        {
            IServiceProvider sProvider = services.BuildServiceProvider();
            var resolver = new DefaultDependencyResolver(sProvider);
            DependencyResolver.SetResolver(resolver);
            sProvider.UseRiotGamesApiServiceProvider();
            return app;
        }
    }
}