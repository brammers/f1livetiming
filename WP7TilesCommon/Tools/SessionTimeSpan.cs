﻿/*
 *  f1livetiming - Part of the Live Timing Library for .NET
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

using System;

namespace WP7TilesCommon.Tools
{
    public static class SessionTimeSpan
    {
        public static TimeSpan Practice1 { get { return TimeSpan.FromMinutes(90); } }
        public static TimeSpan Practice2 { get { return TimeSpan.FromMinutes(90); } }
        public static TimeSpan Practice3 { get { return TimeSpan.FromMinutes(60); } }

        public static TimeSpan Qualifying { get { return TimeSpan.FromMinutes(60); } }
        public static TimeSpan Race { get { return TimeSpan.FromMinutes(120); } }
    }
}
