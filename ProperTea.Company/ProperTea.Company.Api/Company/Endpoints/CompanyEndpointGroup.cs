namespace ProperTea.Company.Api.Company.Endpoints
{
    public static class CompanyEndpointGroup
    {
        public static IEndpointRouteBuilder MapCompanyEndpoints(this IEndpointRouteBuilder endpoints)
        {
            GetCompaniesEndpoint.Map(endpoints);
            GetCompanyByIdEndpoint.Map(endpoints);
            CreateCompanyEndpoint.Map(endpoints);
            DeleteCompanyEndpoint.Map(endpoints);
            ChangeCompanyNameEndpoint.Map(endpoints);
            return endpoints;
        }
    }
}
