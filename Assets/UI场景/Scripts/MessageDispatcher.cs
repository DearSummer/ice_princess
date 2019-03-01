//-------------------------------------------
//  author: Billy
//  description:  
//-------------------------------------------

using System.Collections.Generic;

namespace FairySpring
{
    public class MessageDispatcher
    {
        #region 构造函数
        private static volatile MessageDispatcher mInstance;

        public static MessageDispatcher Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock (typeof(MessageDispatcher))
                    {
                        if (mInstance == null)
                            mInstance = new MessageDispatcher();
                    }

                }
                return mInstance;

            }
        }

        private MessageDispatcher()
        {
            handlerMap = new Dictionary<string, MessageHandlerCollection>();
            messageQuene = new Queue<Message>();
        }
#endregion

        private Dictionary<string, MessageHandlerCollection> handlerMap = new Dictionary<string, MessageHandlerCollection>();
        private Queue<Message> messageQuene = new Queue<Message>();

        public void Update()
        {
            if (messageQuene == null || messageQuene.Count == 0)
            {
                return;
            }

            Message message = messageQuene.Dequeue();
            handlerMap[message.MessageId].DispatcherMessage(message.Sender, message.Param, message.ExceptCallback);

            if (message.TargetCallback != null)
            {
                handlerMap[message.MessageId]
                    .DispatcherMessageTo(message.Sender, message.Param, message.TargetCallback);
            }

        }

        /// <summary>
        /// 清除内存
        /// </summary>
        public void Dispose()
        {
            messageQuene.Clear();
            messageQuene = null;

            foreach (var key in handlerMap.Keys)
            {
                handlerMap[key].Dispose();   
            }

            handlerMap.Clear();
            handlerMap = null;
        }

        public void AddMessageHandler(string messageId, IMessageCallback callback)
        {
            if (callback == null)
            {
                return;
            }

            if (handlerMap.ContainsKey(messageId))
            {
                handlerMap[messageId].AddHandler(callback);
            }
            else
            {
                MessageHandlerCollection messageHandler = new MessageHandlerCollection();
                messageHandler.AddHandler(callback);
                handlerMap.Add(messageId,messageHandler);
            }
        }

        public void RemoveMessageHandler(string messageId, IMessageCallback callback)
        {
            if (callback == null || !handlerMap.ContainsKey(messageId))
            {
                return;
            }

            handlerMap[messageId].RemoveHandler(callback);
            if (handlerMap[messageId].Count == 0)
            {
                handlerMap.Remove(messageId);
            }
        }

        public void DispatchMessage(string messageId, object sender)
        {
            if (!handlerMap.ContainsKey(messageId))
            {
                return;
            }

            DispatchMessage(messageId, sender, null, null, null);
        }

        public void DispatchMessage(string messageId, object sender, object param)
        {
            if (!handlerMap.ContainsKey(messageId))
            {
                return;
            }

            DispatchMessage(messageId, sender, param, null, null);
        }


        public void DispatchMessage(string messageId, object sender, object param, IMessageCallback exceptCallback)
        {
            if (!handlerMap.ContainsKey(messageId))
            {
                return;
            }

            DispatchMessage(messageId, sender, param, exceptCallback, null);
        }

        private void DispatchMessage(string messageId, object sender, object param, IMessageCallback exceptCallback,
            IMessageCallback targetCallback)
        {
            Message message = new Message()
            {
                MessageId = messageId,
                Sender = sender,
                Param = param,
                ExceptCallback = exceptCallback,
                TargetCallback = targetCallback
            };
            messageQuene.Enqueue(message);
        }

        public void DispatchMessageTo(string messageId, IMessageCallback callback, object sender, object param = null)
        {
            DispatchMessage(messageId, sender, param, null, callback);
        }



        private struct Message
        {
            public string MessageId;
            public object Sender;
            public object Param;
            public IMessageCallback ExceptCallback;
            public IMessageCallback TargetCallback;
        }


        private class MessageHandlerCollection
        {
            public int Count
            {
                get { return _callbackList.Count; }
            }

            private List<IMessageCallback> _callbackList;


            public MessageHandlerCollection()
            {
                _callbackList = new List<IMessageCallback>();
            }

            public void AddHandler(IMessageCallback callback)
            {
                if (!_callbackList.Contains(callback))
                {
                    _callbackList.Add(callback);
                }
            }

            public void RemoveHandler(IMessageCallback callback)
            {
                _callbackList.Remove(callback);
            }

            public void DispatcherMessage(object sender, object param)
            {
                foreach (var item in _callbackList)
                {
                    item.ReciveMessage(sender,param);
                }
            }

            public void DispatcherMessageTo(object sender, object param, IMessageCallback target)
            {
                foreach (var item in _callbackList)
                {
                    if (item == target)
                    {
                        item.ReciveMessage(sender,param);
                    }
                }
            }

            public void DispatcherMessage(object sender, object param, IMessageCallback except)
            {
                foreach (var item in _callbackList)
                {
                    if (item != except)
                    {
                        item.ReciveMessage(sender,param);
                    }
                }
            }

            public void Dispose()
            {
                _callbackList.Clear();
                _callbackList = null;
            }
        }
    }

}
