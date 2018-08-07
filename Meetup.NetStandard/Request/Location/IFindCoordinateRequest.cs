namespace Meetup.NetStandard.Request.Location
{
    public interface IFindCoordinateRequest : IFindRequestPager<IFindCoordinateRequest>
    {
        IFindExecutor AndByName(string name);
    }
}