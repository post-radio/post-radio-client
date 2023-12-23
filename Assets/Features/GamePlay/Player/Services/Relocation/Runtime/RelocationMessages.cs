using Common.DataTypes.Network;
using GamePlay.Network.Messaging.REST.Runtime;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;

namespace GamePlay.Player.Services.Relocation.Runtime
{
    public class RelocationRandomRequest : NetworkEvent, IMessage
    {
        public RelocationRandomRequest()
        {
            _id = new MessageId();
            
            Construct(_id);
        }
        
        private readonly MessageId _id;

        public IMessageId RequestId => _id;
    }
    
    public class RelocationRandomResponse : NetworkEvent, IMessage
    {
        public RelocationRandomResponse()
        {
            _id = new MessageId();
            CellId = new NetworkInt(0, 1000);
            
            Construct(CellId, _id);
        }
        
        public RelocationRandomResponse(int cellId)
        {
            CellId = new NetworkInt(0, 1000, cellId);
            _id = new MessageId();
            
            Construct(CellId, _id);
        }
        
        private readonly MessageId _id;

        public readonly NetworkInt CellId;

        public IMessageId RequestId => _id;
    }
    
    public class RelocationTargetRequest : NetworkEvent, IMessage
    {
        public RelocationTargetRequest()
        {
            _id = new MessageId();
            CellId = new NetworkInt(0, 1000);
            
            Construct(CellId, _id);
        }
        
        public RelocationTargetRequest(int cellId)
        {
            CellId = new NetworkInt(0, 1000, cellId);
            _id = new MessageId();
            
            Construct(CellId, _id);
        }
        
        private readonly MessageId _id;

        public readonly NetworkInt CellId;

        public IMessageId RequestId => _id;
    }
    
    public class RelocationTargetResponse : NetworkEvent, IMessage
    {
        public RelocationTargetResponse()
        {
            _id = new MessageId();
            Result = new NetworkBool();
            
            Construct(Result, _id);
        }
        
        public RelocationTargetResponse(bool value)
        {
            Result = new NetworkBool(value);
            _id = new MessageId();
            
            Construct(Result, _id);
        }
        
        private readonly MessageId _id;

        public readonly NetworkBool Result;

        public IMessageId RequestId => _id;
    }
}