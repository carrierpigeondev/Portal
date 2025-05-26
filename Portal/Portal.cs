// SPDX-License-Identifier: MIT
//
// Copyright (c) Microsoft Corporation
// Licensed under the MIT License. See LICENSE file for details.
//
// Minor modifications made by Carrier Pigeon Dev (carrierpigeon.dev@gmail.com).

using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.CommandPalette.Extensions;

namespace Portal;

[Guid("3d830ed4-bfb9-4210-972a-a3653e75a0be")]
public sealed partial class Portal : IExtension, IDisposable
{
    private readonly ManualResetEvent _extensionDisposedEvent;

    private readonly PortalCommandsProvider _provider = new();

    public Portal(ManualResetEvent extensionDisposedEvent)
    {
        this._extensionDisposedEvent = extensionDisposedEvent;
    }

    public object? GetProvider(ProviderType providerType)
    {
        return providerType switch
        {
            ProviderType.Commands => _provider,
            _ => null,
        };
    }

    public void Dispose() => this._extensionDisposedEvent.Set();
}
