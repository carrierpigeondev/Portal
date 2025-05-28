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

namespace Portal
{
    internal class Fetching
    {
        public static async Task<List<Dictionary<string, string>>> FetchURLs()
        {
            System.Diagnostics.Debug.WriteLine("Fetch called.");

            string? fetchURI = Environment.GetEnvironmentVariable("PORTAL_FETCH_URI");
            System.Diagnostics.Debug.WriteLine($"PORTAL_FETCH_URI: {fetchURI}");
            if (fetchURI == null)
            {
                System.Diagnostics.Debug.WriteLine("PORTAL_FETCH_URI environment variable is not set.");
                throw new PortalFetchURLEnvNotSetException("PORTAL_FETCH_URI environment variable is not set.");
            }

            if (Uri.TryCreate(fetchURI, UriKind.Absolute, out Uri? res) && res.Scheme != Uri.UriSchemeFile)
            {
                return await Networking.FetchURLsRemote(fetchURI);
            }
            else if (!string.IsNullOrWhiteSpace(fetchURI) && Path.IsPathRooted(fetchURI) && Path.Exists(fetchURI))
            {
                return FileHelping.FetchURLsLocal(fetchURI);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid fetch URI. Falling back to last URLs.");
                return Parsing.ParseToURLList(FileHelping.ReadLastURLS());
            }
        }
    }
}
