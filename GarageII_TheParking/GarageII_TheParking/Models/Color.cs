using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageII_TheParking.Models {
   // enum drop down not supported... i will have to look into the feacability of making something that supports flagenums later.. [Flags]
    public enum Colors {
        Brown = 0,
        DarkBrown = 1,
        LightBrown = 2 << 0,
        Yellow = 2 << 1,
        DarkYellow = 2 << 2,
        LightYellow = 2 << 3,
        Red = 2 << 4,
        DarkRed = 2 << 5,
        LightishRed = 2 << 6,
        Purple = 2 << 7,
        DarkPurple = 2 << 8,
        LightPurple = 2 << 9,
        Blue = 2 << 10,
        DarkBlue = 2 << 11,
        LightBlue = 2 << 12,
        Teal = 2 << 13,
        DarkTeal = 2 << 14,
        LightTeal = 2 << 15,
        Green = 2 << 16,
        DarkGreen = 2 << 17,
        LightGreen = 2 << 18,
        Silver = 2 << 19,
        Gold = 2 << 20,
        Black = 2 << 21,
        DarkGray = 2 << 22,
        Gray = 2 << 23,
        LightGray = 2 << 24,
        White = 2 << 25,
    }



}