namespace TechnicalTests
{
    public interface ISessionManager
    {
        ISession Get(string sessionKey);

        void Set(ISession session);
    }
}
