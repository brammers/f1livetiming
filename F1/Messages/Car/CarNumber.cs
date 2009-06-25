﻿/*
 *  f1livetiming - Part of the Live Timing Library for .NET
 *  Copyright (C) 2009 Liam Lowey
 *  
 *      http://livetiming.turnitin.co.uk/
 *
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  you may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at 
 *  
 *      http://www.apache.org/licenses/LICENSE-2.0 
 *  
 *  Unless required by applicable law or agreed to in writing, software 
 *  distributed under the License is distributed on an "AS IS" BASIS, 
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
 *  See the License for the specific language governing permissions and 
 *  limitations under the License. 
 */

namespace F1.Messages.Car
{
    /// <summary>
    /// Specifies the FIA assigned car number for a given car.
    /// </summary>
    public class CarNumber : CarBaseMessage
    {
        /// <summary>
        /// It's FIA car number.
        /// </summary>
        public int Number { get; private set; }

        public override string ToString()
        {
            return "CarBaseMessage: CarNumber - CarId: " + CarId + ", Colour: " + Colour + ", Number: " + Number;
        }

        protected override void OnDeserialiseComplete()
        {
            Number = DeserialiseInteger();
        }
    }
}
