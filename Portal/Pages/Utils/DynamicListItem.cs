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

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portal
{
    internal sealed partial class DynamicListItem : ListItem
    {
        public DynamicListItem(ICommand command) : base(command)
        {
        }

        public static async Task<DynamicListItem> CreateAsync(PortalPage page)
        {
            List<string>? newUrls = await Networker.FetchUrls();
            if (newUrls == null)
            {
                // Have the null state so that more error handling could be implemented here
                // I'm too lazy and just want this to work for now, so no error handling for you >:)
                newUrls = new List<string>();
            }

            var command = new AnonymousCommand(action: () => page.UpdateUrls(newUrls))
            {
                Result = CommandResult.KeepOpen()
            };

            return new DynamicListItem(command);
        }
    }
}
