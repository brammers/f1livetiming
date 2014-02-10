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

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using F1.Runtime;

namespace F1.Simulator
{
    /// <summary>
    /// <para>
    /// Decodes a file which has the following format:
    /// </para>
    /// <c>
    /// 6645 = 0xAC701BAE
    /// 6644 = 0xBF941139
    /// 6642 = 0xC1AD82A5
    /// 6638 = 0x9BA5B44C
    /// 6635 = 0x9DF36FD0
    /// </c>
    /// <para>
    /// Return a decryption key from the mapping loaded in the session file.
    /// </para>
    /// </summary>
    public class AuthorizationKey : IAuthKey
    {
        private readonly Dictionary<string, uint> _keyLookup = new Dictionary<string, uint>();
        private readonly uint _key;

        public AuthorizationKey(string keyPath)
        {
            ParseFile(keyPath);
        }


        public AuthorizationKey(uint key)
        {
            _key = key;
        }


        public uint GetKey(string session)
        {
            if( _keyLookup.ContainsKey(session) )
            {
                return _keyLookup[session];
            }
            return _key;
        }


        private void ParseFile(string keyPath)
        {
            using( FileStream s = File.OpenRead(keyPath))
            {
                using(TextReader t = new StreamReader(s))
                {
                    for( string nextLine = t.ReadLine(); !string.IsNullOrEmpty(nextLine); nextLine = t.ReadLine())
                    {
                        string[] split = nextLine.Split('=');
                        string[] value = split[1].Split('x');


                        _keyLookup[split[0].Trim()] = uint.Parse(value[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                    }
                }
            }
        }
    }
}
