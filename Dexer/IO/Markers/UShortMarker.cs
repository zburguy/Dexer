﻿/*
    Dexer, open source framework for .DEX files (Dalvik Executable Format)
    Copyright (C) 2010 Sebastien LEBRETON

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.IO;
using Dexer.Extensions;

namespace Dexer.IO.Markers
{

    internal class UShortMarker : Marker<ushort>
    {
        public override ushort Value
        {
            set {
                foreach (uint position in Positions)
                {
                    Writer.PreserveCurrentPosition(position, () =>
                    {
                        Writer.Write(value);
                    });
                }
            }
        }

        public override void Allocate()
        {
            Writer.Write((ushort) 0);
        }

        public UShortMarker(BinaryWriter writer) : base(writer) { }

    }

}
