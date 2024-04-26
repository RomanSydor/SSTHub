namespace SSTHub.Common.RabbitMQContracts
{
    public interface IEmailMessage
    {
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
