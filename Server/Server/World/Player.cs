using System;
using System.Collections.Generic;

using common;

public class Player
{
    public int globalid { private set; get; }

    public CharacterDTO dto { private set; get; }
    
    public Vector pos { private set; get; }

    public UserToken token { private set; get; }

    public Player(int id_, Vector pos_, CharacterDTO dto_, UserToken token_)
    {
        globalid = id_;
        pos = pos_;

        dto = dto_;
        token = token_;
    }
}