using System;

public interface IEventBroker {
    public void SubscribeTo<TMessage>(Action<TMessage> callBack);
    public void UnSubscribeFrom<TMessage>(Action<TMessage> callBack);
    public void Send<TMessage>(TMessage callback);
}