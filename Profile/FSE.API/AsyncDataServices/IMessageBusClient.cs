namespace FSE.API.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishProfileUpdates(ProfileUpdatedDTO profileUpdatedDTO);
    }
}
