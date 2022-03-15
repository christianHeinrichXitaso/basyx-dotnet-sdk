/*******************************************************************************
* Copyright (c) 2022 Bosch Rexroth AG
* Author: Constantin Ziesche (constantin.ziesche@bosch.com)
*
* This program and the accompanying materials are made available under the
* terms of the MIT License which is available at
* https://github.com/eclipse-basyx/basyx-dotnet/blob/main/LICENSE
*
* SPDX-License-Identifier: MIT
*******************************************************************************/
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace BaSyx.Utils.Extensions
{
    public static class StringOperations
    {
        public static string GetValueOrStringEmpty<T>(this T? nullable) where T : struct
        {
            if (nullable != null)
            {
                var value = Nullable.GetUnderlyingType(nullable.GetType());
                if (value != null && value.IsEnum)
                    Enum.GetName(Nullable.GetUnderlyingType(nullable.GetType()), nullable.Value);
                else
                    return nullable.Value.ToString();
            }
            return string.Empty;
        }

        public static string ToUpperFirstChar(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string ToLowerFirstChar(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToLower(s[0]) + s.Substring(1);
        }

        public static string Base64Encode(this byte[] bytesToEncode)
        {
            return Convert.ToBase64String(bytesToEncode);
        }

        public static string Base64Encode(this string toEncode)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(toEncode);
            return Convert.ToBase64String(bytes);
        }

        public static string Base64Decode(this string toDecode)
        {
            byte[] bytes = Convert.FromBase64String(toDecode);
            return Encoding.UTF8.GetString(bytes);           
        }

        public static byte[] GetBytes(string base64EncodedString)
        {
            byte[] bytes = Convert.FromBase64String(base64EncodedString);
            return bytes;
        }

        public static bool IsBase64String(this string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

        } 
    }
}
