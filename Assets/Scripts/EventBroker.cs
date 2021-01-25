using System;
using System.Collections.Generic;

public class EventBroker : IEventBroker {
    static EventBroker _instance;
    readonly Dictionary<Type, object> subscribers = new Dictionary<Type, object>();
    public static EventBroker Instance() {
        return _instance ??= new EventBroker();
    }

    public void SubscribeTo<TMessage>(Action<TMessage> callBack) {
        if (subscribers.TryGetValue(typeof(TMessage), out var oldSubscribers)) {
            callBack = (oldSubscribers as Action<TMessage>) + callBack;
        }
        
        subscribers[typeof(TMessage)] = callBack;
    }

    public void UnSubscribeFrom<TMessage>(Action<TMessage> callBack) {
        if (subscribers.TryGetValue(typeof(TMessage), out var oldSubscribers)) {
            callBack = (oldSubscribers as Action<TMessage>) - callBack;
            
            if (callBack != null)
                subscribers[typeof(TMessage)] = callBack;
            else
                subscribers.Remove(typeof(TMessage));
        }
    }

    public void Send<TMessage>(TMessage callback) {
        if (subscribers.TryGetValue(typeof(TMessage), out var currentSubscribers)) {
            (currentSubscribers as Action<TMessage>)?.Invoke(callback);
        }
    }
}
