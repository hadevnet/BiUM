using Microsoft.AspNetCore.Mvc;

namespace BiUM.Infrastructure.Common.API;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
sealed class BiUMRouteAttribute(string domainCode) : RouteAttribute($"/api/{domainCode}/[controller]/[action]");