using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;

namespace RiotGamesApi.Interfaces
{
    public interface IFor<T> where T : new() { IAddParameter<T> For(LolApiMethodName middleType); }
}