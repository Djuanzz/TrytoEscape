using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryRoomController : MonoBehaviour
{
    [SerializeField]
    private TryRoomPage roomUI;
    
    public ActiveRoom activeRoom;
    public RoomPov roomPov;
    public EnumFunction enumFunction;

    // ----- PROGRAM UDAH WORKS UNTUK GANTI POV ROOM, TAPI MASIH ADA BUG BERUPA SAAT GANTI POV OBJECT YANG SUDAH TERGENERATE HASIL DARI COMBINE TETAP MENGHILANG KETIKA KEMBALI KE POV SEMULA, MALAH TERGENERATE OBJECT YANG LAMA -> MUNGKIN INI SALAH DI FUNCTION SPAWN OBJECTNYA

}
