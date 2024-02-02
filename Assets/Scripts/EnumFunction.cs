using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumFunction : MonoBehaviour
{
    public ActiveRoom ChangeRoom(int idx){
        switch (idx){
            case 0 : return ActiveRoom.Chillroom;
            case 1 : return ActiveRoom.Cave;
            default:
                return ActiveRoom.Chillroom;
        }
    }

    public RoomPov ChangePov(int idx){
        switch (idx){
            case 0 : return RoomPov.Afront;
            case 1 : return RoomPov.Bright;
            case 2 : return RoomPov.Cback;
            case 3 : return RoomPov.Dleft;
            default:
                return RoomPov.Afront;
        }
    }

}
