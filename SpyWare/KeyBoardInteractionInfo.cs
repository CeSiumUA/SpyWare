using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyWare
{
    //Атрибут, для коректної роботи протоколу Protobuf
    [ProtoContract] 
    public class KeyBoardInteractionInfo
    {
        [ProtoMember(0)] //Атрибут, для коректної роботи протоколу Protobuf
        public string Value { get; set; }
        [ProtoMember(1)] //Атрибут, для коректної роботи протоколу Protobuf
        public string Key { get; set; }
        [ProtoMember(2)] //Атрибут, для коректної роботи протоколу Protobuf
        public string TimePressed { get; set; }
    }
}
