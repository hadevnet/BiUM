using Microsoft.AspNetCore.Mvc;

namespace BiUM.Specialized.Common.API;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public class BiUMRouteAttribute(string domainCode) : RouteAttribute($"/api/{domainCode}/[controller]/[action]");