﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Config {

    // msgType
    public const UInt16 MSG_CS_MOVETO = 0x1002;
    public const UInt16 MSG_SC_MOVETO = 0x2002;
    public const UInt16 MSG_SC_NEWPLAYER = 0x2003;
    public const UInt16 MSG_CS_LOGIN = 0x1001;
    public const UInt16 MSG_SC_GAMESTART = 0x2001;
    public const UInt16 MSG_SC_CONFIRM = 0x2011;
    public const UInt16 MSG_SC_NEWMONSTER = 0x2004;
    public const UInt16 MSG_SC_MONSTER_MOVE = 0x2005;
    public const UInt16 MSG_CS_TRAPPLACE = 0x1003;
    public const UInt16 MSG_SC_TRAPPLACE = 0x2006;
    public const UInt16 MSG_CS_MONSTER_DAMAGE = 0x1004;
    public const UInt16 MSG_SC_MONSTER_STATE = 0x2007;
    public const UInt16 MSG_SC_PLAYER_INFO = 0x2008;
    public const UInt16 MSG_SC_MONSTER_DEATH = 0x2009;
    public const UInt16 MSG_SC_ROUND_STATE = 0x2010;
    public const UInt16 MSG_SC_GAME_RESET = 0x2012;
    public const UInt16 MSG_CS_BUY_TRAP = 0x1005;

    //player state
    public const UInt16 PLAYER_STATE_COMMON = 0;
    public const UInt16 PLAYER_STATE_TRAPING = 1;
    public const UInt16 PLAYER_STATE_BUYING = 2;

    public const UInt32 TRAP_COST = 100;

    Config()
    {

    }

}
