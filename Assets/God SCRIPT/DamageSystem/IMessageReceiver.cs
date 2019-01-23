/// <summary>
/// 消息接受者
/// </summary>
/// <typeparam name="Type">接受的消息的类型</typeparam>
/// <typeparam name="Data">接受的数据的类型</typeparam>
public interface IMessageReceiver<Type, Data>
{
    void ReceiverMessage(Type type, object sender, Data data);
}
