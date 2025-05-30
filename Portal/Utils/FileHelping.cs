﻿// SPDX-License-Identifier: Apache 2.0
//
// Copyright 2025 Carrier Pigeon Dev (carrierpigeon.dev@gmail.com).
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Portal
{
    internal class FileHelping
    {
        private static readonly string _lastURLsFile = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "last_urls");
        public static string ReadLastURLS() 
        {
            if (!File.Exists(_lastURLsFile)) WriteLastURLS("");
            return File.ReadAllText(_lastURLsFile);
        }
        public static void WriteLastURLS(string content) => File.WriteAllText(_lastURLsFile, content);

        public static List<Dictionary<string, string>> FetchURLsLocal(string fetchURI)
        {
            System.Diagnostics.Debug.WriteLine("Local fetch called.");
            string content = File.ReadAllText(fetchURI);
            return Parsing.ParseToURLList(content);
        }
    }
}
