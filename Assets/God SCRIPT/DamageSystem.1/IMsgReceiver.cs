using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMsgReceiver<Type,Data>
{
    void ReceiverMsg(Data data, object sender, Type type);
}
