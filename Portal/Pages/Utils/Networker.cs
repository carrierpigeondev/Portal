// SPDX-License-Identifier: Apache 2.0
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Portal
{
    internal class Networker
    {
        internal static readonly string[] separator = new[] { "\r\n", "\n" };

        public static async Task<List<string>?> FetchUrls()
        {
            List<string> urls = new List<string>();

            string? fetchUrl = Environment.GetEnvironmentVariable("PORTAL_FETCH_URL");
            System.Diagnostics.Debug.WriteLine($"PORTAL_FETCH_URL: {fetchUrl}");
            if (fetchUrl == null)
            {
                System.Diagnostics.Debug.WriteLine("PORTAL_FETCH_URL environment variable is not set.");
                return null;
            }

            try
            {
                using HttpClient client = new HttpClient();
                string content = await client.GetStringAsync(fetchUrl);
                urls = [.. content.Split(separator, StringSplitOptions.None)];
            }
            catch (HttpRequestException e)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching URLs: {e.Message}");
                return null;
            }

            return urls;
        }
    }
}
