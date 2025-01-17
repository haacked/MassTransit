namespace MassTransit
{
    using Middleware;
    using Middleware.InMemoryOutbox;
    using Transports;


    static class InternalOutboxExtensions
    {
        internal static ISendEndpoint SkipOutbox(this ISendEndpoint endpoint)
        {
            if (endpoint is ConsumeSendEndpoint consumeSendEndpoint)
                endpoint = consumeSendEndpoint.Endpoint;

            if (endpoint is OutboxSendEndpoint outboxSendEndpoint)
                endpoint = outboxSendEndpoint.Endpoint;

            if (endpoint is Middleware.Outbox.OutboxSendEndpoint outboxEndpoint)
                return outboxEndpoint.Endpoint;

            return endpoint;
        }

        internal static ConsumeContext SkipOutbox(this ConsumeContext context)
        {
            while (context.TryGetPayload<InMemoryOutboxConsumeContext>(out var outboxConsumeContext))
                context = outboxConsumeContext.CapturedContext;

            while (context.TryGetPayload<OutboxConsumeContext>(out var outboxConsumeContext))
                context = outboxConsumeContext.CapturedContext;

            return context;
        }
    }
}
