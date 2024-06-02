// Helpers/ServiceLocator.cs
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MauiHangmanGames.Helpers
{
    public static class ServiceLocator
    {
        public static IServiceProvider? ServiceProvider { get; set; }
    }
}
