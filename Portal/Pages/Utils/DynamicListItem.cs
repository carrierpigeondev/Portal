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

namespace Portal
{
    internal sealed partial class DynamicListItem : ListItem
    {
        public DynamicListItem(ICommand command) : base(command)
        {
        }

        public static async Task<DynamicListItem> CreateAsync(PortalPage page)
        {
            InvokableCommand command;
            DynamicListItem item;

            List<Dictionary<string, string>> newUrlDictList = [];

            try
            {
                newUrlDictList = await Networker.FetchUrls();
                command = new AnonymousCommand(action: () => page.UpdateUrls(newUrlDictList))
                {
                    Result = CommandResult.KeepOpen()
                };

                item = new DynamicListItem(command)
                {
                    Title = "Load URLs"
                };
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"An error occured. All details of the exception message: {e.Message}.\nThe following is the stack trace: {e.StackTrace}.");
                newUrlDictList = [];

                command = new ShowMessageCommand("An error occured.", $"All details of the exception message: {e.Message}.\nThe following is the stack trace: {e.StackTrace}.");
                item = new DynamicListItem(command)
                {
                    Title = "An Error Occured (Click me to see error)..."
                };
            }

            return item;
        }
    }
}
