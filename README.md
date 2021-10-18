# Dotnet5CleanArchitecture

DOTNET CLI Approach

CREATE PROJECTS

c:\repo>  mkdir dotnet5CleanArchitecuture
c:\repo>  cd dotnet5CleanArchitecuture
c:\repo\dotnet5CleanArchitecuture>   dotnet new sln -n CleanArchitecture
c:\repo\dotnet5CleanArchitecuture>   dotnet new classlib -n CleanArchitecture.Domain
c:\repo\dotnet5CleanArchitecuture>   dotnet new classlib -n CleanArchitecture.Application
c:\repo\dotnet5CleanArchitecuture>   dotnet new classlib -n CleanArchitecture.Infrastructure
c:\repo\dotnet5CleanArchitecuture>   dotnet new webapi -n CleanArchitecture.Api

ADD PROJECTS TO SOLUTION
c:\repo\dotnet5CleanArchitecuture>   dotnet sln CleanArchitecture.sln add CleanArchtecture.Domain\CleanArchitecture.Domain.csproj
c:\repo\dotnet5CleanArchitecuture>   dotnet sln CleanArchitecture.sln add CleanArchtecture.Application\CleanArchitecture.Application.csproj
c:\repo\dotnet5CleanArchitecuture>   dotnet sln CleanArchitecture.sln add CleanArchtecture.Infratructure\CleanArchitecture.Infrastructure.csproj
c:\repo\dotnet5CleanArchitecuture>   dotnet sln CleanArchitecture.sln add CleanArchtecture.Api\CleanArchitecture.Api.csproj

ADD PROJECT REFERENCES 
c:\repo\dotnet5CleanArchitecuture>   dotnet add CleanArchitecture.Application\CleanArchitecture.Application.csproj reference CleanArchitecture.Domain\CleanArchitecture.Domain.csproj
c:\repo\dotnet5CleanArchitecuture>   dotnet add CleanArchitecture.Infrastructure\CleanArchitecture.Infrastructure.csproj  reference CleanArchitecture.Domain\CleanArchitecture.Domain.csproj
c:\repo\dotnet5CleanArchitecuture>   dotnet add CleanArchitecture.Infrastructure\CleanArchitecture.Infrastructure.csproj  reference CleanArchitecture.Application\CleanArchitecture.Application.csproj
c:\repo\dotnet5CleanArchitecuture>   dotnet add CleanArchitecture.Api\CleanArchitecture.Api.csproj reference CleanArchitecture.Application\CleanArchitecture.Application.csproj
c:\repo\dotnet5CleanArchitecuture>   dotnet add CleanArchitecture.Api\CleanArchitecture.Api.csproj reference CleanArchitecture.Infrastructure\CleanArchitecture.Infrastructure.csproj


OPEN IN CODE
c:\repo\dotnet5CleanArchitecuture> Code .


ADD DEPENDENCY INJECTION.CS FILES TO APPLICATION AND INFRASTRUCTURE
namespace CleanArchtiecture.Application
{
	public static class Injection
	{
		public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuraton)
		{
			return services;
		}
	}
}

namespace CleanArchtiecture.Infrastructure
{
	public static class Injection
	{
		public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuraton)
		{
			return services;
		}
	}
}




ADD FOLLOWING NUGET PACKAGES TO APPLICATION AND INFRSTRUCTURE 
Applicaiton> dotnet add package Microsoft.Extensions.Configuration
Applicaiton> dotnet add package Microsoft.Extensions.DependencyInjection

Infrastructure> dotnet add package Microsoft.Extensions.Configuration
Infrastrcture> dotnet add package Microsoft.Extensions.DependencyInjection


ADD INJECTION METHODS INTO STARTUP.CS CONFIGURAITONSERVICES METHOD


Services.AddSwagger();
---
Services.RegisterApplicaitonServices(Configuraiotn);
Services.RegisterInfrastructureServices(Configuraiotn);


CREATE TABLE CLASS
Tables classes should be created under DOMAIN project e.g. Gadget  

INTERFACES should be created under APPLICATION project. e.g. IDbContext


ADD EntityFrameworkCore PACAKGE TO APPLICATION AND INFRASTRUCTURE projects

Applicaiton> dotnet add package Microsoft.EntityFrameworkCore
Infrastrcture> dotnet add package Microsoft.EntityFrameworkCore

