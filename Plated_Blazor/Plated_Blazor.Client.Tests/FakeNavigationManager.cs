using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plated_Blazor.Client.Tests;

internal class FakeNavigationManager : NavigationManager
{
    public string? NavigatedTo { get; private set; }

    public FakeNavigationManager()
    {
        Initialize("http://localhost/", "http://localhost/");
    }

    protected override void NavigateToCore(string uri, bool forceLoad)
    {
        NavigatedTo = uri; // 呼ばれたURLを記録
    }
}
